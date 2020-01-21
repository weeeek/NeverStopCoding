using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1
    {
        /// <summary>
        /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，
        /// 并返回他们的数组下标。
        ///     你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        /// 示例:
        ///     给定 nums = [2, 7, 11, 15], target = 9
        ///     因为 nums[0] + nums[1] = 2 + 7 = 9
        ///     所以返回[0, 1]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // 每一个需要配对的目标值
                int temp = target - nums[i];
                if (dic.Keys.Contains(temp))
                    return new int[] { dic[temp], i };
                dic[nums[i]] = i;//当前数据存字典，实现空间换时间
            }
            return null;
        }
    }
}
