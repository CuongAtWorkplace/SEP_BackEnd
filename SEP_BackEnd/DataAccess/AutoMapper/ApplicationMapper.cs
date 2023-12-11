using AutoMapper;
using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<User, UserVM>()
                .ForMember(x => x.Status, otp => otp.MapFrom(x => x.IsBan ?? true ? "Ban" : "Active"))
                .ForMember(x => x.RoleName, otp => otp.MapFrom(src => src.Role.RoleName))
                .ForMember(x => x.CreateDate, otp => otp.MapFrom(src => src.CreateDate.Value.ToString("dd'-'MM'-'yyyy")))
                .ReverseMap();
            CreateMap<ReportUser, ReportVM>()
                .ForMember(dest => dest.FromAccountName, otp => otp.MapFrom(src => src.FromUserNavigation.FullName))
                .ForMember(dest => dest.ToAccountName, otp => otp.MapFrom(src => src.FromUserNavigation.FullName))
                .ForMember(dest => dest.CreateDate, otp => otp.MapFrom(src => src.CreateDate.Value.ToString("dd'-'MM'-'yyyy")))
                .ReverseMap();
            CreateMap<AddUserVM, User>()
                //.ForMember(dest => dest.RoleId, opt => opt.MapFrom(x => x.RoleName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(x => ConvertRoleNameToRoleId(x.RoleName)))
                .ForMember(dest => dest.IsBan, opt => opt.MapFrom(x => false))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();
            //CreateMap<UserVM, Role>()
            //    .ForMember(x => x.RoleName, otp => otp.MapFrom(src => src.RoleName));
        }

        private int ConvertRoleNameToRoleId(string roleName)
        {

            var roleMapping = new Dictionary<string, int>
            {
                { "Teacher", 1 },
                { "Manager", 3 },
            };

            return roleMapping.TryGetValue(roleName, out var roleId) ? roleId : 0;
        }

    }
}
