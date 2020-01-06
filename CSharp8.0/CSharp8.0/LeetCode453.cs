using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode453
    {
        /// <summary>
        /// 给定一个长度为 n 的非空整数数组，找到让数组所有元素相等的最小移动次数。每次移动可以使 n - 1 个元素增加 1。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MinMoves(int[] nums)
        {
            Array.Sort(nums);
            var sameCount = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] == nums[0])
                    sameCount++;
                else
                    break;
            }
            var result = nums[sameCount..].Sum(s => s) - nums[0] * (nums.Length - sameCount);
            return result;
        }
    }
}
