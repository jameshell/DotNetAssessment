using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetAssessment.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required, StringLength(300)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public Developer? Developer { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public Address? Address { get; set; }

        [Required]
        public bool? Remote { get; set; }

        public List<Invitation>? Invitations { get; set; }
    }
}