using AspNetCore_Project.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Project.Controllers
{
    [ApiController]
    [Route("api/buu-cuc")]
    public class BuuCucController : ControllerBase
    {
        private readonly TransportXContext _context;
        public BuuCucController(TransportXContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var buuCuc = _context.BuuCucs.ToList<BuuCuc>();
            return Ok(buuCuc);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(string maBC)
        {
            var buuCuc = _context.BuuCucs.Find(maBC);
            if (buuCuc == null)
                return NotFound();
            return Ok(buuCuc);
        }

        [HttpPost]
        public IActionResult Create(BuuCuc buuCuc)
        {
            _context.BuuCucs.Add(buuCuc);
            _context.SaveChanges();
            return Created($"/get-by-id?id={buuCuc.MaBc}", buuCuc);
        }

        [HttpPut]
        public IActionResult Update(BuuCuc buuCuc)
        {
            _context.BuuCucs.Update(buuCuc);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string maBC)
        {
            var BCDelete = _context.BuuCucs.Find(maBC);
            if (BCDelete == null)
                return NotFound();
            _context.BuuCucs.Remove(BCDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
