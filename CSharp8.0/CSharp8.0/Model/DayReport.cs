using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class DayReport
    {
        public Guid Id { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public Guid? Shifts { get; set; }
        public DateTime? WorkClockTime { get; set; }
        public string WorkClockTimeResource { get; set; }
        public DateTime? OffClockTime { get; set; }
        public string OffClockTimeResource { get; set; }
        public string Reason { get; set; }
        public int? AttendanceMinutes { get; set; }
        public int? AbnormalMinutes { get; set; }
        public int? LeaveMinutes { get; set; }
        public int? BusinessMinutes { get; set; }
        public int? LateMinutes { get; set; }
        public int? EarlyMinute { get; set; }
        public int? FirstAttendanceStatus { get; set; }
        public string FirstAttendanceDesc { get; set; }
        public int? AttendanceStatus { get; set; }
        public int? AttendanceType { get; set; }
        public string EmpDeptNo { get; set; }
        public string EmpDeptName { get; set; }
        public string EmpCcNo { get; set; }
        public string EmpCcName { get; set; }
        public int? IoaAttendanceStatus { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
