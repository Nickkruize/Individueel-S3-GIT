using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.ContextModel;
using IGDB_Users.Interface;
using IGDB_Users.ModelConverter;
using IGDB_Users.Models;
using IGDB_Users.Repository;
using IGDB_Users.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IGDB_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGDBContext _context;

        private readonly IUserRepository _userRepository;

        public UsersController(IGDBContext context)
        {
            _userRepository = new UserRepository(context);
        }

        //public UsersController(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        //public UsersController(IUserService userService, IGDBContext context)
        //{
        //    _userService = userService;
        //    _context = context;
        //}

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
        public IActionResult Get(int id)
        {
            var user =  _userRepository.GetById(id);
            UserResponseModel model = ViewModelConverter.UserDTOTOUserResponseModel(user);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(model);
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
                _userRepository.AddUser(user);
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

            var user = _userRepository.GetByEmail(model.Email);
            if (user == null)
            {
                return BadRequest("Incorrect Information");
            }
            else
            {
                if (user.Password == model.Password)
                {
                    UserResponseModel response = ViewModelConverter.UserDTOTOUserResponseModel(user);
                    return Ok(response);
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
            IEnumerable<User> users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}
