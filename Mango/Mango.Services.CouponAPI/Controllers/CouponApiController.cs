using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;

        public CouponApiController(AppDbContext db)
        {
            _db = db;
            _response=new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = objList;
         
            }
            catch(Exception ex)
            {
                _response.Message= ex.Message;
                _response.IsSuccessful = false;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]//expect an integer id
        public ResponseDTO GetId(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(u=>u.CouponId==id);
                _response.Result = objList;
            
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccessful = false;
            }

            return _response;
        }
    }
}
