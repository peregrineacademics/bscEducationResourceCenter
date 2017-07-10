using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewCompetency
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long CompetencyId { get; set; }

        public virtual Competency Competency { get; set; }
        public virtual Review Review { get; set; }
    }
}
