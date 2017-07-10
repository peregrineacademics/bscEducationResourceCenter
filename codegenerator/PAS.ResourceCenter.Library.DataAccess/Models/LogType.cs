using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class LogType
    {
        public LogType()
        {
            Log = new HashSet<Log>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Log> Log { get; set; }
    }
}
