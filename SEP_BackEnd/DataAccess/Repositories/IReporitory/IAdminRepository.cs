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
        Task<User> GetUserById(int Id);
        Task<List<UserVM>> SearchUserByName(string name);
        Task<UserVM> AddUser(UserVM user);
        Task<User> DeleteUser(int Id);
    }
}
