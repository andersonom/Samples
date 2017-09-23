using AutoMapper;
using SimpleLogin.Domain.Entities;
using SimpleLogin.Domain.Interfaces.Repositories;
using SimpleLoginViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleLogin.Controllers
{
    public class AppController : Controller
    {
        private readonly IUserProfileAppService _userProfileAppService;

        public AppController(IUserProfileAppService userProfileAppService)
        {
            _userProfileAppService = userProfileAppService;
        }

        // GET: Api
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileViewModel>>(_userProfileAppService.GetAll()));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileViewModel userProfileViewModel)
        {

            if (ModelState.IsValid)
            {
               var userProfileDomain = Mapper.Map<UserProfileViewModel, UserProfile>(userProfileViewModel);
                _userProfileAppService.Add(userProfileDomain);
                return RedirectToAction("Index");
            }

            return View(userProfileViewModel);
        }
    }
}