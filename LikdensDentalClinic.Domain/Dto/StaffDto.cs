using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Dto
{
    public class StaffDto
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
    }
}
