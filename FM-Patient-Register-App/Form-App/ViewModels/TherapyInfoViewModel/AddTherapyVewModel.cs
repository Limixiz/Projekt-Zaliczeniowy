using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels.TherapyInfoViewModel
{
    public class AddTherapyVewModel
    {
        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Wywiad")]
        public string Review { get; set; }
#nullable enable        
        [Display(Name = "Dolegliwości")]
        public string? Disorder { get; set; }
        
        [Display(Name = "Ruchomość")]
        public string? RangeOfMotion { get; set; }
        
        [Display(Name = "Skala Vas")]
        public string? VasScale { get; set; }
        
        [Display(Name = "Testy")]
        public int Tests { get; set; }
#nullable disable
        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string Therapy { get; set; }
#nullable enable

        [Display(Name = "Zalecenia")]
        public string? Recommendation { get; set; }
        [Display(Name = "Informacje dodatkowe")]
        public string? AdisionalInfo { get; set; }
#nullable disable
    }
}
