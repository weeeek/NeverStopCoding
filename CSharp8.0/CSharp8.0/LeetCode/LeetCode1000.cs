using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1000
    {
        /// <summary>
        /// 有 N 堆石头排成一排，第 i 堆中有 stones[i] 块石头。
        /// 每次移动（move）需要将连续的 K堆石头合并为一堆，而这个移动的成本为这 K堆石头的总数。
        /// 找出把所有石头合并成一堆的最低成本。如果不可能，返回 -1 。
        /// </summary>
        /// <returns></returns>
        public static int MergeStones(int[] stones, int K)
        {
            if ((stones.Length - 1) % (K - 1) != 0) return -1;
            if (stones.Length == 1) return 0;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            return 0;
        }
    }
}
