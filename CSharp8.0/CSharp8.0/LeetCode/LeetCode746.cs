using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    /// <summary>
    /// 数组的每个索引作为一个阶梯，第 i个阶梯对应着一个非负数的体力花费值 cost[i](索引从0开始)。
    /// 每当你爬上一个阶梯你都要花费对应的体力花费值，然后你可以选择继续爬一个阶梯或者爬两个阶梯。
    /// 您需要找到达到楼层顶部的最低花费。在开始时，你可以选择从索引为 0 或 1 的元素作为初始阶梯。
    /// cost 的长度将会在 [2, 1000]。
    /// 每一个 cost[i] 将会是一个Integer类型，范围为[0, 999]。
    /// 
    /// 输入：cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
    /// 输出：6
    /// </summary>
    public static class LeetCode746
    {
        public static int MinCostClimbingStairs(int[] cost)
        {
            for (int i = 2; i < cost.Length; i++)
            {
                cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
            }
            return Math.Min(cost[^1], cost[^2]);
        }
    }
}
