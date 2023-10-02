using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.IReporitory
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUserById(int userId);
        User GetUserByEmail(string email);
         void Update(User user);
        void AddNew(User user);

    }
}
