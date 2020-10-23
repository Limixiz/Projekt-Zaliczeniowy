using System.ComponentModel.DataAnnotations;

namespace Form_App.Models.DataBaseModel
{
    public class Therapy
    {
        public int ID { get; set; }

        [Required]
        public string Review { get; set; }
        
        public string Disorder { get; set; }

        public string RangeOfMotion { get; set; }

        public string VasScale { get; set; }

        public int? Tests { get; set; }

        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string TherapyTecnics { get; set; }

        public string Recommendation { get; set; }

        public string AdisionalInfo { get; set; }
    }
}
