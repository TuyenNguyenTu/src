using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture.EntityFramework
{
   public class Person : Entity
    {
        public virtual string Name { set; get; }
        public virtual long Age { set; get; }
    }
}
