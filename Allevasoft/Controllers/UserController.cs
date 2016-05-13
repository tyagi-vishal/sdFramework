using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Allevasoft.Services;
using Allevasoft.Entities.Classes;

namespace Allevasoft.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }
        
        [AllowAnonymous]
        // GET: User
        public ActionResult Index()
        {
            //List<User> searchUserList = new List<User>();
            //searchUserList = _userService.GetAll();
            

            Patient objToUpdate = _userService.GetSinglePatient();
            objToUpdate.FirstName = "Sumit";
            objToUpdate.LastName = "Manoga";

            _userService.UpdatePatient(objToUpdate);
           
            //Module objToAdd = new Module();
            //objToAdd.ModuleName = "Patient";
            //objToAdd.CreatedDate = DateTime.Now;
            //objToAdd.ModifiedDate = DateTime.Now;
            //objToAdd.CreatedBy = 2;
            //_userService.AddModule(objToAdd);
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //_userService.
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
