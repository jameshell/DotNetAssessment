using System;

namespace dotnetAssessment.core.Models
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}