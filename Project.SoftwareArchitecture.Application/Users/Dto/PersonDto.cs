using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Project.SoftwareArchitecture.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture.Users.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto : EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string Name { get; set; }

        [Required]
        public long Age { set; get; }
    }
}
