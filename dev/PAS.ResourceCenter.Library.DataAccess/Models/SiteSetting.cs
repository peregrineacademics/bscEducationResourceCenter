using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class SiteSetting
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public string Notes { get; set; }
        public bool IsPassword { get; set; }
        public bool IsBoolean { get; set; }
        public bool IsCollection { get; set; }
    }
}
