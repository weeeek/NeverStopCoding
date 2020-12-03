using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    /// <summary>
    /// 给你一个整数 n 。按下述规则生成一个长度为 n + 1 的数组 nums ：
    /// nums[0] = 0
    /// nums[1] = 1
    /// 当 2 <= 2 * i <= n 时，nums[2 * i] = nums[i]
    /// 当 2 <= 2 * i + 1 <= n 时，nums[2 * i + 1] = nums[i] + nums[i + 1]
    /// 返回生成数组 nums 中的 最大 值。
    /// </summary>
    public static class LeetCode1646
    {
        // 坐标系中三个点是否在一条直线上
        public static int GetMaximumGenerated(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    int max = 1;
                    int[] dp = new int[n + 1];
                    dp[0] = 0;
                    dp[1] = 1;
                    for (int i = 2; i <= n; i++)
                    {
                        if ((i & 1) == 0)
                        {
                            dp[i] = dp[i >> 1];
                        }
                        else
                        {
                            dp[i] = dp[i >> 1] + dp[(i >> 1) + 1];
                        }
                        max = Math.Max(max, dp[i]);
                    }
                    return max;
            }
        }
    }
}
