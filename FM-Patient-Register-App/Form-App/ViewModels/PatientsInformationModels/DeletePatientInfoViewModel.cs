using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels.PatientsInformationModels
{
    public class DeletePatientInfoViewModel
    {
        public int ID { get; set; }       
        [Display(Name = "Imie")]
        public string Name { get; set; }     
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }        
        [Display(Name = "PESEL")]
        public string PersonalId { get; set; }
        public bool IsOkToDelete { get; set; }
    }
}
