using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            ReviewDiscipline = new HashSet<ReviewDiscipline>();
            SubTopic = new HashSet<SubTopic>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewDiscipline> ReviewDiscipline { get; set; }
        public virtual ICollection<SubTopic> SubTopic { get; set; }
    }
}
