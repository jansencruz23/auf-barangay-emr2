using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Primitives
{
    public abstract class BaseDomainEntity : IEquatable<BaseDomainEntity>
    {

        public Guid Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedById { get; set; }
        public Guid Version { get; set; }

        public static bool operator == (BaseDomainEntity? first, BaseDomainEntity? second)
        {
            return first != null && second != null && first.Equals(second);
        }

        public static bool operator != (BaseDomainEntity? first, BaseDomainEntity? second)
        {
            return !(first == second);
        }

        public bool Equals(BaseDomainEntity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not BaseDomainEntity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }
    }
}
