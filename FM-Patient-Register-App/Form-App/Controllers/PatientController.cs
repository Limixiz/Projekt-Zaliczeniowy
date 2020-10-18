using System.Collections.Generic;
using Form_App.Models.DataBaseModel;
using Form_App.Services.Interfaces;
using Form_App.ViewModels;
using Form_App.ViewModels.PatientsInformationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Form_App.Controllers
{

    //[Authorize(Roles = "User,Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly UserManager<IdentityUser> _userManager;

        public PatientController(IPatientService patientService, UserManager<IdentityUser> userManager)
        {
            _patientService = patientService;
            _userManager = userManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
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
        //[AllowAnonymous]
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
            return View(patientDetailsViewModel);
        }

        // GET: RecipeController/Create
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(PatientInfo patientViewModell)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new PatientModel
                    {
                        ID = patientViewModell.ID,
                        Name = patientViewModell.Name,
                        Surname = patientViewModell.Surname,
                        PersonalId = patientViewModell.PersonalId,
                        PhoneNumber = patientViewModell.PhoneNumber,
                        HomeAdress = patientViewModell.HomeAdress,
                        Email = patientViewModell.Email
                    };
                    _patientService.Create(model);
                    return RedirectToAction("Details", new { id = model.ID });
                }
                catch
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
            EditPatientInfo editPatient = new EditPatientInfo
            {
                ID = patient.ID,
                Name = patient.Name,
                Surname = patient.Surname,
                PersonalId = patient.PersonalId,
                PhoneNumber = patient.PhoneNumber,
                HomeAdress = patient.HomeAdress,
                Email = patient.Email
            };
            return View(editPatient);
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPatientInfo editPatient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var patient = _patientService.Get(editPatient.ID);
                    patient.ID = editPatient.ID;
                    patient.Name = editPatient.Name;
                    patient.Surname = editPatient.Surname;
                    patient.PersonalId = editPatient.PersonalId;
                    patient.PhoneNumber = editPatient.PhoneNumber;
                    patient.HomeAdress = editPatient.HomeAdress;
                    patient.Email = editPatient.Email;

                    _patientService.Update(patient);
                    return RedirectToAction("Details", new { id = editPatient.ID });
                }
                catch
                {
                    return View(editPatient);
                }
            }
            else
            {
                return View(editPatient);
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
            return RedirectToAction(nameof(List));
        }
    }
}

