using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class AttendanceGroupDetail
    {
        public Guid Id { get; set; }
        public Guid? GroupId { get; set; }
        public int? Type { get; set; }
        public string No { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
