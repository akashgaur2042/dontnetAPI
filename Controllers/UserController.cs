using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Business.IService;
using API.Business.Service;
using API.UserModel;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserService userService;
        public UserController(IUserService _userService)
        {
            this.userService=_userService;
            this.userService.userLogin();
        }
        
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return userService.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            var user = userService.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult login([FromBody] UserDto userDto)
      {
            if (userDto == null)
            {
                return BadRequest();
            }
            User userResp= userService.Find(userDto.username);
            
            if(userResp!=null){
                
                if(userResp.username== userDto.username && userResp.password==userDto.password)
            {    
               
                return Ok(userDto);
            }
             else{
               return Unauthorized();
              }
            }
               return Unauthorized();
            }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
           userService.Remove(id);
            
        }
    }
}