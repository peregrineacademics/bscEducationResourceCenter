using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewSector
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long SectorId { get; set; }

        public virtual Review Review { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
