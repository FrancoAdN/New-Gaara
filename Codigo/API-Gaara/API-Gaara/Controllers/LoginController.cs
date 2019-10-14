using API_Gaara.Models;
using API_Gaara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Gaara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public bool Get(string email, string pwd)
        {

            var user = _userService.Get(email, pwd);

            if (user == null)
            {
                return false;
            }

            return true;
        }

    }
}