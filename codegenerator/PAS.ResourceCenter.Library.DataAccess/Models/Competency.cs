using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Competency
    {
        public Competency()
        {
            ReviewCompetency = new HashSet<ReviewCompetency>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewCompetency> ReviewCompetency { get; set; }
    }
}
