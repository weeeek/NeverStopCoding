using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode11
    {
        /// <summary>
        /// 给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
        /// 在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。
        /// 找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
        /// 说明：你不能倾斜容器，且 n的值至少为 2。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int max = 0;
            while (i < j)
            {
                // 移动短的那边，
                bool left = height[i] <= height[j];
                max = Math.Max(max, (left ? height[i] : height[j]) * (j - i));
                switch (left)
                {
                    case true:
                        i++;
                        break;
                    default:
                        j--;
                        break;
                }
            }
            return max;
        }
    }
}
