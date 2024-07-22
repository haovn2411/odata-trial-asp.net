using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Entity;

namespace ODataBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PressesController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public PressesController(BookStoreContext context)
        {
            _context = context;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Presss.ToList());
        }
    }
}
