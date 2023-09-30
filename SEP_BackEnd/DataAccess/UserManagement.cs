using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    
    public class UserManagement
    {
        private static UserManagement instance = null;
        private static readonly object instanceLock = new object();
        private UserManagement() { }
        public static UserManagement Instance
        {
            get 
            { 
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserManagement();
                    }
                    return instance;    
                }
            }
        }
        public IEnumerable<User> GetUser()
        {
            List<User> userList = new List<User>();
            try
            {
                var db = new DB_SEP490Context();
                userList = db.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userList;
        }
        public User GetUserById(int userId)
        {
            User? rp = null;
            try
            {
                var db = new DB_SEP490Context();
                rp = db.Users.SingleOrDefault(x => x.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }
        public User GetUserByEmail(string email)
        {
            User? rp = null;
            try
            {
                var db = new DB_SEP490Context();
                rp = db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }
    }
}
