using FBS.Service.UserManagement.Api.Models;
using FBS.Service.UserManagement.Api.Processor;
using FBS.Service.UserManagement.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBS.Service.UserManagement.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserProcessor _userProcessor;
        public UserManagementController(IUserProcessor userProcessor)
        {
            _userProcessor = userProcessor;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser([FromBody]UserRegister user)
        {
            var response = _userProcessor.AddUser(user);
            if (response.Model)
            {
                return Ok(response);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody]UserLogin user)
        {
            var token = _userProcessor.Authenticate(user);
            if (token.Model!= null)
            {
                return Ok(token);
            }
            return Ok(token);
        }
    }
}
