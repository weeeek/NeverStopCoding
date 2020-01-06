using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class ClockLog
    {
        public Guid Id { get; set; }
        public int? Type { get; set; }
        public DateTime? Time { get; set; }
        public int? Status { get; set; }
        public string Message { get; set; }
    }
}
