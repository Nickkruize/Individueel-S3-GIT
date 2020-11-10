using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.ContextModel;
using IGDB_Users.ModelConverter;
using IGDB_Users.Models;
using IGDB_Users.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;

namespace IGDB_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly InventoryContext _context;

        public UsersController(IUserService userService, InventoryContext context)
        {
            _userService = userService;
            _context = context;
        }

        //[HttpPost("authenticate")]
        //public IActionResult Authenticate(AuthenticateRequest model)
        //{
        //    var response = _userService.Authenticate(model);

        //    if (response == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(response);
        //}

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrationModel model)
        {
            if (model.Password != model.Password_confirmation)
            {
                return BadRequest();
            }


            var user = ViewModelConverter.RegistrationModelToUser(model);
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                //user.Id = user.Id;
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest("Email or Username already in use");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {

            var user = _context.Users.Where(e => e.Email == model.Email).SingleOrDefault();
            if (user == null)
            {
                return BadRequest("Incorrect Information");
            }
            else
            {
                if (user.Password == model.Password)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Incorrect information");
                }
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllUsers()
        {
            List<User> users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
