using AspNetCore_Project.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Project.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly TransportXContext _context;

        public AccountController(TransportXContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var account = _context.Accounts.ToList<Account>();
            return Ok(account);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Created($"/get-by-id?id={account.Id}", account);
        }

        [HttpPut]
        public IActionResult Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var AccountDelete = _context.Accounts.Find(id);
            if (AccountDelete == null)
                return NotFound();
            _context.Accounts.Remove(AccountDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
