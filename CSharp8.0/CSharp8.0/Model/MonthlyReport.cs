using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class MonthlyReport
    {
        public string Id { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string IdCard { get; set; }
        public string WorkPlaceNo { get; set; }
        public string WorkPlaceName { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? LeftDate { get; set; }
        public long? SapEmpDeptId { get; set; }
        public string SapEmpDeptName { get; set; }
        public long? SapEmpCcId { get; set; }
        public string SapEmpCcNo { get; set; }
        public string SapEmpCcName { get; set; }
        public long? SapEmpBuId { get; set; }
        public string SapEmpBuNo { get; set; }
        public string SapEmpBuName { get; set; }
        public long? SapEmpBdId { get; set; }
        public string SapEmpBdNo { get; set; }
        public string SapEmpBdName { get; set; }
        public long? SapEmpBgId { get; set; }
        public string SapEmpBgNo { get; set; }
        public string SapEmpBgName { get; set; }
        public string SapComNo { get; set; }
        public string SapComName { get; set; }
        public string ShiftFlights { get; set; }
        public int? AttendanceYear { get; set; }
        public int? AttendanceMonth { get; set; }
        public int? RequiredAttendanceDays { get; set; }
        public decimal? AttendanceHours { get; set; }
        public decimal? OweHours { get; set; }
        public decimal? WorkExtendHours { get; set; }
        public decimal? LeaveHours { get; set; }
        public decimal? AbsentHours { get; set; }
        public decimal? LateEarlyHours { get; set; }
        public decimal? OverTimeHours { get; set; }
        public uint? OverTimeNumber { get; set; }
        public decimal? PsaAnnualLeave { get; set; }
        public decimal? PsaWorkOffHours { get; set; }
        public decimal? PsaInvertedleave { get; set; }
        public decimal? PsaWeddingHolidayLeave { get; set; }
        public decimal? PsaMaternityLeave { get; set; }
        public decimal? PsaPrenatalExaminatLeave { get; set; }
        public decimal? PsaAccompanyMaternityLeave { get; set; }
        public decimal? PsaBreastFeedingLeave { get; set; }
        public decimal? PsaSickLeave { get; set; }
        public decimal? PsaFuneralLeave { get; set; }
        public decimal? PsaPrsonalLeave { get; set; }
        public decimal PsaBusinessHours { get; set; }
        public string ProductsLine { get; set; }
        public string ChildProducts { get; set; }
        public string TenantId { get; set; }
        public int? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
        public string SapEmpDeptNo { get; set; }
        public string EmpTop2DeptNo { get; set; }
        public string EmpTop2DeptName { get; set; }
        public int? LateMinute { get; set; }
        public int? EarlyMinute { get; set; }
    }
}
