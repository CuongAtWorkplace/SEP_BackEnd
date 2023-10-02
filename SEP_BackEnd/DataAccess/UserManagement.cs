using BussinessObject.Models;

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
                lock (instanceLock)
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
            User? rp ;
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
        public void Update(User user)
        {
            try
            {
                User rp = GetUserById(user.UserId);
                if (rp != null)
                {
                    var db = new DB_SEP490Context();
                    User u = new User
                    {
                        UserId = user.UserId,
                        FullName = user.FullName,
                        Address = user.Address,
                        Email = user.Email,
                        Password = user.Password,
                        Phone = user.Phone,
                        RoleId = 1,
                        IsBan = false,
                        Image = user.Image,
                    };
                    db.Entry<User>(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This user does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddNew(User user)
        {
            try
            {
                User rp = GetUserByEmail(user.Email);
                if (rp == null)
                {
                    var db = new DB_SEP490Context();
                    User u = new User
                    {
                        FullName = user.FullName,
                        Address = user.Address,
                        Email = user.Email,
                        Password = user.Password,
                        Phone = user.Phone,
                        RoleId = 1,
                        IsBan = false,
                        Image = null,
                    };
                    db.Users.Add(u);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
