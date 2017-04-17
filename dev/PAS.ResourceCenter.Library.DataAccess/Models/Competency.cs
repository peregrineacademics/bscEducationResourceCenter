using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Competency
    {
        public Competency()
        {
            ArticleCompetency = new HashSet<ArticleCompetency>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleCompetency> ArticleCompetency { get; set; }
    }
}
