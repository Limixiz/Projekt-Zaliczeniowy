﻿using System;
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
        public int VasScale { get; set; }
        
        [Display(Name = "Testy")]
        public string Tests { get; set; }

        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string TherapyTecnics { get; set; }

        [Display(Name = "Zalecenia")]
        public string Recommendation { get; set; }

        [Display(Name = "Informacje dodatkowe")]
        public string AdisionalInfo { get; set; }
        
        public int PatientId { get; set; }
    }
}
