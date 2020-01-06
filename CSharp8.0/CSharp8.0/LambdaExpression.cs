using System;
using System.Linq;
using System.Linq.Expressions;
using CSharp8._0.Helper;
using CSharp8._0.Model;

namespace CSharp8._0
{
    public class LambdaExpression
    {
        public void Main()
        {
            attendance_devContext db = new attendance_devContext();
            Guid TargetId = new Guid("08d776d7-78e1-3b96-83cc-ad9d4fca2ea9");
            DateTime TargetTime = new DateTime(2019, 11, 3, 14, 27, 7);

            // 默认文本表达式
            Func<string, bool> whereClause = default(Func<string, bool>);
            Expression<Func<ClockInfo, bool>> exp = s => default;

            exp = exp.And(s => s.Id == TargetId);

            // 第一个满足就返回，不检查后续重复
            Console.WriteLine("First" + ActionExtension.Profiler(() => db.ClockInfo.First(exp), 1));
            Console.WriteLine("Single" + ActionExtension.Profiler(() => db.ClockInfo.Single(exp), 1));

            // 根据主键 find，所有主键都要传
            Console.WriteLine("Find" + ActionExtension.Profiler(() => db.ClockInfo.Find(TargetId, TargetTime), 1));
            // 需要 using System.Linq;
            exp = exp.And(s => s.ClockDate == TargetTime);
            // Single总是迭代整个集合，即使它在列表的开始处发现它。并检查重复。通常用于账号相关。
            Console.WriteLine("Single" + ActionExtension.Profiler(() => db.ClockInfo.Single(exp), 1));
            // 第一个满足就返回，不检查后续重复
            Console.WriteLine("First" + ActionExtension.Profiler(() => db.ClockInfo.First(exp), 1));

            Console.WriteLine("单主键");



            // 默认值
            var entity = db.ClockInfo.FirstOrDefault(s => s.Id == TargetId && s.ClockDate == TargetTime) ?? new ClockInfo();
            // C# 6.0 Null 条件运算符 ?.
            var name = entity?.EmpName;
            // C# 8.0 及更高版本中可使用空合并赋值运算符 ??=，该运算符仅在左侧操作数的求值结果为 null 时，才将其右侧操作数的值赋值给左操作数。 如果左操作数的求值结果为非 null，则 ??= 运算符不会对右操作数求值。
            name ??= "默认名";
            Console.WriteLine(name);

            var arrA = new int[] { 1, 2, 3, 4 };
            var arrB = new int[] { 3, 4, 5, 6 };

            // 并集
            Console.WriteLine(String.Join(" ", arrA.Union(arrB)));  // 123456

            // 差集（A有B没有）
            Console.WriteLine(String.Join(" ", arrA.Except(arrB)));  // 1，2
            // 差集（B有A没有）
            Console.WriteLine(String.Join(" ", arrB.Except(arrA)));  // 5，6

            // 交集
            Console.WriteLine(String.Join(" ", arrA.Intersect(arrB))); // 3，4
        }
    }
}
