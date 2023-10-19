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
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<ReportUser, ReportVM>().ReverseMap();
        }
        
    }
}
