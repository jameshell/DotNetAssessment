using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetAssessment.Models
{
    public class Developer : BaseEntity
    {
        [Required, StringLength(255)]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? City { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }
}