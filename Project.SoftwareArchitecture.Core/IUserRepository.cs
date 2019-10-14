using Abp.Domain.Repositories;
using Project.SoftwareArchitecture.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture
{
    public interface  IUserRepository : IRepository<User,long>
    {
        //định nghĩa GetUserAccount method trong đây
        Task<List<string>> GetUserAccount();
    }
}
