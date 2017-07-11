using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewCategory
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual Review Review { get; set; }
    }
}
