using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wizDev2020.Models
{
    public class QuizModel
    {
        [Key]
        public int Id { get; set; }
        public string quiz_question { get; set; }
        public string quiz_answer { get; set; }
        public string quiz_choice1 { get; set; }
        public string quiz_choice2 { get; set; }
        public string quiz_choice3 { get; set; }
        public string quiz_choice4 { get; set; }
        public int quiz_correct { get; set; }
    }
}
