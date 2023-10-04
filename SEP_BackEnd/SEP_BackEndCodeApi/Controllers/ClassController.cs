using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IUserRepository _user;

        public ClassController(IUserRepository user, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            _user = user;
        }

        [HttpGet]
        public IActionResult ClassList()
        {
            try
            {
                return Ok(_db.Classes.ToList());
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
