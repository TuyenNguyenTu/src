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
    [AutoMapTo(typeof(Person))]
    public class UpdatePeopleDto : EntityDto<long>
    {
        [Required]
        public long Age { set; get; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }
    }
}
