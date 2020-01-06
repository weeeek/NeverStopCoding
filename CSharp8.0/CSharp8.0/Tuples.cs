using System;
using System.Threading.Tasks;

namespace CSharp8._0
{
    public class Tuples
    {
        // 低于 C# 7.0 的版本中也提供元组，但它们效率低下且不具有语言支持
        public void Main()
        {
            // 不需要创建Man的类，可以通过为每个成员赋值来创建元组，并可选择为元组的每个成员提供语义名称
            (string Name, int Age) Man = ("万", 18);

            Console.WriteLine($"{Man.Name}, {Man.Age}");


            // 这些名称仅存在于编译时且不保留，在运行时使用反射来检查元组
            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");


            // 接收返回元组，注意返回元组序号
            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
            // ↑_弃元

            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
            var (x, _) = new Point(1, 2);
            Console.WriteLine(x); // 1
            // Console.WriteLine(_); // _不能作为变量名

            ExecuteAsyncMethods().Wait();

            // 左C# 7.0    右 C# 7.1
            int count = 5;
            string label = "Colors used in the map";
            Console.WriteLine((count: count, label: label)== (count, label)); 
            // element names are "count" and "label"
        }

        /// <summary>
        /// 使用独立弃元来忽略异步操作返回的 Task 对象。 这一操作的效果等同于抑制操作即将完成时所引发的异常。
        /// </summary>
        /// <returns></returns>
        private static async Task ExecuteAsyncMethods()
        {
            Console.WriteLine("About to launch a task...");
            // 独立弃元
            _ = Task.Run(() => {
                var iterations = 0;
                for (int ctr = 0; ctr < int.MaxValue; ctr++)
                    iterations++;
                Console.WriteLine("Completed looping operation...");
                // 调试模式会抛出这个异常
                throw new InvalidOperationException();
            });
            await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");
        }

        private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;

            if (name == "New York City")
            {
                double area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
    }

    public class Point
    {
        public Point(double x, double y) => (X, Y) = (x, y);

        public double X { get; }
        public double Y { get; }

        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
    }
}
