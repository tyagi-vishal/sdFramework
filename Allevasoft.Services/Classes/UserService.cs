using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allevasoft.DataAccess.Repository;
using Allevasoft.Entities.Classes;
using Allevasoft.DataAccess.Edmx;
using Allevasoft.Entities.PartialClass;

namespace Allevasoft.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;
        private IRepository<UserTemp> _userTempRepository;
        private IRepository<Module> _moduleRepository;
        private IRepository<Patient> _patientRepository;
        private IRepository<User> _userRepository;

        public UserService()
        {

        }
        /// <summary>
        /// Initializes a new instance of the AdvertisementService class.
        /// </summary>
        /// <param name="uow"></param>       
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _userTempRepository = _uow.GetRepository<UserTemp>();
            _moduleRepository = _uow.GetRepository<Module>();
            _patientRepository = _uow.GetRepository<Patient>();
            _userRepository = _uow.GetRepository<User>();
        }

        #region user Service

        /// <summary>
        /// List all the users.
        /// </summary>
        /// <returns></returns>
        public List<UserTemp> GetAll()
        {
            return _userTempRepository.GetAll().ToList();
        }

        /// <summary>
        /// Add a new user.
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public long AddUser(UserTemp _user)
        {
            _userTempRepository.Add(_user);
            _uow.SaveChanges();
            return _user.UserId;
        }
        public long AddModule(Module _module)
        {
            _moduleRepository.Add(_module);
            _uow.SaveChanges();
            return _module.ModuleID;
        }
        public List<Module> GetAllModule()
        {
            return _moduleRepository.GetAll().ToList();
        }

        public void UpdateModule(Module _objToUpdate)
        {
            _moduleRepository.Update(_objToUpdate);
            _uow.SaveChanges();
        }

        public Patient GetSinglePatient()
        {
            return _patientRepository.GetSingleOrDefault();
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll().ToList();
        }

        public void UpdatePatient(Patient _objToUpdate)
        {
            _patientRepository.Update(_objToUpdate);
            _uow.SaveChanges();
        }


        /// <summary>
        /// Get Logged user Information
        /// </summary>
        /// <CreatedBy>Neeraj Sharma</CreatedBy>
        /// <On>May 10, 2016</On>
        /// <param name="Email">Login user email id</param>
        /// <returns>Login Information model</returns>
        public LoggedUserInformationModel GetLoggedUserInformation(string userName)
        {

            AllevasoftEntities _objectAlleva = new AllevasoftEntities();

            var result = _objectAlleva.Users.Where(x => x.UserName == userName).Select(x => new LoggedUserInformationModel
            {
                Address1 = x.Address1,
                facilityId = 1,
                Domain = null,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LoginUserId = x.UserId,
                UserId = x.AspNetUserId,
                RoleTypeId  = x.RoleId,
                RoleType = x.Role.RoleName,
                TimeZoneName = null,
                UserIp = null
            }).FirstOrDefault();

            return result;

        }


        #endregion
    }
}
