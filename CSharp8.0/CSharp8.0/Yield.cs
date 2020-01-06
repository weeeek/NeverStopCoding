using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public class Yield
    {
        public void Main() {
            foreach (var item in FilterWithoutYield)
            {
                Console.WriteLine(item);
            }

            foreach (var item in FilterWithYield)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.ReadKey(false);

            // 
            
            Console.ReadKey(false);
        }

        //位置数据类型
        public static List<object> ObjectData
        {
            get
            {
                return new List<object>() { false, 0, 1, null, 2 };
            }
        }

        //申明属性，定义数据来源
        public static List<int> Data
        {
            get
            {
                return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            }
        }

        //申明属性，过滤器(不使用yield)
        public static IEnumerable<int> FilterWithoutYield
        {
            get
            {
                // 返回大于4的所有的数，就要到另一个集合，有额外的内存消耗。

                var result = new List<int>();
                foreach (var i in Data)
                {
                    if (i > 4)
                        result.Add(i);
                }
                return result;

                // （C# 2.0还没有出lambda linq，C# 3.0 and .Net Framework 3.5了才有）
                // return Data.Where(s => s > 4);
            }
        }

        // 使用 yield
        public static IEnumerable<int> FilterWithYield {
            get
            {
                foreach (var item in Data)
                {
                    if (item > 4)
                    {
                        Console.Write(" ");
                        yield return item;
                    }
                }
            }
        }
    }
}
