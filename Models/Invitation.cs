using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetAssessment.Models
{
    public class Invitation : BaseEntity
    {
        [Required]
        public Developer? Developer { get; set; }

        [Required]
        public Event? Event { get; set; }

        public bool? Accepted { get; set; }
    }
}