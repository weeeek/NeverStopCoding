using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class ClockMobile
    {
        public Guid Id { get; set; }
        public int? MobileId { get; set; }
        public string AttenceEmpNo { get; set; }
        public string AttenceEmpName { get; set; }
        public DateTime? AttenceRecordTime { get; set; }
        public int? AtenceClockTime { get; set; }
        public bool? Source { get; set; }
        public bool? AttenceType { get; set; }
        public string AttenceRemark { get; set; }
        public string AttenceDeviceId { get; set; }
        public string AttencePointAddr { get; set; }
        public string AttencePointLongitude { get; set; }
        public string AttencePointLatitude { get; set; }
        public string AttenceCbzx { get; set; }
        public string AttenceZw { get; set; }
        public string AttenceGzd { get; set; }
        public string AttencePointName { get; set; }
        public int? OrganizeId { get; set; }
        public string MacId { get; set; }
        public string UuId { get; set; }
        public string WifiId { get; set; }
        public bool? Style { get; set; }
        public int? CreatedAt { get; set; }
        public int? UpdatedAt { get; set; }
    }
}
