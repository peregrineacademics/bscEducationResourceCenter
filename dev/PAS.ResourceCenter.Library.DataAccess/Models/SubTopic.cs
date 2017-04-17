using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class SubTopic
    {
        public SubTopic()
        {
            ArticleSubTopic = new HashSet<ArticleSubTopic>();
        }

        public long Id { get; set; }
        public long DisciplineId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleSubTopic> ArticleSubTopic { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}
