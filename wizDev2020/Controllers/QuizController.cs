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

        public IActionResult Index()
        {
            data = _context.Quizzes.OrderBy(q => Guid.NewGuid()).ToArray();
            return View(_context.Quizzes);
        }

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