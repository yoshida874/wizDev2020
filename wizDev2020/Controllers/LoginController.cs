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
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginModel { Conf = true});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string UserName, string PW, string returnUrl = null)
        {
            var loginModel = new LoginModel { Conf = false };

            // 必須入力がないなどの場合ログインさせない。（ログインページに戻る）
            if (!ModelState.IsValid) return View(loginModel);

            // ==================================================
            // ダミーの認証処理

            bool isValid = UserName == "hoge" && PW == "hoge" ? true : false;

            // ===================================================

            // 入力内容が異なっている場合ログインさせない。
            if (!isValid) return View(loginModel);
            Claim[] claims = {
                new Claim(ClaimTypes.Name, UserName), // ユニークID
                new Claim(ClaimTypes.Name, PW),
            };

            // 一意の ID 情報
            var claimsIdentity = new ClaimsIdentity(
              claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // ログイン
            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity)
              );

            // ログインが必要なアクションにリダイレクト
            return RedirectToAction("Index", "Home");

        }
    }
}
