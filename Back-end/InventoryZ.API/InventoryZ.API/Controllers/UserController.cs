using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryZ.API.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("example")]
        public IActionResult JustTest()
        {
            return Ok();
        }
    }
}
