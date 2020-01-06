using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSharp8._0.Model
{
    public partial class attendance_devContext : DbContext
    {
        public attendance_devContext()
        {
        }

        public attendance_devContext(DbContextOptions<attendance_devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceGroup> AttendanceGroup { get; set; }
        public virtual DbSet<AttendanceGroupDetail> AttendanceGroupDetail { get; set; }
        public virtual DbSet<ClockGate> ClockGate { get; set; }
        public virtual DbSet<ClockInfo> ClockInfo { get; set; }
        public virtual DbSet<ClockLog> ClockLog { get; set; }
        public virtual DbSet<ClockMobile> ClockMobile { get; set; }
        public virtual DbSet<DayReport> DayReport { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<MonthlyReport> MonthlyReport { get; set; }
        public virtual DbSet<PayData> PayData { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Supplement> Supplement { get; set; }
        public virtual DbSet<Whitelist> Whitelist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=10.158.0.32;user id=root;password=1Q2W3e4r!;AllowZeroDateTime=True;database=attendance_dev", x => x.ServerVersion("5.7.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceGroup>(entity =>
            {
                entity.ToTable("attendance_group");

                entity.HasComment("考勤组表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("begin_date")
                    .HasColumnType("datetime")
                    .HasComment("开始时间");

                entity.Property(e => e.ClockInCount)
                    .HasColumnName("clock_in_count")
                    .HasColumnType("int(11)")
                    .HasComment("打卡次数");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasColumnType("tinyint(4)")
                    .HasComment("是否是默认；1：默认，2：非默认");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ShiftsId)
                    .HasColumnName("shifts_id")
                    .HasComment("班次")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<AttendanceGroupDetail>(entity =>
            {
                entity.ToTable("attendance_group_detail");

                entity.HasComment("考勤组成员明细表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BeginDate)
                    .HasColumnName("begin_date")
                    .HasColumnType("datetime")
                    .HasComment("开始时间");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasComment("考勤组id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.No)
                    .HasColumnName("no")
                    .HasColumnType("varchar(50)")
                    .HasComment("编号（人员编号、组织结构编号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("类型（1：人员、2：组织结构）");
            });

            modelBuilder.Entity<ClockGate>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClockDate })
                    .HasName("PRIMARY");

                entity.ToTable("clock_gate");

                entity.HasIndex(e => new { e.ClockDate, e.EmpNo })
                    .HasName("IDX_clock_info_clock_date_emp_no");

                entity.HasIndex(e => new { e.Type, e.FromSource })
                    .HasName("Ix_type");

                entity.HasIndex(e => new { e.TenantId, e.RecordStatus, e.ClockDate, e.EmpNo, e.EmpName })
                    .HasName("IX_clock_info_clock_date_emp_no_emp_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("guid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClockDate)
                    .HasColumnName("clock_date")
                    .HasColumnType("datetime")
                    .HasComment("打卡时间");

                entity.Property(e => e.CardNo)
                    .HasColumnName("card_no")
                    .HasColumnType("varchar(128)")
                    .HasComment("卡号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("创建人saasid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("员工姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("员工编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EquCode)
                    .HasColumnName("equ_code")
                    .HasColumnType("varchar(50)")
                    .HasComment("闸机口号/指纹机设备号/App考勤地点")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromSource)
                    .HasColumnName("from_source")
                    .HasColumnType("int(11)")
                    .HasComment("来源(1.同步 2 Excel导入)");

                entity.Property(e => e.InOut)
                    .HasColumnName("in_out")
                    .HasColumnType("bit(1)")
                    .HasComment("进出标识");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("修改人saasid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReadId)
                    .HasColumnName("read_id")
                    .HasColumnType("varchar(100)")
                    .HasComment("设备号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReadName)
                    .HasColumnName("read_name")
                    .HasColumnType("varchar(255)")
                    .HasComment("打卡地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecId)
                    .HasColumnName("rec_id")
                    .HasColumnType("varchar(64)")
                    .HasComment("闸机自增ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("记录状态（0无效1有效）");

                entity.Property(e => e.SyncDatetime)
                    .HasColumnName("sync_datetime")
                    .HasColumnType("datetime")
                    .HasComment("同步时间");

                entity.Property(e => e.SyncError)
                    .HasColumnName("sync_error")
                    .HasColumnType("varchar(255)")
                    .HasComment("同步失败原因")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SyncStatus)
                    .HasColumnName("sync_status")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("同步状态:0：未同步；2：同步成功；-1：同步失败。");

                entity.Property(e => e.TenantId)
                    .HasColumnName("tenant_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("租户ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("类型");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("类型名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ClockInfo>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClockDate })
                    .HasName("PRIMARY");

                entity.ToTable("clock_info");

                entity.HasComment("打卡数据汇总表");

                entity.HasIndex(e => new { e.ClockDate, e.EmpNo })
                    .HasName("IDX_clock_info_clock_date_emp_no");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("guid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClockDate)
                    .HasColumnName("clock_date")
                    .HasColumnType("datetime")
                    .HasComment("打卡时间");

                entity.Property(e => e.ClockRemark)
                    .HasColumnName("clock_remark")
                    .HasColumnType("varchar(50)")
                    .HasComment("打卡备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("员工姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("员工编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("类型");
            });

            modelBuilder.Entity<ClockLog>(entity =>
            {
                entity.ToTable("clock_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(2000)")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasComment("1：成功 2：失败");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("1：闸机 2：移动 3：合并");
            });

            modelBuilder.Entity<ClockMobile>(entity =>
            {
                entity.ToTable("clock_mobile");

                entity.HasIndex(e => e.AttenceEmpNo)
                    .HasName("empno");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AtenceClockTime)
                    .HasColumnName("atenceClockTime")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AttenceCbzx)
                    .HasColumnName("attenceCBZX")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("成本中心")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceDeviceId)
                    .HasColumnName("attenceDeviceID")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("设备ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceEmpName)
                    .HasColumnName("attenceEmpName")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("员工姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceEmpNo)
                    .HasColumnName("attenceEmpNo")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("员工编号 ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceGzd)
                    .HasColumnName("attenceGZD")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("工作地")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttencePointAddr)
                    .HasColumnName("attencePointAddr")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttencePointLatitude)
                    .HasColumnName("attencePointLatitude")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("纬度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttencePointLongitude)
                    .HasColumnName("attencePointLongitude")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("经度")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttencePointName)
                    .HasColumnName("attencePointName")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceRecordTime)
                    .HasColumnName("attenceRecordTime")
                    .HasColumnType("date")
                    .HasComment("打卡时间");

                entity.Property(e => e.AttenceRemark)
                    .HasColumnName("attenceRemark")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("备注描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttenceType)
                    .HasColumnName("attenceType")
                    .HasDefaultValueSql("'1'")
                    .HasComment("考勤类型 1： H5普通打卡2：原生ios普通打卡 3：原生android普通打卡 4：H5外勤打卡");

                entity.Property(e => e.AttenceZw)
                    .HasColumnName("attenceZW")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("职位")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("添加时间");

                entity.Property(e => e.MacId)
                    .HasColumnName("macId")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("蓝牙mac 地址ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobileId)
                    .HasColumnName("mobileId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.OrganizeId)
                    .HasColumnName("organizeId")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("事业群ID");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasDefaultValueSql("'1'")
                    .HasComment("数据来源 1: app 2: 企业微信 3：小程序");

                entity.Property(e => e.Style)
                    .HasColumnName("style")
                    .HasDefaultValueSql("'1'")
                    .HasComment("打卡类型 1:GPS 2：蓝牙 3:WIFI");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("int(10)")
                    .HasComment("更新时间");

                entity.Property(e => e.UuId)
                    .HasColumnName("uuId")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("蓝牙的UUID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WifiId)
                    .HasColumnName("wifiId")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''")
                    .HasComment("wifi 打卡")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DayReport>(entity =>
            {
                entity.ToTable("day_report");

                entity.HasIndex(e => e.AttendanceDate)
                    .HasName("index_attendance_date");

                entity.HasIndex(e => e.EmpNo)
                    .HasName("index_emp_no");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AbnormalMinutes)
                    .HasColumnName("abnormal_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("异常分钟数");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnName("attendance_date")
                    .HasColumnType("date")
                    .HasComment("考勤日期");

                entity.Property(e => e.AttendanceMinutes)
                    .HasColumnName("attendance_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("出勤分钟数");

                entity.Property(e => e.AttendanceStatus)
                    .HasColumnName("attendance_status")
                    .HasColumnType("int(11)")
                    .HasComment("考勤状态");

                entity.Property(e => e.AttendanceType)
                    .HasColumnName("attendance_type")
                    .HasColumnType("int(11)")
                    .HasComment("考勤类型（考勤组）");

                entity.Property(e => e.BusinessMinutes)
                    .HasColumnName("business_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("因公外出分钟数");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EarlyMinute)
                    .HasColumnName("early_minute")
                    .HasColumnType("int(11)")
                    .HasComment("早退分钟数");

                entity.Property(e => e.EmpCcName)
                    .HasColumnName("emp_cc_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("成本中心名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpCcNo)
                    .HasColumnName("emp_cc_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("成本中心编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpDeptName)
                    .HasColumnName("emp_dept_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("人事部门名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpDeptNo)
                    .HasColumnName("emp_dept_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("人事部门编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("员工姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("员工编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstAttendanceDesc)
                    .HasColumnName("first_attendance_desc")
                    .HasColumnType("varchar(50)")
                    .HasComment("初次考勤描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstAttendanceStatus)
                    .HasColumnName("first_attendance_status")
                    .HasColumnType("int(11)")
                    .HasComment("初次考勤状态");

                entity.Property(e => e.IoaAttendanceStatus)
                    .HasColumnName("ioa_attendance_status")
                    .HasColumnType("int(11)")
                    .HasComment("IOA假勤状态");

                entity.Property(e => e.LateMinutes)
                    .HasColumnName("late_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("迟到分钟数");

                entity.Property(e => e.LeaveMinutes)
                    .HasColumnName("leave_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("请假分钟数");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OffClockTime)
                    .HasColumnName("off_clock_time")
                    .HasColumnType("datetime")
                    .HasComment("下班打卡时间");

                entity.Property(e => e.OffClockTimeResource)
                    .HasColumnName("off_clock_time_resource")
                    .HasColumnType("varchar(20)")
                    .HasComment("下班打卡时间来源")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasColumnType("varchar(255)")
                    .HasComment("原因")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)")
                    .HasComment("记录状态(1:正常,2:已删除)");

                entity.Property(e => e.Shifts)
                    .HasColumnName("shifts")
                    .HasComment("班次id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkClockTime)
                    .HasColumnName("work_clock_time")
                    .HasColumnType("datetime")
                    .HasComment("上班打卡时间");

                entity.Property(e => e.WorkClockTimeResource)
                    .HasColumnName("work_clock_time_resource")
                    .HasColumnType("varchar(20)")
                    .HasComment("上班打卡时间来源")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(16)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Msg)
                    .HasColumnName("msg")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<MonthlyReport>(entity =>
            {
                entity.ToTable("monthly_report");

                entity.HasComment("月结表");

                entity.HasIndex(e => new { e.TenantId, e.RecordStatus, e.AttendanceYear, e.AttendanceMonth })
                    .HasName("IX_monthly_report_year_month");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(36)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AbsentHours)
                    .HasColumnName("absent_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("旷工工时");

                entity.Property(e => e.AttendanceHours)
                    .HasColumnName("attendance_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("工作日出勤工时");

                entity.Property(e => e.AttendanceMonth)
                    .HasColumnName("attendance_month")
                    .HasColumnType("int(11)")
                    .HasComment("考勤月");

                entity.Property(e => e.AttendanceYear)
                    .HasColumnName("attendance_year")
                    .HasColumnType("int(11)")
                    .HasComment("考勤年");

                entity.Property(e => e.ChildProducts)
                    .HasColumnName("child_products")
                    .HasColumnType("varchar(128)")
                    .HasComment("子产品线")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EarlyMinute)
                    .HasColumnName("early_minute")
                    .HasColumnType("int(11)")
                    .HasComment("早退分钟数");

                entity.Property(e => e.EmpName)
                    .HasColumnName("emp_name")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("用户编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpTop2DeptName)
                    .HasColumnName("emp_top2_dept_name")
                    .HasColumnType("varchar(255)")
                    .HasComment("组织结构2名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpTop2DeptNo)
                    .HasColumnName("emp_top2_dept_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("组织结构2编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime")
                    .HasComment("入职时间");

                entity.Property(e => e.IdCard)
                    .HasColumnName("id_card")
                    .HasColumnType("varchar(128)")
                    .HasComment("卡号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LateEarlyHours)
                    .HasColumnName("late_early_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("迟到早退处罚工时");

                entity.Property(e => e.LateMinute)
                    .HasColumnName("late_minute")
                    .HasColumnType("int(11)")
                    .HasComment("迟到分钟数");

                entity.Property(e => e.LeaveHours)
                    .HasColumnName("leave_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("请假工时");

                entity.Property(e => e.LeftDate)
                    .HasColumnName("left_date")
                    .HasColumnType("datetime")
                    .HasComment("离职时间");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("修改人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OverTimeHours)
                    .HasColumnName("over_time_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("加班工时");

                entity.Property(e => e.OverTimeNumber)
                    .HasColumnName("over_time_number")
                    .HasColumnType("int(11) unsigned")
                    .HasDefaultValueSql("'0'")
                    .HasComment("加班次数");

                entity.Property(e => e.OweHours)
                    .HasColumnName("owe_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("欠工时");

                entity.Property(e => e.ProductsLine)
                    .HasColumnName("products_line")
                    .HasColumnType("varchar(128)")
                    .HasComment("产品线")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PsaAccompanyMaternityLeave)
                    .HasColumnName("psa_accompany_maternity_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA陪产假");

                entity.Property(e => e.PsaAnnualLeave)
                    .HasColumnName("psa_annual_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA年假");

                entity.Property(e => e.PsaBreastFeedingLeave)
                    .HasColumnName("psa_breast_feeding_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA哺乳假");

                entity.Property(e => e.PsaBusinessHours)
                    .HasColumnName("psa_business_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("psa_business_hours");

                entity.Property(e => e.PsaFuneralLeave)
                    .HasColumnName("psa_funeral_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA丧事假时数");

                entity.Property(e => e.PsaInvertedleave)
                    .HasColumnName("psa_invertedleave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA倒休");

                entity.Property(e => e.PsaMaternityLeave)
                    .HasColumnName("psa_maternity_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA产假");

                entity.Property(e => e.PsaPrenatalExaminatLeave)
                    .HasColumnName("psa_prenatal_examinat_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA产检假");

                entity.Property(e => e.PsaPrsonalLeave)
                    .HasColumnName("psa_prsonal_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PAS事假");

                entity.Property(e => e.PsaSickLeave)
                    .HasColumnName("psa_sick_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA病假");

                entity.Property(e => e.PsaWeddingHolidayLeave)
                    .HasColumnName("psa_wedding_holiday_leave")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA婚假");

                entity.Property(e => e.PsaWorkOffHours)
                    .HasColumnName("psa_work_off_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("PSA加班倒休");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("int(11)")
                    .HasComment("记录状态（0无效1有效）");

                entity.Property(e => e.RequiredAttendanceDays)
                    .HasColumnName("required_attendance_days")
                    .HasColumnType("int(11)")
                    .HasComment("应出勤工时");

                entity.Property(e => e.SapComName)
                    .HasColumnName("sap_com_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("公司名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapComNo)
                    .HasColumnName("sap_com_no")
                    .HasColumnType("varchar(128)")
                    .HasComment("公司编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBdId)
                    .HasColumnName("sap_emp_bd_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("BDID");

                entity.Property(e => e.SapEmpBdName)
                    .HasColumnName("sap_emp_bd_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("BD名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBdNo)
                    .HasColumnName("sap_emp_bd_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("BD编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBgId)
                    .HasColumnName("sap_emp_bg_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("BGID");

                entity.Property(e => e.SapEmpBgName)
                    .HasColumnName("sap_emp_bg_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("BG名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBgNo)
                    .HasColumnName("sap_emp_bg_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("BG编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBuId)
                    .HasColumnName("sap_emp_bu_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("BUId");

                entity.Property(e => e.SapEmpBuName)
                    .HasColumnName("sap_emp_bu_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("BU名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpBuNo)
                    .HasColumnName("sap_emp_bu_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("BU编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpCcId)
                    .HasColumnName("sap_emp_cc_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("成本中心");

                entity.Property(e => e.SapEmpCcName)
                    .HasColumnName("sap_emp_cc_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("成本中心名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpCcNo)
                    .HasColumnName("sap_emp_cc_no")
                    .HasColumnType("varchar(255)")
                    .HasComment("成本中心编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpDeptId)
                    .HasColumnName("sap_emp_dept_id")
                    .HasColumnType("bigint(128)")
                    .HasComment("员工人事部门Id");

                entity.Property(e => e.SapEmpDeptName)
                    .HasColumnName("sap_emp_dept_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("员工人事部门名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SapEmpDeptNo)
                    .HasColumnName("sap_emp_dept_no")
                    .HasColumnType("varchar(20)")
                    .HasComment("人事部门编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShiftFlights)
                    .HasColumnName("shift_flights")
                    .HasColumnType("varchar(128)")
                    .HasComment("班次")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TenantId)
                    .HasColumnName("tenant_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("租户ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkExtendHours)
                    .HasColumnName("work_extend_hours")
                    .HasColumnType("decimal(18,4)")
                    .HasComment("延长总工时");

                entity.Property(e => e.WorkPlaceName)
                    .HasColumnName("work_place_name")
                    .HasColumnType("varchar(128)")
                    .HasComment("工作地点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkPlaceNo)
                    .HasColumnName("work_place_no")
                    .HasColumnType("varchar(128)")
                    .HasComment("工作地点编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PayData>(entity =>
            {
                entity.ToTable("pay_data");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Begda)
                    .HasColumnName("begda")
                    .HasColumnType("date")
                    .HasComment("开始日期");

                entity.Property(e => e.Beguz)
                    .HasColumnName("beguz")
                    .HasColumnType("varchar(10)")
                    .HasComment("开始时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Endda)
                    .HasColumnName("endda")
                    .HasColumnType("date")
                    .HasComment("结束日期");

                entity.Property(e => e.Enduz)
                    .HasColumnName("enduz")
                    .HasColumnType("varchar(10)")
                    .HasComment("结束时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pernr)
                    .HasColumnName("pernr")
                    .HasColumnType("varchar(50)")
                    .HasComment("人员编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Stdaz)
                    .HasColumnName("stdaz")
                    .HasColumnType("decimal(6,2)")
                    .HasComment("缺勤时数");

                entity.Property(e => e.Subty)
                    .HasColumnName("subty")
                    .HasColumnType("varchar(20)")
                    .HasComment("缺勤信息子类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.ToTable("shifts");

                entity.HasComment("班次表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClockEndDate)
                    .HasColumnName("clock_end_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("可打卡结束时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClockStartDate)
                    .HasColumnName("clock_start_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("可打卡开始时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasColumnType("varchar(1000)")
                    .HasComment("班次描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effective_date")
                    .HasColumnType("datetime")
                    .HasComment("生效时间");

                entity.Property(e => e.ElasticMinutes)
                    .HasColumnName("elastic_minutes")
                    .HasColumnType("int(11)")
                    .HasComment("弹性分钟");

                entity.Property(e => e.GoOffWorkAfternoonDate)
                    .HasColumnName("go_off_work_afternoon_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("下午下班时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoOffWorkMorningDate)
                    .HasColumnName("go_off_work_morning_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("上午下班时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoToWorkAfternoonDate)
                    .HasColumnName("go_to_work_afternoon_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("下午上班时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoToWorkMorningDate)
                    .HasColumnName("go_to_work_morning_date")
                    .HasColumnType("varchar(10)")
                    .HasComment("上午上班时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("班次名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<Supplement>(entity =>
            {
                entity.ToTable("supplement");

                entity.HasComment("异常补录表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(36)")
                    .HasComment("ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApprovalDesc)
                    .HasColumnName("approval_desc")
                    .HasColumnType("varchar(50)")
                    .HasComment("审批说明")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApprovalEmpNo)
                    .HasColumnName("approval_emp_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("审批人编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ApprovalStatus)
                    .HasColumnName("approval_status")
                    .HasColumnType("tinyint(4)")
                    .HasComment("审批状态");

                entity.Property(e => e.ApprovalTime)
                    .HasColumnName("approval_time")
                    .HasColumnType("datetime")
                    .HasComment("审批时间");

                entity.Property(e => e.ApprovalType)
                    .HasColumnName("approval_type")
                    .HasColumnType("tinyint(4)")
                    .HasComment("审批类型");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DayReportAttDate)
                    .HasColumnName("day_report_att_date")
                    .HasColumnType("date")
                    .HasComment("日结表考勤日期");

                entity.Property(e => e.DayReportEmpNo)
                    .HasColumnName("day_report_emp_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("日结表用户编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DayReportId)
                    .HasColumnName("day_report_id")
                    .HasColumnType("varchar(36)")
                    .HasComment("日结表主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)")
                    .HasComment("记录状态");

                entity.Property(e => e.SupplementDesc)
                    .HasColumnName("supplement_desc")
                    .HasColumnType("varchar(50)")
                    .HasComment("异常补录说明")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SupplementEmpNo)
                    .HasColumnName("supplement_emp_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("提交人编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SupplementTime)
                    .HasColumnName("supplement_time")
                    .HasColumnType("datetime")
                    .HasComment("提交时间");

                entity.Property(e => e.SupplementType)
                    .HasColumnName("supplement_type")
                    .HasColumnType("tinyint(4)")
                    .HasComment("提交类型");
            });

            modelBuilder.Entity<Whitelist>(entity =>
            {
                entity.ToTable("whitelist");

                entity.HasComment("白名单");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(36)")
                    .HasComment("id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnName("create_datetime")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmpNo)
                    .HasColumnName("emp_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("员工编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date")
                    .HasComment("失效日期");

                entity.Property(e => e.ModifyDatetime)
                    .HasColumnName("modify_datetime")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnName("modify_user_id")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("record_status")
                    .HasColumnType("tinyint(4)")
                    .HasComment("记录状态(1:正常,2:已删除)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date")
                    .HasComment("生效日期");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
