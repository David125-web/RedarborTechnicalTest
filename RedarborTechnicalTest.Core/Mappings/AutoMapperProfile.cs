using AutoMapper;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Entities;
using RedarborTechnicalTest.Core.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedarborTechnicalTest.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>().ReverseMap()
                .ForMember(des => des.Id, opt => opt.MapFrom(x=>x.Id))
                .ForMember(des => des.CompanyId, opt => opt.MapFrom(x => x.CompanyId))
                .ForMember(des => des.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn))
                .ForMember(des => des.DeletedOn, opt => opt.MapFrom(x => x.DeletedOn))
                .ForMember(des => des.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(des => des.Fax, opt => opt.MapFrom(x => x.Fax))
                .ForMember(des => des.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(des => des.Lastlogin, opt => opt.MapFrom(x => x.Lastlogin))
                .ForMember(des => des.Password, opt => opt.MapFrom(x => x.Password))
                .ForMember(des => des.PortalId, opt => opt.MapFrom(x => x.PortalId))
                .ForMember(des => des.RoleId, opt => opt.MapFrom(x => x.RoleId))
                .ForMember(des => des.StatusId, opt => opt.MapFrom(x => x.StatusId))
                .ForMember(des => des.Telephone, opt => opt.MapFrom(x => x.Telephone))
                .ForMember(des => des.UpdatedOn, opt => opt.MapFrom(x => x.UpdatedOn))
                .ForMember(des => des.Username, opt => opt.MapFrom(x => x.Username));

            CreateMap<EmployeeEntity, CreateEmployeeCommand>().ReverseMap();

        }
    }
}
