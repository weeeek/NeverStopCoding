using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public class LeetCode628
    {
        public static int MaximumProduct(int[] nums)
        {
            // 我们将数组进行升序排序，如果数组中所有的元素都是非负数，那么答案即为最后三个元素的乘积。

            // 如果数组中出现了负数，那么我们还需要考虑乘积中包含负数的情况，显然选择最小的两个负数和最大的一个正数是最优的，即为前两个元素与最后一个元素的乘积。

            // 上述两个结果中的较大值就是答案。

            // Array.Sort(nums);
            // return Math.Max(nums[0] * nums[1] * nums[^1], nums[^1] * nums[^2] * nums[^3]);

            // 实际上只要求出数组中最大的三个数以及最小的两个数

            int min1, min2;
            int max1, max2, max3;
            min1 = min2 = int.MaxValue;
            max1 = max2 = max3 = int.MinValue;

            foreach (var item in nums)
            {
                if (item <= min1)
                {
                    min2 = min1;
                    min1 = item;
                }
                else if (item <= min2) {
                    min2 = item;
                }

                if (item >= max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = item;
                }
                else if (item >= max2)
                {
                    max3 = max2;
                    max2 = item;
                }
                else if (item >= max3) {
                    max3 = item;
                }
            }

            return max1 * (max1 > 0 ? Math.Max(min1 * min2, max2 * max3) : Math.Min(min1 * min2, max2 * max3));
        }
    }
}
