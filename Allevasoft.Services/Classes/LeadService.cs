using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allevasoft.DataAccess.Repository;
using Allevasoft.Entities.Classes;
using Allevasoft.DataAccess.Edmx;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Common;
using System.Data;
using System.Data.Entity.Infrastructure;
using Allevasoft.Entities;

namespace Allevasoft.Services
{
    public class LeadService : ILeadService
    {
        private IUnitOfWork _uow;
        private IRepository<LeadInfo> _leadInfoRepository;

        /// <summary>
        /// Initialize repositories.
        /// </summary>
        /// <param name="uow"></param>       
        public LeadService(IUnitOfWork uow)
        {
            _uow = uow;
            _leadInfoRepository = _uow.GetRepository<LeadInfo>();
        }

        /// <summary>
        /// Add lead information to database.
        /// </summary>
        /// <param name="_lead"></param>
        /// <returns></returns>
        public long AddLead(LeadInfo _lead)
        {
            _leadInfoRepository.Add(_lead);
            _uow.SaveChanges();
            return _lead.LeadId;
        }
        
        public List<LeadInfo> GetLeadsList(int limit, int offset, string order, string sort, string searchText,string firstName,string lastName, out int total)
        {            

            using (AllevasoftEntities objEntity = new AllevasoftEntities())
            {
               
                objEntity.Database.Initialize(force: false);
                if (objEntity.Database.Connection.State != ConnectionState.Open)
                {
                    objEntity.Database.Connection.Open();
                }
                var _dbCmd = objEntity.Database.Connection.CreateCommand();

                _dbCmd.CommandType = CommandType.StoredProcedure;
                _dbCmd.CommandTimeout = 60 * 5;
                _dbCmd.CommandText = "ssp_GetAllLeads";
                _dbCmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@FirstName", firstName),new SqlParameter("@LastName",lastName), new SqlParameter("@limit", limit), new SqlParameter("@offset", offset), new SqlParameter("@order", order), new SqlParameter("@sort", sort) });
                DbDataReader reader = _dbCmd.ExecuteReader();

                List<LeadInfo> _leadInfo = new List<LeadInfo>();

                if (reader.HasRows)
                {

                    _leadInfo = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<LeadInfo>(reader).ToList();

                }
                
                reader.NextResult();

                if (reader.HasRows)
                {

                    total = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<int>(reader).FirstOrDefault();

                }

                total = 10;
                return _leadInfo;
            }

          

        }
    }
}