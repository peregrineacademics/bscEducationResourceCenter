using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            SubTopic = new HashSet<SubTopic>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubTopic> SubTopic { get; set; }
    }
}
