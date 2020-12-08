using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using wizDev2020.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace wizDev2020.Controllers
{
    public class MemberCreateController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new MemberCreateModel { Conf = true });
        }




        
    }
}
