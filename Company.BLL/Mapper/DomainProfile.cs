using AutoMapper;
using Company.BLL.ModelVM;
using Company.DAL.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Mapper
{
    public class DomainProfile : Profile 
    {
        public DomainProfile() {
            CreateMap<Employee, CreateEmployeeVM>()
                    .ForMember(dist => dist.DepartmentId, opt => opt.MapFrom(s => s.DepartmentId));
            CreateMap<CreateEmployeeVM, Employee>();

            CreateMap<Employee, IndexEmployeeVM>()
                    .ForMember(dist => dist.DepartmentName, opt => opt.MapFrom(s => s.Department.Name));
            CreateMap<IndexEmployeeVM, Employee>();

            CreateMap<Employee, DeleteEmployeeVM>()
                   .ForMember(dist => dist.DepartmentName, opt => opt.MapFrom(s => s.Department.Name));
            CreateMap<DeleteEmployeeVM, Employee>();

            CreateMap<Employee, EditEmployeeVM>()
            .ForMember(dest => dest.ExistingImageUrl, opt => opt.MapFrom(src => src.ImageURL));

            CreateMap<EditEmployeeVM, Employee>()
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore()); // We handle image URL manually
        }


    }
}
