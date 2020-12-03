using System;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode64
    {
        /// <summary>
        /// 给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
        /// 说明：每次只能向下或者向右移动一步。
        /// m == grid.length
        /// n == grid[i].length
        /// 1 <= m, n <= 200
        /// 0 <= grid[i][j] <= 100
        /// </summary>
        public static int MinPathSum(int[][] grid)
        {
            // 实际就是原grid每一个格子从小到大依次   加    左和上中比较小的那个
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int tp = 1000000000;
                    if (i > 0) tp = Math.Min(tp, grid[i - 1][j]);
                    if (j > 0) tp = Math.Min(tp, grid[i][j - 1]);
                    grid[i][j] += tp;
                }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
    }
}
