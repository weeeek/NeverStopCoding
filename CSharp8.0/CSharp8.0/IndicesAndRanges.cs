using System;
using System.Linq;
using CSharp8._0.Model;

namespace CSharp8._0
{
    public class IndicesAndRanges
    {
        public void Main(int [] list)
        {
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0
            // 末尾运算符 ^，使用 ^1 索引检索最后一个词

            // 以下代码创建了一个包含单词“quick”、“brown”和“fox”的子范围。 它包括 words[1] 到 words[3]。 元素 words[4] 不在该范围内。
            Console.WriteLine("1," + string.Join(" ", words[1..4]));
            Console.WriteLine("2," + string.Join(" ", words[^2..^0]));
            Console.WriteLine("3," + string.Join(" ", words[..]));
            Console.WriteLine("4," + string.Join(" ", words[..4]));
            Console.WriteLine("5," + string.Join(" ", words[6..]));

            Range r = 1..4;
            Console.WriteLine("6-1" + string.Join(" ", words[r]));

            Console.ReadKey(false);

            Console.WriteLine();
            list.Skip(1).Take(10);

            var start = 1;
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list.Skip(start).Take(10))), 3));
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list[start..(start + 10)])), 3));
            Console.WriteLine();
            start *= 10;
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list.Skip(start).Take(10))), 3));
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list[start..(start + 10)])), 3));
            Console.WriteLine();
            start *= 10;
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list.Skip(start).Take(10))), 3));
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list[start..(start + 10)])), 3));
            Console.WriteLine();
            start *= 10;
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list.Skip(start).Take(10))), 3));
            Console.WriteLine(ActionExtension.Profiler(() => Console.WriteLine(string.Join(" ", list[start..(start + 10)])), 3));

            // 性能差不多
            Console.ReadKey(false);
        }
    }
}
