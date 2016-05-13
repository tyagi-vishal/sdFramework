using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Data.Entity.Validation;
using System.Text;
using Allevasoft.Entities.Classes;
using System.Data.Entity;
using Allevasoft.Common.Helper;
//using System.Data;

namespace Allevasoft.DataAccess.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
        private readonly IDbContext _ctx;
        private Dictionary<Type, object> _repositories;
        private bool _disposed;

        /// <summary>
        /// List of properties for each type that will be logged by the application
        /// </summary>
        private Dictionary<Type, List<LogProperty>> AuditInfo { get; set; }

        /// <summary>
        /// List of types that will be logged by the application
        /// </summary>
        private List<LogType> TypesToLog { get; set; }

        public UnitOfWork()
        {
            _ctx = new TContext();

            _repositories = new Dictionary<Type, object>();
            _disposed = false;

        }
        public IDbContext DBContext
        {
            get { return _ctx; }

        }
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            // If the repository for that Model class doesn't exist, create it
            var repository = new Repository<TEntity>(_ctx);

            // Add it to the dictionary
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public void SaveChanges()
        {
            TypesToLog = this.GetRepository<LogType>().GetAll().ToList();
            //get a list of the changes that the user made
            var logs = new List<Log>();
            var properties = new List<LogPropertyChanx>();
            List<LogInfo> listOfModuleChanges = new List<LogInfo>();
            int? userId = null;
            DateTime now = DateTime.Now;
            foreach (var entry in _ctx.ChangeTracker.Entries<object>())
            {
                var entryType = entry.Entity.GetType();
                var typeInfo = (from i in TypesToLog
                                where i.Key == entryType.Name || entryType.Name.StartsWith(i.Key + "_")
                                select i).FirstOrDefault();
                if (typeInfo != null)
                {
                    int objectId = 0;
                    string clientId = "";
                    int? parentId = null;
                    Guid logId = Guid.NewGuid();
                    var message = "";
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            objectId = (int)entry.CurrentValues[typeInfo.IdName];
                            if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
                                //Value that identifies the object for the user (Name, number, etc)
                                clientId = (entry.CurrentValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
                            message = string.Format("A new {0} was created ({1})", typeInfo.Name, clientId);
                            if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
                                //Id of the parent (to be logged in children objects)
                                parentId = (int)entry.CurrentValues[typeInfo.ParentIdName];
                            break;
                        case EntityState.Deleted:
                            objectId = (int)entry.OriginalValues[typeInfo.IdName];
                            if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
                                //Value that identifies the object for the user (Name, number, etc)
                                clientId = (entry.OriginalValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
                            message = string.Format("The {0} {1} was deleted.", typeInfo.Name, clientId);
                            if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
                                //Id of the parent (to be logged in children objects)
                                parentId = (int)entry.OriginalValues[typeInfo.ParentIdName];
                            break;
                        case EntityState.Detached:
                            break;
                        case EntityState.Modified:
                            objectId = (int)entry.CurrentValues[typeInfo.IdName];

                            if (!string.IsNullOrWhiteSpace(typeInfo.ParentIdName))
                                //Id of the parent (to be logged in children objects)
                                parentId = (int)entry.CurrentValues[typeInfo.ParentIdName];
                            if (!string.IsNullOrWhiteSpace(typeInfo.ClientIdName))
                                //Value that identifies the object for the user (Name, number, etc)
                                clientId = (entry.OriginalValues[typeInfo.ClientIdName] ?? string.Empty).ToString();
                            var sb = new StringBuilder();
                            sb.AppendLine(string.Format("The {0} {1} was updated.", typeInfo.Name, clientId));
                            //Go through each of the properties that will be logged
                            foreach (var property in FieldsToLog(entryType))
                            {
                                string originalValue = entry.OriginalValues[property.Key] == null ? "" : entry.OriginalValues[property.Key].ToString();
                                string currentValue = entry.CurrentValues[property.Key] == null ? "" : entry.CurrentValues[property.Key].ToString();

                                if (originalValue != currentValue)
                                {
                                    if (property.LogValues)
                                    {
                                        sb.AppendLine(string.Format("-The value of {0} changed from {1} to {2}.", property.Name, originalValue, currentValue));
                                        //Log the changes to each property
                                        Guid LogPropertyChangeId = Guid.NewGuid();
                                        properties.Add(new LogPropertyChanx { LogId = logId, LogPropertyChangeId = LogPropertyChangeId, PropertyKey = property.Key, PreviousValue = originalValue, NewValue = currentValue, EncryptionKey = LogHelper.GetSHA1HashData(logId + LogPropertyChangeId.ToString() + property.Key + originalValue + currentValue) });
                                        listOfModuleChanges.Add(new LogInfo { ModuleName = typeInfo.Key, FieldName = property.Key, PreviousValue = originalValue, NewValue = currentValue,ModifiedDate=DateTime.UtcNow });
                                    }
                                    else
                                        sb.AppendLine(string.Format("-The value of {0} was changed.", property.Name));
                                }
                            }
                            message = sb.ToString();
                            break;
                        case EntityState.Unchanged:
                            break;
                        default:
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        logs.Add(new Log
                        {
                            LogId = logId,
                            ObjectId = objectId,
                            ParentId = parentId,
                            TypeKey = typeInfo.Key,
                            OperationKey = entry.State.ToString(),
                            UserId = userId,
                            Representative = false,
                            Message = message,
                            Created = now,
                            Processed = true,
                            SendEmail = false,
                            WriteAsFile = false
                        });
                    }
                }
            }

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }


            //write the list of user changes to the log table           
            
            foreach (var log in logs)
            {
                this.GetRepository<Log>().Add(log);              
            }
            foreach (var property in properties)
            {
                this.GetRepository<LogPropertyChanx>().Add(property);
            }
            foreach (var loginfo in listOfModuleChanges)
            {
                this.GetRepository<LogInfo>().Add(loginfo);
            }

            _ctx.SaveChanges();

        }

        /// <summary>
        ///	We are using reflection to figure out what fields we need to worry about
        ///   We are caching the results of the reflection so that we only need to do this
        ///   one time per entity type
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        private IEnumerable<LogProperty> FieldsToLog(Type entityType)
        {
            if (this.AuditInfo == null)
                this.AuditInfo = new Dictionary<Type, List<LogProperty>>();

            if (!this.AuditInfo.ContainsKey(entityType))
            {

                var properties = this.GetRepository<LogProperty>().GetAll(a => a.TypeKey == entityType.Name).ToList();

                this.AuditInfo.Add(entityType, properties);

                //var auditPropertyInfo = new List<LogProperty>();
                //var auditFields = typeof(IAuditable).GetProperties().Select(x => x.Name).ToList();
                //foreach (var property in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                //{
                //	if (!property.GetGetMethod().IsVirtual)
                //		auditPropertyInfo.Add(property.Name);
                //}
                //this.AuditInfo.Add(entityType, auditPropertyInfo);
            }

            return this.AuditInfo[entityType];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }

                this._disposed = true;
            }
        }
        public void Commit()
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                               new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                {


                    if (_ctx != null)
                        _ctx.SaveChanges();

                    scope.Complete();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Exception", ex);
            }

        }

    }
}