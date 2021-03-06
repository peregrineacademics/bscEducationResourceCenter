﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class GuideType
    {
        public GuideType()
        {
            Review = new HashSet<Review>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
