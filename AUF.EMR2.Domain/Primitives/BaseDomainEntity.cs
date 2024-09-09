using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Domain.Primitives
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedById { get; set; }
        public Guid Version { get; set; }
    }
}
