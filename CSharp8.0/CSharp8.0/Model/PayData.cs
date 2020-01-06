using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class PayData
    {
        public Guid Id { get; set; }
        public string Pernr { get; set; }
        public DateTime? Begda { get; set; }
        public DateTime? Endda { get; set; }
        public string Subty { get; set; }
        public string Beguz { get; set; }
        public string Enduz { get; set; }
        public decimal? Stdaz { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
