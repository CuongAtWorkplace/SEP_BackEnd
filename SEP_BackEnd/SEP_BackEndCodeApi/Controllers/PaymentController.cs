using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        

        public PaymentController( IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
          
        }
        [HttpGet]
        public IActionResult GetAllPayment()
        {
            return Ok(_db.PaymentHistories.ToList());
        }
        [HttpGet]
        public IActionResult GetAllPaymentByUserId(int userId)
        {
            return Ok(_db.PaymentHistories.Where(x=>x.ToUser == userId).ToList());
        }
        [HttpGet]
        public IActionResult GetAllPaymentByType(bool type)
        {
            return Ok(_db.PaymentHistories.Where(x => x.Type.Equals(type)).ToList());
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentHistory paymentHistory )
        {
            try
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == paymentHistory.ToUser);
                _db.PaymentHistories.Add(paymentHistory);
                u.Balance += paymentHistory.TotalMoney;
                _db.Users.Update(u);
                _db.SaveChanges();
                return Ok();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
