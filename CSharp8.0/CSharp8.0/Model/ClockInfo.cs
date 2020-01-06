using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class ClockInfo: SimpleClockInfo
    {
        public Guid Id { get; set; }
        public DateTime ClockDate { get; set; }
        public int? Type { get; set; }
        public string ClockRemark { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }

    public class SimpleClockInfo
    {
        public int? Type { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
    }

    public struct ClockInfoStruct
    {
        public int? Type { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
    }

    public struct ClockInfoStructGuid
    {
        public Guid Id { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
    }
}
