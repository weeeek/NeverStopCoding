using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode632
    {
        public static int[] SmallestRange(IList<IList<int>> nums)
        {
            /* k 个升序排列的整数数组。找到一个最小区间，使得 k 个列表中的每个列表至少有一个数包含在其中。
              我们定义如果 b-a < d-c 或者在 b-a == d-c 时 a < c，则区间 [a,b] 比 [c,d] 小。
              注意:
                给定的列表可能包含重复元素，所以在这里升序表示 >= 。
                1 <= k <= 3500
                -100000 <= 元素的值 <= 100000             
            */

            // 数值，区间
            Dictionary<int, bool[]> dic = new Dictionary<int, bool[]>();

            /*
             [  4,   10, 15,      24, 26]
             [0,   9,  12,    20]
             [   5,        18,  22,     30]
             */

            // 计算每一个数，在每一行的出现情况
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums[i].Count; j++)
                {
                    if (!dic.ContainsKey(nums[i][j]))
                        dic[nums[i][j]] = new bool[nums.Count];
                    dic[nums[i][j]][i] = true;
                }
            }

            // 排序
            var order = dic.OrderBy(s => s.Key).ToArray();

            // 起始
            var result = new int[] { -100000, 100000 };
            // 区间跨度，默认最小到最大
            var step = 200000;

            /* 从最小的数开始
               如果这个数在每一行都出现，则返回 [这个数, 这个数]
               否则往后找比它大一点点的数，或运算合并出现的行，计算区间跨度，如果更小，则替换结果
            */
            for (int i = 0; i < dic.Keys.Count; i++)
            {
                // 基准
                var zone = order[i].Value;
                // 新基准最小值
                var min = order[i].Key;
                // 新基准默认最大值
                var max = 100000;
                var j = i;
                // 这个数在每一行都出现了，则直接返回结果 [这个数, 这个数]
                if (zone.All(s => s)) {
                    return new int[] { order[i].Key, order[i].Key };
                }
                else {
                    while (zone.Any(s => s == false) && ++j < dic.Keys.Count)
                    {
                        for (var k = 0; k < order[j].Value.Length; k++)
                        {
                            zone[k] = zone[k] || order[j].Value[k];
                        }
                    }
                    if (zone.All(s => s))
                    {
                        max = order[j].Key;
                        if (max - min < step)
                        {
                            step = max - min;
                            result[0] = min;
                            result[1] = max;
                        }
                    }
                }
            }
            return result;
        }
    }
}
