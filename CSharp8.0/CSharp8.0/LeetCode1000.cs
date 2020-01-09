using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1000
    {
        /// <summary>
        /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        ///     你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        /// 示例:
        ///     给定 nums = [2, 7, 11, 15], target = 9
        ///     因为 nums[0] + nums[1] = 2 + 7 = 9
        ///     所以返回[0, 1]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int MergeStones(int[] stones, int K)
        {
            if ((stones.Length - 1) % (K - 1) != 0) return -1;
            if (stones.Length == 1) return 0;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            // 1，遍历所有可能的三个数的和
            // 2，取最小的那一组
            while (stones.Length > K)
            {
                for (int i = 0; i < stones.Length - 2; i++)
                {

                }
            }
            return 0;
        }
    }
}
