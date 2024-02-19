using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryManage.DataAccess;
using GroceryManage.models;


namespace GroceryManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public AdminUserController(GroceryDbContext context)
        {
            _context = context;
        }

        //public AdminUserController()
        //{
        //}

        // GET: api/AdminUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminUser>>> GetadminUsers()
        {
            return await _context.adminUsers.ToListAsync();
        }

        // GET: api/AdminUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminUser>> GetAdminUser(int id)
        {
            var adminUser = await _context.adminUsers.FindAsync(id);

            if (adminUser == null)
            {
                return NotFound();
            }

            return adminUser;
        }

        // PUT: api/AdminUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminUser(int id, AdminUser adminUser)
        {
            if (id != adminUser.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ActionResult<AdminUser>> PostAdminUser(AdminUser adminUser)
        {
            _context.adminUsers.Add(adminUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminUser", new { id = adminUser.AdminId }, adminUser);
        }

        //login
        [HttpPost("LoginUser")]
        //[ActionName("PostUserModel")]
        //[Route("api/UserModel/login")]
        public IActionResult Login(Login user)
        {
            try
            {
                var userlist = _context.adminUsers.Where(i => i.AdminMail == user.UserMail && i.Password == user.Password).FirstOrDefault();
                if (userlist == null)
                {
                    return Ok("Failure");
                }

                return Ok("Success");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        // DELETE: api/AdminUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminUser(int id)
        {
            var adminUser = await _context.adminUsers.FindAsync(id);
            if (adminUser == null)
            {
                return NotFound();
            }

            _context.adminUsers.Remove(adminUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminUserExists(int id)
        {
            return _context.adminUsers.Any(e => e.AdminId == id);
        }

        //public  string Logincheck(string v1, string v2)
        //{
        //    var userlist = _context.adminUsers.Where(i => i.AdminMail == v1 && i.Password == v2).FirstOrDefault();
        //    string messages;
        //    if(userlist != null)
        //    {
        //        messages = "Success";
        //        return messages;
        //    }
        //    else
        //    {
        //        messages = "Failure";
        //        return messages;
        //    }
        //}
    }
}
