using System;
using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Dto
{
    public class PatientDto
    {
        public int? Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string HomeAddress { get; set; }

        public bool? HighPressure { get; set; }

        public bool? LowPressure { get; set; }

        public bool? HeartDisease { get; set; }

        public bool? Diabetes { get; set; }

        public bool? Allergy { get; set; }

        public bool? OncologycalDisease { get; set; }

        public bool? Hepatitis { get; set; }

        public bool? Epilepsy { get; set; }

        public bool? GastrointestinalDisease { get; set; }

        public bool? Aids { get; set; }

        public string DrugIntolerence { get; set; }

        public bool? Smoking { get; set; }

        public DateTime? DateOfRegistration { get; set; }

        public int? Doctor { get; set; }
    }
}