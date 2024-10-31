﻿using Microsoft.AspNetCore.Mvc;

namespace PVS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        public IActionResult LoginCallback()
        {
            Console.WriteLine("Вошел");
            return Ok("Вошел");
        }
    }
}
