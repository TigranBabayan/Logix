using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entity;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listOfuser = await _userService.GetAllAsync();
            var listOfUserModel = _mapper.Map<List<UserModel>>(listOfuser);
            return View(listOfUserModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            if(userModel != null) 
            {
                await _userService.CreateAsync(_mapper.Map<User>(userModel));
            }
            return RedirectToAction("Index");
        }
    }
}
