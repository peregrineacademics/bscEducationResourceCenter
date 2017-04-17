﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ArticleCompetency
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long CompetencyId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Competency Competency { get; set; }
    }
}
