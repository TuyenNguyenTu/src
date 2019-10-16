using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.SoftwareArchitecture.Roles.Dto;
using Project.SoftwareArchitecture.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture
{
    public interface IPersonAppService : IAsyncCrudAppService<PersonDto,long, PagedResultRequestDto,CreatePersonDto,UpdatePeopleDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
