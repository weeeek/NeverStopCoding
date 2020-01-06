using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode741
    {
        /*[[0, 1, -1],
           [1, 0, -1],
           [1, 1,  1]]*/
        public static int CherryPickup(int[][] grid)
        {
            // 转化为2人同时从(0,0)走到(N-1,N-1)的最大收益
            var N = grid.Length;
            // 最大步数，即（N-1)*2步走到目的地
            var S = (N - 1) << 1;
            return 0;
        }
    }
}
