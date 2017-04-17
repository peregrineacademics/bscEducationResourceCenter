using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Sector
    {
        public Sector()
        {
            ArticleSector = new HashSet<ArticleSector>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleSector> ArticleSector { get; set; }
    }
}
