using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class ClockGate
    {
        public Guid Id { get; set; }
        public string RecId { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string CardNo { get; set; }
        public DateTime ClockDate { get; set; }
        public int? Type { get; set; }
        public string TypeName { get; set; }
        public string ReadId { get; set; }
        public string ReadName { get; set; }
        public int? FromSource { get; set; }
        public string TenantId { get; set; }
        public int? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
        public string EquCode { get; set; }
        public int? SyncStatus { get; set; }
        public DateTime? SyncDatetime { get; set; }
        public string SyncError { get; set; }
        public ulong? InOut { get; set; }
    }
}
