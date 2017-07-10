using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewDiscipline
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Review Review { get; set; }
    }
}
