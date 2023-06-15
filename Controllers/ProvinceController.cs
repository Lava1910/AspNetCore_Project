using AspNetCore_Project.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Project.Controllers
{
    [ApiController]
    [Route("api/province")]
    public class ProvinceController : ControllerBase
    {
        private readonly TransportXContext _context;
        public ProvinceController(TransportXContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var province = _context.Provinces.ToList<Province>();
            return Ok(province);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int provinceId)
        {
            var province = _context.Provinces.Find(provinceId);
            if (province == null)
                return NotFound();
            return Ok(province);
        }

        [HttpPost]
        public IActionResult Create(Province province)
        {
            _context.Provinces.Add(province);
            _context.SaveChanges();
            return Created($"/get-by-id?id={province.ProvinceId}", province);
        }

        [HttpPut]
        public IActionResult Update(Province province)
        {
            _context.Provinces.Update(province);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int provinceId)
        {
            var PrDelete = _context.Provinces.Find(provinceId);
            if (PrDelete == null)
                return NotFound();
            _context.Provinces.Remove(PrDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
