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
                .ForMember(x => x.Status, otp => otp.MapFrom(x => x.IsBan ?? true ? "Ban" : "Active"));
            CreateMap<ReportUser, ReportVM>()
                .ForMember(dest => dest.FromAccount, otp => otp.MapFrom(src => src.FromUserNavigation.UserId))
                .ForMember(dest => dest.ToAccount, otp => otp.MapFrom(src => src.FromUserNavigation.UserId));
        }
        
    }
}
