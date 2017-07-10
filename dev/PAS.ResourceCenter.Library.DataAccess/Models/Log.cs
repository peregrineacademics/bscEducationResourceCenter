using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Log
    {
        public long Id { get; set; }
        public long LogSourceId { get; set; }
        public long LogTypeId { get; set; }
        public long LinkId { get; set; }
        public string LinkUserId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }

        public virtual Users CreatedByUser { get; set; }
        public virtual LogSource LogSource { get; set; }
        public virtual LogType LogType { get; set; }
    }
}
