using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_MyWordPop2
{
    internal class Question
    {
        public string questionText { get; set; }

        public List<Answer> answers { get; set; }
    }

    public class Answer
    {
        public string text { get; set; }
        public bool isCorrect { get; set; }
    }
}
