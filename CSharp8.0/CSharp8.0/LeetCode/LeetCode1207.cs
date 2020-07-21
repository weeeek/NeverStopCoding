using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1207
    {
        /// <summary>
        /// 给你一个整数数组 arr，请你帮忙统计数组中每个数的出现次数。
        /// 如果每个数的出现次数都是独一无二的，就返回 true；否则返回 false。
        /// </summary>
        /// <returns></returns>
        public static bool UniqueOccurrences(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach (var i in arr)
            {
                if (!dict.ContainsKey(i))
                    dict.Add(i, 0);
                dict[i]++;
            }
            var hashSet = new HashSet<int>();
            foreach (var pair in dict)
            {
                if (hashSet.Contains(pair.Value))
                    return false;
                hashSet.Add(pair.Value);
            }
            return true;
        }
    }
}
