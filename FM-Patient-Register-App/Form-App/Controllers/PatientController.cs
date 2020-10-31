using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
using Form_App.ViewModels;
using Form_App.ViewModels.PatientsInformationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Form_App.Controllers
{

    [Authorize(Roles = "User,Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(IPatientService patientService, UserManager<ApplicationUser> userManager)
        {
            _patientService = patientService;
            _userManager = userManager;
        }

        [HttpGet]
        
        public IActionResult Index()
        {
            var patientsByLoggedUserList = _patientService.GetAllByLoggedUser(User.Identity.Name);
            List<PatientListViewModel> patientList = new List<PatientListViewModel>();
            foreach (var patient in patientsByLoggedUserList)
            {
                patientList.Add(new PatientListViewModel
                {
                    ID = patient.ID,
                    Name = patient.Name,
                    Surname = patient.Surname,
                    PersonalId = patient.PersonalId
                });
            }
            return View(patientList);
        }
        
        [HttpGet]
        
        public IActionResult Details(int id)
        {
            var patient = _patientService.Get(id);
            DetailsPatienInfoViewModel patientDetailsViewModel = new DetailsPatienInfoViewModel
            {
                ID = patient.ID,
                Name = patient.Name,
                Surname = patient.Surname,
                PersonalId = patient.PersonalId,
                PhoneNumber = patient.PhoneNumber,
                HomeAdress = patient.HomeAdress,
                Email = patient.Email
            };
            if (_patientService.IsTherapyInPatientDetails(id))
            {
                patientDetailsViewModel.TherapiesforPatient = _patientService.GetTherapiesforPatients(patient.ID);
                return View(patientDetailsViewModel);
            }
            else
            {
                return View(patientDetailsViewModel);
            }
        }

        // GET: RecipeController/Create
        [HttpGet]
        public IActionResult Add(int ID)
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        
        public async Task<IActionResult> Add(PatientInfo patientViewModell)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var patientModel = new Patient
                    {
                        Name = patientViewModell.Name,
                        Surname = patientViewModell.Surname,
                        PersonalId = patientViewModell.PersonalId,
                        PhoneNumber = patientViewModell.PhoneNumber,
                        HomeAdress = patientViewModell.HomeAdress,
                        Email = patientViewModell.Email,
                        Created = DateTime.Now,
                        ApplicationUserID = user.Id
                    };

                    _patientService.Create(patientModel);

                    return RedirectToAction("Details", new { id = patientModel.ID });
                }
                catch (Exception exception)
                {
                    return View(patientViewModell);
                }
            }
            else
            {
                return View(patientViewModell);
            }
        }

        // GET: RecipeController/Edit/5
        [HttpGet]
        
        public IActionResult Edit(int id)
        {

            var patient = _patientService.Get(id);
            var patientInfo = new PatientInfo
            {
                ID = patient.ID,
                Name = patient.Name,
                Surname = patient.Surname,
                PersonalId = patient.PersonalId,
                PhoneNumber = patient.PhoneNumber,
                HomeAdress = patient.HomeAdress,
                Email = patient.Email
            };
            return View(patientInfo);
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        
        public IActionResult Edit(PatientInfo patientInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var patient = _patientService.Get(patientInfo.ID);
                    patient.Name = patientInfo.Name;
                    patient.Surname = patientInfo.Surname;
                    patient.PersonalId = patientInfo.PersonalId;
                    patient.PhoneNumber = patientInfo.PhoneNumber;
                    patient.HomeAdress = patientInfo.HomeAdress;
                    patient.Email = patientInfo.Email;

                    _patientService.Update(patient);
                    return RedirectToAction("Details", new { id = patientInfo.ID });
                }
                catch
                {
                    return View(patientInfo);
                }
            }
            else
            {
                return View(patientInfo);
            }
        }

        // GET: RecipeController/Delete/5
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var isOkToDelete = _patientService.CheckBeforeDelete(id);
            var deletePatient = _patientService.Get(id);
            DeletePatientInfoViewModel patientDelete = new DeletePatientInfoViewModel
            {
                ID = deletePatient.ID,
                Name = deletePatient.Name,
                Surname = deletePatient.Surname,
                PersonalId = deletePatient.PersonalId,
                IsOkToDelete = isOkToDelete
            };
            if (isOkToDelete == true)
            {
                ViewBag.CheckMsg = "Można bezpiecznie usunąć Pacjenta.";
            }
            else
            {
                ViewBag.CheckMsg = "Nie można usunąć Pacjenta, ponieważ jest zajestrowany gdzieindziej!";
            }
            return View(patientDelete);
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ConfirmRemove(int id)
        {
            _patientService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

