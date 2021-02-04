using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using wizDev2020.Models;
using wizDev2020.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace wizDev2020.Controllers
{
    public class MemberCreateController : Controller
    {
        private readonly Wizdev2020Context _context;

        public MemberCreateController(Wizdev2020Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Conf = true;
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(string username, string userpw, string userpw_2)
        {
            //userpwとuserpw_2が一致しないとログインしない
            ViewBag.Conf = false;
            if (!ModelState.IsValid) return View();

            bool isValid = false;
            
            if (userpw == userpw_2)
            {
                isValid = true;
            }

            //新規登録内容をDBに格納する
            _context.Users.Add(new UserModel
            {
                user_name=username,
                user_password=userpw,
                character_id=1,
            });

            _context.SaveChanges();

                UserModel usermodel = new UserModel();
            usermodel.user_name = username;
            usermodel.user_password = userpw;
            usermodel.character_id = 1;
            if (!isValid) return View();
            Claim[] claims = {
                new Claim(ClaimTypes.Name, username), // ユニークID
                new Claim(ClaimTypes.Name, userpw),
            };

            // 一意の ID 情報
            var claimsIdentity = new ClaimsIdentity(
              claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // ログイン
            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity)
              );
            ViewBag.Conf = true;
            // ログインが必要なアクションにリダイレクト
            return RedirectToAction("Index", "Home");

        }

    }
}
