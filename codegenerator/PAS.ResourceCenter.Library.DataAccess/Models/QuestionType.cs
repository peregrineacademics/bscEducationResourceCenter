using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            QuizQuestion = new HashSet<QuizQuestion>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<QuizQuestion> QuizQuestion { get; set; }
    }
}
