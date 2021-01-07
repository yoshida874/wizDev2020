using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wizDev2020.Data;
using wizDev2020.Models;

namespace wizDev2020.Controllers
{
    public class QuizController : Controller
    {
        private readonly Wizdev2020Context _context;
        private static QuizModel[] data;

        public QuizController(Wizdev2020Context context) => _context = context;

        //[HttpGet]
        public IActionResult Index()
        {
            //QuizModel model = _context.Quizzes.Single(v => v.Id == 1);
            ////QuizModel model = new QuizModel();
            //_context.Quizzes.Count();
            data = _context.Quizzes.OrderBy(q => Guid.NewGuid()).ToArray();
            return View(_context.Quizzes);
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(int id)
        //{
        //    bool isFailed;

        //    QuizModel model = _context.Quizzes.Single(v => v.Id == 1);
        //    return RedirectToAction("Index", this);
        //    data = _context.Quizzes.OrderBy(q => Guid.NewGuid()).ToArray();
        //    return View(data.Length);
        //}

        public IActionResult Question(int id)
        {
            if (_context.Quizzes.Count() < id)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View(data[id - 1]);
            }
        }

        public IActionResult Result() => View();
    }
}