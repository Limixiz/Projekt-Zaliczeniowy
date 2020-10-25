using Form_App.Models.DataBaseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels.TherapyInfoViewModel
{
    public class AddTherapyVewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Wywiad")]
        public string Review { get; set; }
              
        [Display(Name = "Dolegliwości")]
        public string Disorder { get; set; }
        
        [Display(Name = "Ruchomość")]
        public string RangeOfMotion { get; set; }
        
        [Display(Name = "Skala Vas")]
        [Range(0, 10, ErrorMessage = "Skala nie może przekroczyć wartości 0/10!")]
        public int VasScale { get; set; }
        
        [Display(Name = "Testy")]
        public string Tests { get; set; }

        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string TherapyTecnics { get; set; }

        [Display(Name = "Zalecenia")]
        public string Recommendation { get; set; }

        [Display(Name = "Informacje dodatkowe")]
        public string AdditionalInfo { get; set; }
        
        [Required(ErrorMessage = "Należy wybrać pacjenta")]
        public int PatientId { get; set; }

        public List<SelectListItem> Patients { get; set; }
    }
}
