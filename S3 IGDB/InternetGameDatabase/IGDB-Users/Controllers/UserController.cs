﻿using System;
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

        public UsersController(IUserRepository repository)
        {
            _userRepository = repository;
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
        public IActionResult Get(int id)
        {
            var user =  _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            UserResponseModel model = ViewModelConverter.UserDTOTOUserResponseModel(user);
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
                _userRepository.Create(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            catch
            {
                return BadRequest("Email or Username already in use");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            IEnumerable<User> userlist = _userRepository.FindByCondition(x => x.Email == model.Email);
            User user = userlist.Single(x => x.Email == model.Email);

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

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _userRepository.FindAll();
            List<UserResponseModel> Users = new List<UserResponseModel>();
            foreach (User user in users)
            {
                Users.Add(ViewModelConverter.UserDTOTOUserResponseModel(user));
            }
            
            return Ok(Users);

            //else
            //{
            //    return Unauthorized();
            //}
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
