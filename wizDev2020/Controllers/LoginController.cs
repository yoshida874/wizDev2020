using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Linq ;
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
    public class LoginController : Controller
    {
        private readonly Wizdev2020Context _context;

        public LoginController(Wizdev2020Context context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            using (_context)
            {
                /*var sample = _context.Users.FirstOrDefault(x => x.Id == 1);
                Console.WriteLine(sample.Id);*/
                var user = from u in _context.Users
                           select u;
            }
            ViewBag.Conf = true;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string user_name, string user_password, string returnUrl = null)
        {
            ViewBag.Conf = false;

            // 必須入力がないなどの場合ログインさせない。（ログインページに戻る）
            if (!ModelState.IsValid) return View();

            bool isValid = false;
            // ==================================================

            // ダミーの認証処理
            // ===================================================
            
            using (_context)
            {
                var user = from u in _context.Users
                           select u;
                        
                foreach (var item in user)
                {
                    if (item.user_name == user_name && item.user_password == user_password)
                    {
                        isValid = true;
                    }
                }
                //isValid = user.user_name == UserName && user.user_password == PW;
                //Console.WriteLine(sample.Id);
            }
            // 入力内容が異なっている場合ログインさせない。
            if (!isValid) return View();
            Claim[] claims = {
                new Claim(ClaimTypes.Name, user_name), // ユニークID
                new Claim(ClaimTypes.Name, user_password),
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
