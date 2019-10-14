using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Project.SoftwareArchitecture.Authorization.Roles;
using Project.SoftwareArchitecture.Authorization.Users;
using Project.SoftwareArchitecture.MultiTenancy;

namespace Project.SoftwareArchitecture.EntityFramework
{
    public class SoftwareArchitectureDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public virtual IDbSet<Employee> Employees { set; get; }
        public virtual IDbSet<Person> People { set; get; }
        public SoftwareArchitectureDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SoftwareArchitectureDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SoftwareArchitectureDbContext since ABP automatically handles it.
         */
        public SoftwareArchitectureDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SoftwareArchitectureDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public SoftwareArchitectureDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
