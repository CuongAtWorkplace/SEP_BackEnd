﻿using AutoMapper;
using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using DataAccess.DTO;
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

        public async Task<bool> AddUser(AddUserVM addUserVM)
        {
            var addUser = _mapper.Map<User>(addUserVM);
            _context.Users.AddAsync(addUser);
            bool result = true;
            bool saveChange = true;
            if (saveChange)
            {
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> CheckEmailExist(string email)
        {
            try
            {
                // Kiểm tra xem có người dùng nào có email tương ứng không
                var userWithEmail = await _context.Users.AnyAsync(x => x.Email == email);

                return userWithEmail;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi, bạn có thể ném một ngoại lệ hoặc ghi log tùy thuộc vào yêu cầu của bạn
                Console.WriteLine($"Error checking email existence: {ex.Message}");
                return false;
            }
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

        public async Task<List<ReportVM>> GetListReport()
        {
            var allReport = await _context.ReportUsers
                .Include(t => t.FromUserNavigation)
                .ToListAsync();

            var result = allReport.Select(x => new ReportVM()
            {
                ReportUserId = x.ReportUserId,
                FromUser = x.FromUser,
                FromAccountName = (_context.Users.FirstOrDefault(e => e.UserId == x.FromUser)).FullName,
                ToUser = x.ToUser,
                ToAccountName = (_context.Users.FirstOrDefault(e => e.UserId == x.ToUser)).FullName,
                Description = x.Description,
                CreateDate = x.CreateDate.Value.ToString("dd'-'MM'-'yyyy"),
                Reason = x.Reason,
                EvidenceImage = x.EvidenceImage,
                IsChecked = x.IsChecked,
            }).ToList();
            //return Ok(result);
            return result;
        }

        public  async Task<int> GetTotalCourse()
        {
            int count = await _context.Courses.CountAsync();
            return count;
        }

        public async Task<int> GetTotalPost()
        {
            int count = await _context.Posts.CountAsync();
            return count;
        }

        public async Task<int> GetTotalReport()
        {
            int count = await _context.ReportUsers.CountAsync();
            return count;
        }

        public async Task<int> GetTotalUser()
        {
            int count = await _context.Users.CountAsync();
            return count;
        }
        public async Task<UserVM> GetUserById(int Id)
        {
            var users = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserId == Id);
            if (users != null)
            {
                var result = _mapper.Map<UserVM>(users);
                return result;
            }
            else
            {
                return null;
            }
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

        public async Task<List<PaymentHistoryVM>> GetListPayMent()
        {
            var allPayMent = await _context.PaymentHistories
                .Include(t => t.FromUserNavigation)
                .Include(t => t.ToUserNavigation)
                .ToListAsync();

            var result = allPayMent.Select(x => new PaymentHistoryVM()
            {
                Id = x.Id,
                FromUser = x.FromUserNavigation.FullName,
                ToUser= x.ToUserNavigation.FullName,
                TotalMoney = x.TotalMoney,
                CreateDate = x.CreateDate.Value.ToString("dd'-'MM'-'yyyy"),
                Type = x.Type,
            }).ToList();
            //return Ok(result);
            return result;
        }

    }
}
