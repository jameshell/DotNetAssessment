using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetAssessment.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }
    }
}