using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePublisherWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    namespace TestController { 
    [Route("api/test")]
    public class TestController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Get()
        {
        var model = new Message { Id = 1, Text = "Message, from Get action" };
            return Ok(model);
        }
    }
    }


