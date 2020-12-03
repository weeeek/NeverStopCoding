using System;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode198
    {
        /// <summary>
        /// 你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
        /// 给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
        /// 
        /// 0 <= nums.length <= 100
        /// 0 <= nums[i] <= 400
        /// </summary>
        //public static int Rob(int[] nums)
        //{
        //    // 考虑到每间房屋的最高总金额只和该房屋的前两间房屋的最高总金额相关，
        //    // 因此可以使用滚动数组，在每个时刻只需要存储前两间房屋的最高总金额。
        //    if (nums == null || nums.Length == 0)
        //    {
        //        return 0;
        //    }
        //    if (nums.Length == 1)
        //    {
        //        return nums[0];
        //    }
        //    int first = nums[0], second = Math.Max(nums[0], nums[1]);
        //    for (int i = 2; i < nums.Length; i++)
        //    {
        //        int temp = second;
        //        second = Math.Max(first + nums[i], second);
        //        first = temp;
        //    }
        //    return second;
        //}

        public static int Rob(int[] nums)
        {
            // 考虑到每间房屋的最高总金额只和该房屋的前两间房屋的最高总金额相关，
            // 因此可以使用滚动数组，在每个时刻只需要存储前两间房屋的最高总金额。
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }
    }
}
