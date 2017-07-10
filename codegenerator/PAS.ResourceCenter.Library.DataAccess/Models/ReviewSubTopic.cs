﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ReviewSubTopic
    {
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public long SubTopicId { get; set; }

        public virtual Review Review { get; set; }
        public virtual SubTopic SubTopic { get; set; }
    }
}