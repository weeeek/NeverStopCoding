using System;
using System.Collections.Generic;

namespace CSharp8._0.Model
{
    public partial class Shifts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClockStartDate { get; set; }
        public string ClockEndDate { get; set; }
        public string GoToWorkMorningDate { get; set; }
        public string GoOffWorkMorningDate { get; set; }
        public string GoToWorkAfternoonDate { get; set; }
        public string GoOffWorkAfternoonDate { get; set; }
        public int? ElasticMinutes { get; set; }
        public string Desc { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public sbyte? RecordStatus { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string ModifyUserId { get; set; }
        public DateTime? ModifyDatetime { get; set; }
    }
}
