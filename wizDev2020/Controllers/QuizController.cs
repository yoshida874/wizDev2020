using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using wizDev2020.Data;
using wizDev2020.Models;

namespace wizDev2020.Controllers
{
    public class QuizController : Controller
    {
        private readonly Wizdev2020Context _context;    
        private static QuizModel[] data;    // 出題される問題
        private static int correctNum = 0;  // 正答数
        public QuizController(Wizdev2020Context context) => _context = context;

        // 出題内容を無作為に入れ替える
        public IActionResult Index()
        {
            ViewData["All"] = $"全{_context.Quizzes.Count()}問";    // 総問題数
            // 一意の参照番号を作成し並び替え
            data = _context.Quizzes.OrderBy(q => Guid.NewGuid()).ToArray();
            correctNum = 0; // 初期化
            return View();
        }

        /*
         * 解答画面
         * id 並び替えた何番目を出題するか
         */
        [HttpGet]
        public IActionResult Question(int id)
        {
            // 未出題なし
            if (_context.Quizzes.Count() < id)
            {
                // 結果表示画面に遷移
                return RedirectToAction("Result");
            }
            // 未出題あり
            else
            {
                ViewBag.correct= correctNum; // 正答数
                ViewBag.correctPosition = data[id - 1].quiz_correct; // 正答の位置
                ViewData["Next"] = id + 1; // 次の問題の添え字
                ViewData["Now"] = $"{id}問目";
                ViewData["All"] = _context.Quizzes.Count(); // 総問題数
                //ViewData["AlloutofCorrect"] = $"{ViewData["All"]}問中{correctNum}問正解"; ;
                ViewData["Correct"] = $"正解は{ViewBag.correctPosition}番目の{data[id - 1].quiz_answer}";

                // 配列の添え字が0から始まるため調整
                return View(data[id - 1]);
            }
        }

        // 結果表示
        public IActionResult Result() {
            ViewData["Correct"] = $"{_context.Quizzes.Count()}問中{correctNum}問正解"; // 正答数
            return View();
        }
    }
}