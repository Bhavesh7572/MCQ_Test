using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCQ_Test;

namespace MCQ_Test
{
    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public string CorrectAnswerText { get; set; }

        public int GetCorrectAnswerIndex()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                if (Options[i].Equals(CorrectAnswerText, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }

        public string UserAnswer { get; set; }
        public bool IsCorrect => !string.IsNullOrEmpty(UserAnswer) &&
                                 UserAnswer.Equals(CorrectAnswerText, StringComparison.OrdinalIgnoreCase);

    }
}
