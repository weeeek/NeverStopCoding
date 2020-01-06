using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode172
    {
        /// <summary>
        /// 给定一个整数 n，返回 n! 结果尾数中零的数量。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int TrailingZeroes(int n)
        {
            int count = 0;
            while (n > 0)
            {
                // 因子中包含5的个数
                count += n / 5;
                n = n / 5;
            }
            return count;

            //if (n < 5)
            //{
            //    return 0;
            //}
            //return n / 5 + TrailingZeroes(n / 5);
        }
    }
}
