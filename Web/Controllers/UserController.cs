using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entity;
using System.Security.Claims;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listOfuser = await _userService.GetAllAsync();
            var listOfUserModel = _mapper.Map<List<UserModel>>(listOfuser);
            return Ok(listOfUserModel);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserModel userModel)
        {
            if (userModel != null)
            {
                await _userService.CreateAsync(_mapper.Map<User>(userModel));
            }
            return Ok("Success");
        }

        [HttpGet("GetProfile")]
        [Authorize(Roles = "user,admin")]
        public async Task<User> GetProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var id = identity.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

                return await _userService.GetByIdAsync(int.Parse(id));
            }

            return null;
        }

        [HttpDelete("Delete")]
        [Authorize(Roles ="user,admin")]
        public async Task Delete()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = identity.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

                 await _userService.Delete(int.Parse(id));
            }
        }

        [HttpPut("Update")]
        [Authorize(Roles = "user,Admin")]
        public async Task Update(UserModel userModel)
        {
            if (userModel != null)
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var id = identity.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

                     await _userService.Update(_mapper.Map<User>(userModel), int.Parse(id));
                }
               
            }
        }
    }
}

