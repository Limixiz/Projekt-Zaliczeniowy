using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels
{
    public class TherapyListViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Review { get; set; }

        public string Disorder { get; set; }

        public string RangeOfMotion { get; set; }

        public int VasScale { get; set; }

        public string Tests { get; set; }

        [Required]
        public string TherapyTecnics { get; set; }

        public string Recommendation { get; set; }

        public string AdisionalInfo { get; set; }
    }
}
