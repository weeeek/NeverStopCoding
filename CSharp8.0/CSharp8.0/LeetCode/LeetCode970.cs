using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8._0
{
    public static class LeetCode970
    {
        /// <summary>
        /// 给定两个正整数 x 和 y，如果某一整数等于 x^i + y^j，其中整数 i >= 0 且 j >= 0，那么我们认为该整数是一个强整数。
        /// 返回值小于或等于 bound 的所有强整数组成的列表。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //public static List<int> PowerfulIntegers(int x, int y, int bound)
        //{
        //    var result = new List<int>();
        //    List<int> xTimes = new List<int>();
        //    List<int> yTimes = new List<int>();
        //    if (x == 1)
        //    {
        //        xTimes.Add(1);
        //    }
        //    if (y == 1)
        //    {
        //        yTimes.Add(1);
        //    }
        //    var a = 0;
        //    var flag = true;
        //    if (x > 1 || y > 1)
        //    {
        //        while (flag)
        //        {
        //            var powX = (int)Math.Pow(x, a);
        //            var powY = (int)Math.Pow(y, a);
        //            if (powX <= bound)
        //                xTimes.Add(powX);
        //            if (powY <= bound)
        //                yTimes.Add(powY);
        //            if ((powX == 1 && powY > bound) || (powY == 1 && powX > bound) || powX > bound && powY > bound)
        //                flag = false;
        //            a++;
        //        }
        //    }

        //    var arrX = xTimes.Distinct().ToArray();
        //    var arrY = yTimes.Distinct().ToArray();

        //    for (int i = 0; i < arrX.Length; i++)
        //    {
        //        for (int j = 0; j < arrY.Length; j++)
        //        {
        //            if (arrX[i] + arrY[j] <= bound)
        //                result.Add(arrX[i] + arrY[j]);
        //        }
        //    }
        //    return result.Where(s => s > 0).Distinct().OrderBy(s => s).ToList();
        //}

        public static IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int p, q, m, n, s;
            int count, i, j;
            IList<int> list = new List<int>();

            count = 1;
            if (x != 1)
            {
                m = x;
                n = m;
                while (n < bound)
                {
                    n *= m;
                    count++;
                }
            }
            p = count;

            count = 1;
            if (y != 1)
            {
                m = y;
                n = m;
                while (n < bound)
                {
                    n *= m;
                    count++;
                }
            }
            q = count;
            //Console.WriteLine("{0},{1}",p,q);
            for (i = 0; i <= p; i++)
            {
                for (j = 0; j <= q; j++)
                {
                    s = (int)Math.Pow(x, i) + (int)Math.Pow(y, j);
                    if (s <= bound)
                    {
                        if (!dict.ContainsKey(s))
                        {
                            dict.Add(s, 1);
                            list.Add(s);
                        }
                    }
                }
            }
            return list;
        }
    }
}
