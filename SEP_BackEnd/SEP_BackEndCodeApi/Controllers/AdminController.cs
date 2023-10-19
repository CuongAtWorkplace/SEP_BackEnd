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
        public async Task<IActionResult> AddNewUser(UserVM userVM)
        {
            try
            {
                var result = await _adminRepository.AddUser(userVM);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
    }
}
