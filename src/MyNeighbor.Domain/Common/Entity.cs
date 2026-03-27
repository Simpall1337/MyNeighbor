using System;
using System.Collections.Generic;
using System.Text;

namespace MyNeighbor.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other) return false;
            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
