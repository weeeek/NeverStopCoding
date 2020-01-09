using System;

namespace CSharp8._0
{
    public class SwitchExpressions
    {
        public void Main()
        {
            Console.WriteLine(EnumSwitch.FromAttendance(AttendanceAbnormalStatusEnum.Normal));

        }
    }

    public static class EnumSwitch
    {
        public static object FromAttendance(AttendanceAbnormalStatusEnum item) => item switch
        {
            AttendanceAbnormalStatusEnum.Normal => 1,
            AttendanceAbnormalStatusEnum.Absenteeism => "旷工",
            AttendanceAbnormalStatusEnum.Absence => false,
            AttendanceAbnormalStatusEnum.Late => DateTime.Now,
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(item)),
        };

        // 对比
        //public static object FromAttendanceSwitch(AttendanceAbnormalStatusEnum item)
        //{
        //    switch (item)
        //    {
        //        case AttendanceAbnormalStatusEnum.Normal:
        //            return 1;
        //        case AttendanceAbnormalStatusEnum.Absenteeism:
        //            return "旷工";
        //        case AttendanceAbnormalStatusEnum.Absence:
        //            return false;
        //        case AttendanceAbnormalStatusEnum.Late:
        //            return DateTime.Now;
        //        default:
        //            return "?";
        //    }
        //}


        // 借助属性模式，例如需求：某外卖平台，各种节假日折扣不同，根据客户地址计算配送费
        public static double FromHolidays(Customer customer, Holidays item, double originPrice) => item switch
        {
            Holidays.Christmas => FromAddress(customer, originPrice * 0.95),
            Holidays.NewYear => FromAddress(customer, originPrice * 0.8),
            Holidays.Lantern => FromAddress(customer, originPrice * 0.9),
            _ => 1.0
        };

        // 属性模式
        public static double FromAddress(Customer customer, double originPrice) => customer switch
        {
            { Area: Area.HK } => originPrice + 1,
            { Area: Area.HY } => originPrice + 2,
            { Area: Area.WC } => originPrice + 3,
            _ => originPrice
        };

        // 元组模式，剪刀石头布。
        public static string RockPaperScissors(string first, string second) => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };
        // 位置模式
        public static Quadrant GetQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
    }
    public enum AttendanceAbnormalStatusEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 旷工
        /// </summary>
        Absenteeism = 2,
        /// <summary>
        /// 缺勤
        /// </summary>
        Absence = 3,
        /// <summary>
        /// 迟到
        /// </summary>
        Late = 4,
        /// <summary>
        /// 早退
        /// </summary>
        LeaveEarly = 5,
        /// <summary>
        /// 迟到并且早退
        /// </summary>
        LateAndLeaveEarly = 6
    }

    public enum Holidays {
        Christmas,
        NewYear,
        Lantern
    }

    public struct Customer {
        public Area Area { get; set; }
    }

    public enum Area {
        HK,
        HY,
        WC
    }
    public enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }
}
