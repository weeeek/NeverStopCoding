using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class Whitelist
    {
        public string Id { get; set; }
        public string EmpNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
