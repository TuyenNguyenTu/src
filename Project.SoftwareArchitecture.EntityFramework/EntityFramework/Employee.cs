using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture.EntityFramework
{
    public class Employee : Entity<long>
    {
        public virtual Person AssignedPerson { set; get; }
        public virtual int? AssignedPersonId { set; get; }
        public virtual string Decription { set; get; }
        public virtual DateTime CreatedDate { set; get; }
        public virtual bool Status { set; get; }

        public Employee()
        {
            CreatedDate = DateTime.Now;
            Status = true;
        }
    }
}
