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
    public class ReferralService : IReferralService
    {
        AllevasoftEntities objEntity = new AllevasoftEntities();
        private IUnitOfWork _uow;
        private IRepository<GlobalCode> _globalCodeRepository;
        private IRepository<ReferralCompany> _referralCompanyRepository;
        private IRepository<ReferralContact> _referralContactRepository;
        public ReferralService(IUnitOfWork uow)
        {
            _uow = uow;
            _globalCodeRepository= _uow.GetRepository<GlobalCode>();
            _referralCompanyRepository = _uow.GetRepository<ReferralCompany>();
            _referralContactRepository = _uow.GetRepository<ReferralContact>();
        }
        

        public List<ssp_GetAllReferralSource_Result> GetAllReferralType()
        {
            return objEntity.ssp_GetAllReferralSource().ToList(); ;
        }

        public List<ssp_GetAllReferralCategory_Result> GetAllReferralCategory(int GlobalCodeId)
        {
            return objEntity.ssp_GetAllReferralCategory(GlobalCodeId).ToList();
        }

        public List<ssp_GetAllReferralCompanies_Result> GetAllReferralCompanies()
        {
             return objEntity.ssp_GetAllReferralCompanies().ToList();
        }

        public List<ssp_GetAllReferralCompanyById_Result> GetAllReferralCompanyById(int Id)
        {
            return objEntity.ssp_GetAllReferralCompanyById(Id).ToList();
        }


        public List<ssp_GetAllReferralContact_Result> GetAllReferralContact()
        {
            return objEntity.ssp_GetAllReferralContact().ToList();
        }
        public List<ssp_GetAllReferralContactById_Result> GetAllReferralContactById(int Id)
        {
            return objEntity.ssp_GetAllReferralContactById(Id).ToList();
        }

        public long AddReferralCompany(ReferralCompany _referralCompany)
        {
            _referralCompanyRepository.Add(_referralCompany);
            _uow.SaveChanges();
            return _referralCompany.ReferralCompanyId;
        }

        public void UpdateReferralCompany(ReferralCompany _referralCompany)
        {
            _referralCompanyRepository.Update(_referralCompany);
            _uow.SaveChanges();
        }


        public long AddReferralContact(ReferralContact _referralContact)
        {
            _referralContactRepository.Add(_referralContact);
            _uow.SaveChanges();
            return _referralContact.ReferralContactId;
        }

        public long UpdateReferralContact(ReferralContact _referralContact)
        {
            _referralContactRepository.Update(_referralContact);
            _uow.SaveChanges();
            return 0;
        }

    }
}
