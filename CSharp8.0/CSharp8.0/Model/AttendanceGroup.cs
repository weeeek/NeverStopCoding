using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class AttendanceGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ShiftsId { get; set; }
        public int? ClockInCount { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
        public sbyte? IsDefault { get; set; }
    }
}
