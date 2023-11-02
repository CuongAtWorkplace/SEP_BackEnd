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
                .ForMember(dest => dest.FromAccountName, otp => otp.MapFrom(src => src.FromUserNavigation.FullName))
                .ForMember(dest => dest.ToAccountName, otp => otp.MapFrom(src => src.FromUserNavigation.FullName))
                .ForMember(dest => dest.CreateDate, otp => otp.MapFrom(src => src.CreateDate.Value.ToString("dd'-'MM'-'yyyy")))
                .ReverseMap();
         
        }
        
    }
}
