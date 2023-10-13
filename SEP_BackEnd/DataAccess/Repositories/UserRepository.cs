using BussinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories.IReporitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void AddNew(User user)=> UserManagement.Instance.AddNew(user);

        public User GetUserByEmail(string email) => UserManagement.Instance.GetUserByEmail(email);

        public User GetUserById(int userId) => UserManagement.Instance.GetUserById(userId);

        public void Update(User user) => UserManagement.Instance.AddNew(user);

        public IEnumerable<UserDTO> GetUserList(int roleId) => UserManagement.Instance.GetUserList(roleId);

        public IEnumerable<User> GetListUser(int roleId) => UserManagement.Instance.GetListUser(roleId);
    }
}
