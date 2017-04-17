using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleStatus
    {
        public ArticleStatus()
        {
            Article = new HashSet<Article>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
