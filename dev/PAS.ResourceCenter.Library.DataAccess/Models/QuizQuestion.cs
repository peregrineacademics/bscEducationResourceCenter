using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class QuizQuestion
    {
        public QuizQuestion()
        {
            QuizAnswer = new HashSet<QuizAnswer>();
        }

        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long QuestionTypeId { get; set; }
        public string Question { get; set; }
        public long Ordinal { get; set; }

        public virtual ICollection<QuizAnswer> QuizAnswer { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual Review Review { get; set; }
    }
}
