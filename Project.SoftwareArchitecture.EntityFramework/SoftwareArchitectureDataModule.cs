using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Project.SoftwareArchitecture.EntityFramework;

namespace Project.SoftwareArchitecture
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SoftwareArchitectureCoreModule))]
    public class SoftwareArchitectureDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SoftwareArchitectureDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
