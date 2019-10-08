using Project.SoftwareArchitecture.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Project.SoftwareArchitecture.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SoftwareArchitectureDbContext _context;

        public InitialHostDbBuilder(SoftwareArchitectureDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
