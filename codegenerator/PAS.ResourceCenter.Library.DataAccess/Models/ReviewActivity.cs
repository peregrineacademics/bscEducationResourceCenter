﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewActivity
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public string Activity { get; set; }
        public long Ordinal { get; set; }
    }
}
