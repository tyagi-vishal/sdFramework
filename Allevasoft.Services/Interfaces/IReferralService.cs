using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allevasoft.Entities.Classes;
using Allevasoft.Entities;

namespace Allevasoft.Services
{
    public interface IReferralService
    {
        List<ssp_GetAllReferralCompanies_Result> GetAllReferralCompanies();

        List<ssp_GetAllReferralCompanyById_Result> GetAllReferralCompanyById(int Id);

        List<ssp_GetAllReferralContact_Result> GetAllReferralContact();

        List<ssp_GetAllReferralContactById_Result> GetAllReferralContactById(int Id);

        List<ssp_GetAllReferralSource_Result> GetAllReferralType();

        List<ssp_GetAllReferralCategory_Result> GetAllReferralCategory(int GlobalCodeId);
        
        long AddReferralCompany(ReferralCompany _referralCompany);
        void UpdateReferralCompany(ReferralCompany _referralCompany);

        long AddReferralContact(ReferralContact _referralContact);

        long UpdateReferralContact(ReferralContact _referralContact);
    }
}
