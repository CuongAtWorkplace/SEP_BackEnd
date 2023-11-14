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
    public class AdminController : ControllerBase
    {

        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListReport")]
        public async Task<IActionResult> GetListReport()
        {
            try
            {
                var list = await _adminRepository.GetListReport();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                var list = await _adminRepository.SearchUserByName(name);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(AddUserVM addUserVM)
        {
            try
            {
                var result = await _adminRepository.AddUser(addUserVM);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [HttpGet("GetTotal")]
        public async Task<IActionResult> GetTotalDashboard()
        {
            try
            {
                TotalCount data = new TotalCount();
                var countUser = await _adminRepository.GetTotalUser();
                data.TotalUser = countUser;

                var countPost = await _adminRepository.GetTotalPost();
                data.TotalPost = countPost;

                var countCourse = await _adminRepository.GetTotalCourse();
                data.Totalcourse = countCourse;

                var countReport = await _adminRepository.GetTotalReport();
                data.TotalReport = countReport;

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
