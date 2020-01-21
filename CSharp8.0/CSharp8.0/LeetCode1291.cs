using System.Collections.Generic;
using System.Linq;

namespace CSharp8._0
{
    public static class LeetCode1291
    {
        /// <summary>
        /// 我们定义「顺次数」为：每一位上的数字都比前一位上的数字大 1 的整数。
        /// 请你返回由[low, high] 范围内所有顺次数组成的 有序 列表（从小到大排序）
        /// </summary>
        /// <returns></returns>
        public static IList<int> SequentialDigits(int low, int high)
        {
            return new int[] {
                12, 23, 34, 45, 56, 67, 78, 89,
                123, 234, 345, 456, 567, 678, 789,
                1234, 2345, 3456, 4567, 5678, 6789,
                12345, 23456, 34567, 45678, 56789,
                123456, 234567, 345678, 456789,
                1234567, 2345678, 3456789,
                12345678, 23456789,
                123456789}.Where(s => s >= low && s <= high).ToList();
        }
    }
}
