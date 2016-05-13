using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allevasoft.Entities.Classes;
using Allevasoft.Entities.PartialClass;

namespace Allevasoft.Services
{
    public interface IUserService
    {
        List<UserTemp> GetAll();
        Patient GetSinglePatient();
        long AddModule(Module _module);
        List<Module> GetAllModule();
        void UpdateModule(Module _objToUpdate);
        List<Patient> GetAllPatients();
        void UpdatePatient(Patient _objToUpdate);

        /// <summary>
        /// List loggedUserInformation
        /// </summary>
        /// <returns>list</returns>
       
      LoggedUserInformationModel GetLoggedUserInformation(string Email); 
    }
}
