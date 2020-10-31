using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
using Form_App.ViewModels;
using Form_App.ViewModels.TherapyInfoViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Form_App.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class TherapyController : Controller
    {
        private readonly ITherapyService _therapyService;
        private readonly IPatientService _patientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TherapyController(ITherapyService therapyService, UserManager<ApplicationUser> userManager, IPatientService patientService)
        {
            _therapyService = therapyService;
            _userManager = userManager;
            _patientService = patientService;
        }


        [HttpGet]

        public async Task<ActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int userId = user.Id;
            var therapiesByLoggedUserList = _therapyService.GetAllByLoggedUser(userId);
            var therapyList = new List<TherapyListViewModel>();
            foreach (var therapy in therapiesByLoggedUserList)
            {
                therapyList.Add(new TherapyListViewModel
                {
                    ID = therapy.ID,
                    Review = therapy.Review,
                    Disorder = therapy.Disorder,
                    RangeOfMotion = therapy.RangeOfMotion,
                    VasScale = therapy.VasScale,
                    Tests = therapy.Tests,
                    TherapyTecnics = therapy.TherapyTecnics,
                    Recommendation = therapy.Recommendation,
                    AdditionalInfo = therapy.AdditionalInfo
                });
            }
            return View(therapyList);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var therapy = _therapyService.Get(id);
            var therapyDetailsViewModel = new DetailsTherapyViewModel
            {
                ID = therapy.ID,
                Review = therapy.Review,
                Disorder = therapy.Disorder,
                RangeOfMotion = therapy.RangeOfMotion,
                VasScale = therapy.VasScale,
                Tests = therapy.Tests,
                TherapyTecnics = therapy.TherapyTecnics,
                Recommendation = therapy.Recommendation,
                AdditionalInfo = therapy.AdditionalInfo
            };

            return View(therapyDetailsViewModel);
        }

        // GET: RecipeController/Create
        [HttpGet]
        public IActionResult Add(int id)
        {
            var patient = _patientService.Get(id);
            var addTherapyVewModel = new AddTherapyVewModel();
            addTherapyVewModel.PatientId = patient.ID;

            return View(addTherapyVewModel);
        }

        // POST: RecipeController/Create
        [HttpPost]

        public IActionResult Add(AddTherapyVewModel addTherapyVewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var therapyModel = new Therapy
                    {
                        Review = addTherapyVewModel.Review,
                        Disorder = addTherapyVewModel.Disorder,
                        RangeOfMotion = addTherapyVewModel.RangeOfMotion,
                        VasScale = addTherapyVewModel.VasScale,
                        Tests = addTherapyVewModel.Tests,
                        TherapyTecnics = addTherapyVewModel.TherapyTecnics,
                        Recommendation = addTherapyVewModel.Recommendation,
                        AdditionalInfo = addTherapyVewModel.AdditionalInfo,
                        CreationDate = DateTime.Now,
                        PatientID = addTherapyVewModel.PatientId
                    };
                    _therapyService.Create(therapyModel);

                    return RedirectToAction("Details", new { id = therapyModel.ID });
                }
                catch (Exception exception)
                {
                    return View(addTherapyVewModel);
                }
            }
            else
            {
                return View(addTherapyVewModel);
            }
        }

        // GET: RecipeController/Edit/5
        [HttpGet]

        public IActionResult Edit(int id)
        {

            var therapy = _therapyService.Get(id);
            var therapyEdit = new EditTherapyViewModel
            {
                ID = therapy.ID,
                Review = therapy.Review,
                Disorder = therapy.Disorder,
                RangeOfMotion = therapy.RangeOfMotion,
                VasScale = therapy.VasScale,
                Tests = therapy.Tests,
                TherapyTecnics = therapy.TherapyTecnics,
                Recommendation = therapy.Recommendation,
                AdditionalInfo = therapy.AdditionalInfo

            };
            return View(therapyEdit);
        }

        // POST: RecipeController/Edit/5
        [HttpPost]

        public IActionResult Edit(EditTherapyViewModel therapyVewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var therapy = _therapyService.Get(therapyVewModel.ID);
                    therapy.Review = therapyVewModel.Review;
                    therapy.Disorder = therapyVewModel.Disorder;
                    therapy.RangeOfMotion = therapyVewModel.RangeOfMotion;
                    therapy.VasScale = therapyVewModel.VasScale;
                    therapy.Tests = therapyVewModel.Tests;
                    therapy.TherapyTecnics = therapyVewModel.TherapyTecnics;
                    therapy.Recommendation = therapyVewModel.Recommendation;
                    therapy.AdditionalInfo = therapyVewModel.AdditionalInfo;

                    _therapyService.Update(therapy);
                    return RedirectToAction("Details", new { id = therapyVewModel.ID });
                }
                catch
                {
                    return View(therapyVewModel);
                }
            }
            else
            {
                return View(therapyVewModel);
            }
        }
    }
}
