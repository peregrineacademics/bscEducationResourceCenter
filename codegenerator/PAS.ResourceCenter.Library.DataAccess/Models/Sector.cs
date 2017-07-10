using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Sector
    {
        public Sector()
        {
            ReviewSector = new HashSet<ReviewSector>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewSector> ReviewSector { get; set; }
    }
}
