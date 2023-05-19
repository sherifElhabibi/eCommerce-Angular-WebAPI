using eCommerce.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(50);
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("ServerError")]
        public IActionResult GetServerError()
        {
            var thing = _context.Products.Find(50);
            var thingReturn = thing.ToString();
            return Ok(thingReturn);
        }
        [HttpGet("BadRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("BadRequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
