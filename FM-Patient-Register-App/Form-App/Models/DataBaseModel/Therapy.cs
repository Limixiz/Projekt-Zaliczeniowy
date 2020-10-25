using System;
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

        public int VasScale { get; set; }

        public string Tests { get; set; }

        [Required(ErrorMessage = "Ta rubryka jest wymagana!")]
        [Display(Name = "Zastosowana Terapia")]
        public string TherapyTecnics { get; set; }

        public string Recommendation { get; set; }

        public string AdisionalInfo { get; set; }

        public DateTime CreationDate { get; set; }

        public int PatientID { get; set; }

        public Patient Patient { get; set; }
    }
}
