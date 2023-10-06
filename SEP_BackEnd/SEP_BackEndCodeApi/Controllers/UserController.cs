using AutoMapper;
using BussinessObject.Models;
using BussinessObject.ResourceModel.ViewModel;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private IConfiguration _config;
        //private readonly DB_SEP490Context _context;
        //private readonly IUserRepository _user;
        //private readonly IMapper _mapper; 
        private readonly IAdminRepository _adminRepository;
        public UserController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("GetListUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var list = await _adminRepository.GetAllUser();
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                var list = await _adminRepository.GetUserById(Id);
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var list = await _adminRepository.SearchUserByName(name);
            return Ok(list);

        }
    }
}
