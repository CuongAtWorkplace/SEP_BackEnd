using AutoMapper;
using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using DataAccess.Repositories.IReporitory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AdminManagement : IAdminRepository
    {
        private readonly DB_SEP490Context _context;
        private readonly IMapper _mapper;

        public AdminManagement(DB_SEP490Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(UserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _context.Users.Add(user);
            bool result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public Task<User> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserVM>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            var result = _mapper.Map<List<UserVM>>(users);

            return result;
        }

        public async Task<User> GetUserById(int Id)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.UserId == Id);
            return users;
        }

        public async Task<List<UserVM>> SearchUserByName(string name)
        {
            List<User> users = new List<User>();
            if (!String.IsNullOrEmpty(name))
            {
                users = await _context.Users.Where(x => x.FullName.Contains(name)).ToListAsync();
            }
            var list = _mapper.Map<List<UserVM>>(users);
            return list;
        }


    }
}
