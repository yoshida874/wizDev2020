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
        private static int ALL; // 総出題数
        public QuizController(Wizdev2020Context context) => _context = context;

        // 正答数の初期化と問題の並べ替え
        public IActionResult Index()
        {
            correctNum = 0; // 初期化
            data = _context.Quizzes.OrderBy(q => Guid.NewGuid()).ToArray();
            return View();
        }

        // 総問題数の代入とリダイレクト
        public IActionResult SetAll(int all)
        {
            ALL = all;
            return RedirectToAction("Question");
        }

        /// <summary>
        /// 出題の可否を判定し遷移
        /// </summary>
        /// <param name="id">現在の問題</param>
        /// <returns>遷移するビュー</returns>
        public IActionResult Question(int id = 1)
        {
            // 未出題なし
            if (ALL < id + 1)
            {
                // 結果表示にリダイレクト
                return RedirectToAction("Result");
            }
            // 未出題あり
            else
            {
                GetParam(id);
                ViewBag.correctnum = correctNum; // 正答数
                ViewBag.correctPosition = data[id - 1].quiz_correct; // 正答の位置
                ViewData["Next"] = id + 1; // 次の問題の添え字
                ViewData["Now"] = $"{id}問目";
                ViewData["AlloutofCorrect"] = $"{id - 1}問中{correctNum}問正解";
                ViewData["Correct"] = $"正解は{ViewBag.correctPosition}番目の{data[id - 1].quiz_answer}";

                // 配列の添え字が0から始まるため調整
                return View(data[id - 1]);
            }
        }

        // 選択されたボタンのIDを取得
        private void GetParam(int id)
        {
            // 最初には?だけが渡されるため
            if (1 < id)
            {
                var param = Request.QueryString.ToString();
                var selId = param.Substring(param.Length - 1, 1);
                isParse(id, selId);
            }
        }

        // 変換可能かを調べ同一なら加算
        private void isParse(int id, string selId)
        {
            int num;
            bool success = int.TryParse(selId, out num);
            if (success)
            {
                // 次の問題に遷移後に比較判定を行うため -2
                if (num == data[id - 2].quiz_correct)
                {
                    correctNum++;
                }
            }
        }

        // 結果表示
        public IActionResult Result() {
            ViewBag.percent = (float)correctNum / ALL * 100;
            ViewData["res"] = $"{ViewBag.percent:F2}%";
            // selIdとの比較のため調整
            ViewData["Correct"] = $"{ALL - 1}問中{correctNum}問正解"; // 正答数
            return View();
        }
    }
}