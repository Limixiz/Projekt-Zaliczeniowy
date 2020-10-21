using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels
{
    public class PatientListViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Imie")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "PESEL")]
        [StringLength(11)]
        public string PersonalId { get; set; }
    }
}
