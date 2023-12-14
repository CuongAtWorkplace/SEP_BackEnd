using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IReporitory
{
    public interface IAdminRepository
    {
        Task<List<UserVM>> GetAllUser();
        Task<UserVM> GetUserById(int Id);
        Task<List<UserVM>> SearchUserByName(string name);
        Task<bool> AddUser(AddUserVM addUserVM);
        Task<User> DeleteUser(int Id);
        Task<List<ReportVM>> GetListReport(); 
        Task<int> GetTotalReport();
        Task<int> GetTotalUser();
        Task<int> GetTotalPost();
        Task<int> GetTotalCourse();
        Task<bool> CheckEmailExist(string email);

    }
}
