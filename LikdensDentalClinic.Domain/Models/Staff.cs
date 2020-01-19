using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Models
{
    public class Staff
    {
        public int? Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Patient> Patients { get; set; }
    }
}