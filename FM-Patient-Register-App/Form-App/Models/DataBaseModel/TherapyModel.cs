using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.Models.DataBaseModel
{
    public class TherapyModel
    {
        public int ID { get; set; }
        [Required]
        public string Review { get; set; }
#nullable enable                
        public string? Disorder { get; set; }
        public string? RangeOfMotion { get; set; }        
        public string? VasScale { get; set; }        
        public int? Tests { get; set; }
#nullable disable
        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string Therapy { get; set; }
#nullable enable        
        public string? Recommendation { get; set; }        
        public string? AdisionalInfo { get; set; }
#nullable disable
    }
}
