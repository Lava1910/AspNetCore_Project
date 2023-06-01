//using AspNetCore_Project.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Net;

//namespace AspNetCore_Project.Controllers
//{
//    [ApiController]
//    [Route("api/phong-ban")]
//    public class PhongBanController : ControllerBase
//    {   
//        private readonly TransportXContext _context;

//        public PhongBanController (TransportXContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public IActionResult Index()
//        {
//            var phongBan = _context.PhongBans.ToList<PhongBan>();
//            return Ok(phongBan);
//        }

//        [HttpGet]
//        [Route("get-by-id")]
//        public IActionResult Get(string maPB)
//        {
//            var phongBan = _context.PhongBans.Find(maPB);
//            if (phongBan == null)
//                return NotFound();
//            return Ok(phongBan);
//        }

//        [HttpPost]
//        public IActionResult Create(PhongBan phongBan)
//        {
//            _context.PhongBans.Add(phongBan);
//            _context.SaveChanges();
//            return Created($"/get-by-id?id={phongBan.MaPb}", phongBan);
//        }

//        [HttpPut]
//        public IActionResult Update(PhongBan phongBan)
//        {
//            _context.PhongBans.Update(phongBan);
//            _context.SaveChanges();
//            return NoContent();
//        }

//        [HttpDelete]
//        public IActionResult Delete(string maPB)
//        {
//            var PBDelete = _context.PhongBans.Find(maPB);
//            if (PBDelete == null)
//                return NotFound();
//            _context.PhongBans.Remove(PBDelete);
//            _context.SaveChanges();
//            return NoContent();
//        }
//    }
//}
