using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Business.IService;
using API.Business.Service;
using API.UserModel;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IUserService lg {get; set;}
        public UserController(IUserService _lg)
        {
            lg=_lg;
        }
        
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return lg.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            var user = lg.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }


        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            lg.add(user);
            return CreatedAtRoute("GetUser", new { Controller = "user", id = user.username }, user);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            lg.Remove(id);
        }


        [HttpGet ("testing")]
        public string Demo()
        {
            return lg.test();
        }
    }
}