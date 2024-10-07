using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponApiController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();

                return objList;
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]//expect an integer id
        public object GetId(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(u=>u.CouponId==id);

                return objList;
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
