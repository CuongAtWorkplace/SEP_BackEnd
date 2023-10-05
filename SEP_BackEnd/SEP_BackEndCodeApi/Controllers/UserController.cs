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
        private IConfiguration _config;
        private readonly DB_SEP490Context _context;
        private readonly IUserRepository _user;
        private readonly IMapper _mapper; 
        public UserController(IUserRepository user, IConfiguration config, DB_SEP490Context db, IMapper mapper)
        {
            _config = config;
            _context = db;
            _user = user;
            _mapper = mapper;
        }

        [HttpGet("GetListUser")]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                List<User> users = await _context.Users.ToListAsync();
                var list = _mapper.Map<List<UserVM>>(users);
                return Ok(list);
                //var list = _user.GetUser();
                //return Ok(list);
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
                User users = await _context.Users.FirstOrDefaultAsync(x => x.UserId == Id);
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
