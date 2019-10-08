using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Project.SoftwareArchitecture.EntityFramework;

namespace Project.SoftwareArchitecture.Migrator
{
    [DependsOn(typeof(SoftwareArchitectureDataModule))]
    public class SoftwareArchitectureMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SoftwareArchitectureDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}