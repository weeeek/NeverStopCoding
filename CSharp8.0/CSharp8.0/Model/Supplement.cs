using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class Supplement
    {
        public string Id { get; set; }
        public string DayReportId { get; set; }
        public string DayReportEmpNo { get; set; }
        public DateTime? DayReportAttDate { get; set; }
        public string SupplementEmpNo { get; set; }
        public sbyte? SupplementType { get; set; }
        public string SupplementDesc { get; set; }
        public DateTime? SupplementTime { get; set; }
        public string ApprovalEmpNo { get; set; }
        public sbyte? ApprovalType { get; set; }
        public string ApprovalDesc { get; set; }
        public DateTime? ApprovalTime { get; set; }
        public sbyte? ApprovalStatus { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
