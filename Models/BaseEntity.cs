using System;

namespace dotnetAssessment.Models
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}