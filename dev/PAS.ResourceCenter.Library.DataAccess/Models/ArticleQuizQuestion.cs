using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleQuizQuestion
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long QuestionTypeId { get; set; }
        public string QuizQuestion { get; set; }
        public long Ordinal { get; set; }

        public virtual Article Article { get; set; }
    }
}
