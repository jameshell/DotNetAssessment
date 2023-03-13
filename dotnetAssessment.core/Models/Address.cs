using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetAssessment.core.Models
{
    public class Address : BaseEntity
    {
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