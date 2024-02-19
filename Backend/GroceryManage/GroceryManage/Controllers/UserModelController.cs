using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryManage.DataAccess;
using GroceryManage.models;
using GroceryManage.services;

namespace GroceryManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserModelController : ControllerBase
    {
        private readonly GroceryDbContext _context;
       // IUserService _userService;

        public UserModelController(GroceryDbContext context)
        {
            _context = context;
            //_userService = service;
        }
        //login
        [HttpPost("LoginUser")]
        //[ActionName("PostUserModel")]
        //[Route("api/UserModel/login")]
        public IActionResult Login(Login user)
        {
            try
            {
                //here userModel is the table name declared at dbcontext class
                var userlist = _context.userModel.Where(i => i.UserMail == user.UserMail && i.Password == user.Password).FirstOrDefault();
                if (userlist == null)
                {
                    return Ok("Failure");
                }
                //var claims = new List<Claim> { new Claim(type: ClaimTypes.Name, value: username), new Claim(type: ClaimTypes.Role, value: userlist.Design) };
                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return Ok("Success");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        // GET: api/UserModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetuserModel()
        {
            return await _context.userModel.ToListAsync();
        }

        // GET: api/UserModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(int id)
        {
            var userModel = await _context.userModel.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/UserModel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, UserModel userModel)
        {
            if (id != userModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/UserModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [Route ("api/UserModel/register")]
        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> PostUserModel(UserModel userModel)
        {
            _context.userModel.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.UserId }, userModel);
        }

        // DELETE: api/UserModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel(int id)
        {
            var userModel = await _context.userModel.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.userModel.Remove(userModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModelExists(int id)
        {
            return _context.userModel.Any(e => e.UserId == id);
        }
    }
}
