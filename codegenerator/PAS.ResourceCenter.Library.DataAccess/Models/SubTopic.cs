using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class SubTopic
    {
        public SubTopic()
        {
            ReviewSubTopic = new HashSet<ReviewSubTopic>();
        }

        public long Id { get; set; }
        public long DisciplineId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<ReviewSubTopic> ReviewSubTopic { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}
