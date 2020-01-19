using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Models
{
    public class Service
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? CostInUSD { get; set; }

        public double? CostInUAH { get; set; }

        public string Description { get; set; }
    }
}
