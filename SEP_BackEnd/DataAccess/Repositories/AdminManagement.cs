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

        public Task<UserVM> AddUser(UserVM user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserVM>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            var result = _mapper.Map<List<UserVM>>(users);

            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return users;
        }

        public async Task<User> SearchUserByName(string name)
        {
            //var users = await _context.Users.Where(x => x.FullName == name).ToListAsync();
            //var result = _mapper.Map<List<UserVM>>(users);
            //return result;
            throw new NotImplementedException();
        }
    }
}
