using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace wizDev2020.Controllers
{
    public class MyPageController : Controller
    {
        public IActionResult Index()
        {
            //ログインしたユーザー名を表示する
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
    }
}
