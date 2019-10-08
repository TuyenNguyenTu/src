using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Project.SoftwareArchitecture.EntityFramework.Repositories
{
    public abstract class SoftwareArchitectureRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SoftwareArchitectureDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SoftwareArchitectureRepositoryBase(IDbContextProvider<SoftwareArchitectureDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SoftwareArchitectureRepositoryBase<TEntity> : SoftwareArchitectureRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SoftwareArchitectureRepositoryBase(IDbContextProvider<SoftwareArchitectureDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
