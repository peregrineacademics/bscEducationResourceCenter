using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class QuizAnswer
    {
        public long Id { get; set; }
        public long QuizQuestionId { get; set; }
        public string Answer { get; set; }
        public long Ordinal { get; set; }

        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
