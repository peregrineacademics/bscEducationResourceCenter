using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class LogSource
    {
        public LogSource()
        {
            Log = new HashSet<Log>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Log> Log { get; set; }
    }
}
