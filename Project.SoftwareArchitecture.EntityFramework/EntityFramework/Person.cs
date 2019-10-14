using Abp.Domain.Entities;

namespace Project.SoftwareArchitecture.EntityFramework
{
    public class Person : Entity
    {
        public virtual string Name { set; get; }
        public virtual long Age { set; get; }
    }
}
