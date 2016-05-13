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
    public class CommonService: ICommonService
    {
        AllevasoftEntities objEntity = new AllevasoftEntities();
        private IUnitOfWork _uow;
        private IRepository<ErrorLog> _errorlogRepository;
        private IRepository<LogInfo> _logInfoRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<GlobalCode> _globalCodeRepository;

        /// <summary>
        /// Initializes a new instance of the AdvertisementService class.
        /// </summary>
        /// <param name="uow"></param>       
        public CommonService(IUnitOfWork uow)
        {
            _uow = uow;
            _errorlogRepository = _uow.GetRepository<ErrorLog>();
            _logInfoRepository = _uow.GetRepository<LogInfo>();
            _globalCodeRepository = _uow.GetRepository<GlobalCode>();
            _countryRepository = _uow.GetRepository<Country>();
        }
        /// <summary>
        /// Used for API
        /// </summary>
        public CommonService()
        {
            _uow = new UnitOfWork<AllevasoftEntities>();
            _errorlogRepository = _uow.GetRepository<ErrorLog>();
            _logInfoRepository = _uow.GetRepository<LogInfo>();
        
        }

        #region Common Service



        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public long LogError(ErrorLog _error)
        {
            _errorlogRepository.Add(_error);
            return _error.Id;
        }
        public List<ssp_GetAllMenu_Result> GetAllMenu()
        {
             return objEntity.ssp_GetAllMenu().ToList();
        }

        public List<ssp_GetAllStates_Result> GetAllStates(int CountryId)
        {
            return objEntity.ssp_GetAllStates(CountryId).ToList();
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAll().ToList();
        }


        public List<LogInfo> GetAllLogList(int limit, int offset, string order, string sort, string SearchText, string ModuleName, string FieldName, string ModifiedBy, out int total)
        {

            if (!string.IsNullOrEmpty(SearchText))
            {

                var data = _logInfoRepository.GetAll(x => x.ModuleName == SearchText || x.FieldName == SearchText || x.PreviousValue == SearchText || x.NewValue == SearchText || x.ModifiedBy == SearchText).AsQueryable();
                //Order by
                GetSortedData(ref data, sort + order.ToUpper());
                total = data.Count();
                return data.Skip(offset).Take(limit).ToList();
            }
            else
            {

                var data = _logInfoRepository.GetAll().AsQueryable();
                //Order by
                GetSortedData(ref data, sort + order.ToUpper());
                total = data.Count();
                return data.Skip(offset).Take(limit).ToList();
            }

            //return allAuditLog;
        }
        public void GetSortedData(ref IQueryable<LogInfo> obj, string Case)
        {
            switch (Case)
            {
                case "ModuleNameASC":
                    obj = obj.OrderBy(x => x.ModuleName.ToLower());
                    break;
                case "FieldNameASC":
                    obj = obj.OrderBy(x => x.FieldName.ToLower());
                    break;
                case "ModifiedByASC":
                    obj = obj.OrderBy(x => x.UserId);
                    break;
                case "ModuleNamDESC":
                    obj = obj.OrderByDescending(x => x.UserId);
                    break;
                case "FieldNameDESC":
                    obj = obj.OrderByDescending(x => x.FieldName.ToLower());
                    break;
                case "ModifiedByDESC":
                    obj = obj.OrderByDescending(x => x.UserId);
                    break;
                default:
                    obj = obj.OrderBy(x => x.UserId);
                    break;
            }
        }

        public List<GlobalCode> GetGender() {
           return  _globalCodeRepository.GetAll().Where(x => x.Category == "GENDER").ToList();         
        }
        #endregion

        #region Dashboard
        public CRMDeatials GetDashBoardDetails(string actionParameter, string currentDate)
        {
            ssp_GetCRMDashbordDatails_Result ObjectBindTicketPageDropDownModel = new ssp_GetCRMDashbordDatails_Result();
            CRMDeatials _CRMDetails = new CRMDeatials();
            string val = actionParameter;
            // val=1....complete datat
            // val=''...Appointment data

            try
            {

                using (AllevasoftEntities objEntity = new AllevasoftEntities())
                {
                    DbDataReader _reader;
                    objEntity.Database.Initialize(force: false);
                    if (objEntity.Database.Connection.State != ConnectionState.Open)
                    {
                        objEntity.Database.Connection.Open();
                    }
                    var _dbCmd = objEntity.Database.Connection.CreateCommand();

                    _dbCmd.CommandType = CommandType.StoredProcedure;
                    _dbCmd.CommandTimeout = 60 * 5;
                    _dbCmd.CommandText = "ssp_GetCRMDashbordDatails";
                    _dbCmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@actionparameter", val),
                        new SqlParameter("@appointmentDateFilter",currentDate),
                    });
                    DbDataReader reader = _dbCmd.ExecuteReader();
                    //Product Type
                    List<ssp_GetCRMDashbordDatails_Result> _Leads = new List<ssp_GetCRMDashbordDatails_Result>();
                    List<Opportunities> _Opportunities = new List<Opportunities>();
                    List<ClientStatus> _ClientStatus = new List<ClientStatus>();
                    List<DischargeStatus> _DischargeStatus = new List<DischargeStatus>();
                    List<BedStatus> _BedStatus = new List<BedStatus>();
                    List<AppointmentStatus> _AppointmentStatus = new List<AppointmentStatus>();
                    List<Notes> _Notes = new List<Notes>();
                    List<Messages> _Message = new List<Messages>();
                    List<AlertsMessages> _AlertMessages = new List<AlertsMessages>();
                    if (val == "1")
                    {
                        // reading leads resultSet
                        if (reader.HasRows)
                        {

                            _Leads = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<ssp_GetCRMDashbordDatails_Result>(reader).ToList();

                        }
                        //reading Opportunity resultSet
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _Opportunities = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<Opportunities>(reader).ToList();

                        }
                        //reading ClientSatus resultSet
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _ClientStatus = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<ClientStatus>(reader).ToList();

                        }
                        //reading Discharge status
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _DischargeStatus = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<DischargeStatus>(reader).ToList();

                        }
                        //reading BedStatus status
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _BedStatus = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<BedStatus>(reader).ToList();

                        }
                        //reading AppointmentStatus status
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _AppointmentStatus = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<AppointmentStatus>(reader).ToList();

                        }
                        //reading Notes 
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _Notes = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<Notes>(reader).Take(3).ToList();
                                

                        }
                        //reading Messages
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _Message = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<Messages>(reader).ToList();

                        }
                        //reading AlertsMessages
                        reader.NextResult();

                        if (reader.HasRows)
                        {

                            _AlertMessages = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<AlertsMessages>(reader).ToList();

                        }
                        _CRMDetails._Oppertunities = _Opportunities;
                        _CRMDetails._Leads = _Leads;
                        _CRMDetails._ClientStatus = _ClientStatus;
                        _CRMDetails._DischargeStatus = _DischargeStatus;
                        _CRMDetails._BedStatus = _BedStatus;
                        _CRMDetails._Appointments = _AppointmentStatus;
                        _CRMDetails._Messages = _Message;
                        _CRMDetails._Notes = _Notes;
                        _CRMDetails._AlertsMessages = _AlertMessages;
                    }
                    else
                    {
                        if (reader.HasRows)
                        {

                            _AppointmentStatus = ((IObjectContextAdapter)objEntity).ObjectContext.Translate<AppointmentStatus>(reader).ToList();

                        }
                        _CRMDetails._Appointments = _AppointmentStatus;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _CRMDetails;
        }


        #endregion
    }
}

