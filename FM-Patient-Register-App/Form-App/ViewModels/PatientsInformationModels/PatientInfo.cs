using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form_App.ViewModels.PatientsInformationModels
{
    public class PatientInfo
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

        [Required]
        [Display(Name = "Telefon Kontaktowy")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Adres Zamieszkania")]
        public string HomeAdress { get; set; }

        [Required(ErrorMessage = "E-mail wymagany!")]
        [EmailAddress(ErrorMessage = "Niepoprawny E-mail.")]
        public string Email { get; set; }
    }
}
