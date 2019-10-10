using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Project.SoftwareArchitecture.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using Project.SoftwareArchitecture.EntityFramework;

namespace Project.SoftwareArchitecture.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SoftwareArchitecture.EntityFramework.SoftwareArchitectureDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SoftwareArchitecture";
        }

        protected override void Seed(SoftwareArchitecture.EntityFramework.SoftwareArchitectureDbContext context)
        {
            context.DisableAllFilters();
            context.People.AddOrUpdate(
                p => p.Name,
                new Person { Id = 1, Name = "Tự Tuyên", Age = 21 },
                new Person { Id = 2, Name = "Lê Văn Việt", Age = 20 },
                new Person { Id = 3, Name = "John", Age = 22 }
                );
            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
