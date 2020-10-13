using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_App.Models.DataBaseModel;
using Form_App.ViewModels.PatientsInformationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Form_App.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class PatientController : Controller
    {  
            [HttpGet]
            [AllowAnonymous]
            public IActionResult Index()
            {
            return View();
            }

            [HttpGet]
            [AllowAnonymous]
            public IActionResult Details(int id)
            {
                var patient = _recipeService.Get(id);
                DetailsPatienInfoViewModel patientDetailsViewModel = new DetailsPatienInfoViewModel
                {
                    ID = recipe.ID,
                    Description = recipe.Description,
                    Ingredients = recipe.Ingredients,
                    Name = recipe.Name,
                    Preparation = recipe.Preparation,
                    PreparationTime = recipe.PreparationTime,
                    PhotoPath = recipe.PhotoPath
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
            [ValidateAntiForgeryToken]
            public IActionResult Add(PatientInfo patientViewModell)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var model = new PatientModel
                        {
                            
                        };
                        _recipeService.Create(model);
                        return RedirectToAction("Details", new { id = model.ID });
                    }
                    catch
                    {
                        return View(recipeCreateViewModel);
                    }
                }
                else
                {
                    return View(recipeCreateViewModel);
                }
            }

            // GET: RecipeController/Edit/5
            [HttpGet]
            public IActionResult Edit(int id)
            {

                var itemRecipe = _recipeService.Get(id);
                RecipeEditViewModel recipeEditViewModel = new RecipeEditViewModel
                {
                    ID = itemRecipe.ID,
                    Description = itemRecipe.Description,
                    Ingredients = itemRecipe.Ingredients,
                    Name = itemRecipe.Name,
                    Preparation = itemRecipe.Preparation,
                    PreparationTime = itemRecipe.PreparationTime,
                    ExistingPhotoPath = itemRecipe.PhotoPath
                };
                return View(recipeEditViewModel);
            }

            // POST: RecipeController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, RecipeEditViewModel recipeEditViewModel)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var recipeModel = _recipeService.Get(recipeEditViewModel.ID);
                        recipeModel.ID = recipeEditViewModel.ID;
                        recipeModel.Description = recipeEditViewModel.Description;
                        recipeModel.Ingredients = recipeEditViewModel.Ingredients;
                        recipeModel.Name = recipeEditViewModel.Name;
                        recipeModel.Preparation = recipeEditViewModel.Preparation;
                        recipeModel.PreparationTime = recipeEditViewModel.PreparationTime;
                        if (recipeEditViewModel.Photo != null)
                        {
                            if (recipeEditViewModel.ExistingPhotoPath != null)
                            {
                                string fileToDeletePath = Path.Combine(_hostingEnvironment.WebRootPath, "images",
                                    recipeEditViewModel.ExistingPhotoPath);
                                System.IO.File.Delete(fileToDeletePath);
                            }

                            string uniqueFileName = null;
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + recipeEditViewModel.Photo.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                recipeEditViewModel.Photo.CopyTo(fileStream);
                            }

                            recipeModel.PhotoPath = uniqueFileName;
                        }

                        _recipeService.Update(recipeModel);
                        return RedirectToAction("Details", new { id = recipeEditViewModel.ID });
                    }
                    catch
                    {
                        return View(recipeEditViewModel);
                    }
                }
                else
                {
                    return View(recipeEditViewModel);
                }
            }

            // GET: RecipeController/Delete/5
            [HttpGet]
            public IActionResult Remove(int id)
            {
                var isOkToDelete = _recipeService.CheckBeforeDelete(id);
                var deleteRecipe = _recipeService.Get(id);
                RecipeDeleteViewModel recipeDeleteViewModel = new RecipeDeleteViewModel
                {
                    ID = deleteRecipe.ID,
                    Name = deleteRecipe.Name,
                    Description = deleteRecipe.Description,
                    IsOkToDelete = isOkToDelete
                };
                if (isOkToDelete == true)
                {
                    ViewBag.CheckMsg = "Można bezpiecznie usunąć przepis.";
                }
                else
                {
                    ViewBag.CheckMsg = "Nie można usunąć przepisu, ponieważ jest wykorzystywany już w planie żywieniowym!";
                }
                return View(recipeDeleteViewModel);
            }

            // POST: RecipeController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult ConfirmRemove(int id)
            {
                _recipeService.Delete(id);
                return RedirectToAction(nameof(List));
            }
        }
    }
}
