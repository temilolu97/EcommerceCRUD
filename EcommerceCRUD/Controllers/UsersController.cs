using AutoMapper;
using EcommerceCRUD.Attributes;
using EcommerceCRUD.Contexts;
using EcommerceCRUD.DTOs;
using EcommerceCRUD.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EcommerceCRUD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private  IUserService _userService;
        private IMapper _mapper;
        private readonly Settings _settings;

        public UsersController(IUserService userService, IMapper mapper, IOptions<Settings> settings)
        {
            _userService = userService;
            _mapper = mapper;
            _settings = settings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var response = _userService.Login(request);
            return Ok(response); 
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            _userService.Register(request);
            return Ok(new { message = "Registration successful" });

        }
    }
}
