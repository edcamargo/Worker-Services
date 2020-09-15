using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace demok.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        //[NotMapped]
        //public ValidationResult ValidationResult { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
