using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.Models.DataBaseModel
{
    public class PatientModel
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        public string PersonalId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string HomeAdress { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
