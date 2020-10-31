using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Form_App.Models.DataBaseModel
{
    public class Patient
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

        public int ApplicationUserID { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IList<Therapy> Therapies { get; set; }
    }
}
