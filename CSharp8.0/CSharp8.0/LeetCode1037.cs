using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1037
    {
        // 坐标系中三个点是否在一条直线上
        public static bool IsBoomerang(int[][] points)
        {
            /*
             判断三点是否同直线，直接思路就是判断斜率。
             假设三点分别为a(x1, y1), b(x2, y2), c(x3,y3),
             a、b两点的斜率为 k1 = (y2 - y1) / (x2 - x1)
             a、c两点的斜率为 k2 = (y3 - y1) / (x3 - x1)
             如果在同一直线，则k1 = k2，考虑到分母为0 的情况，可以直接交叉相乘，省去判断0的情况，直接判断
             (y2 - y1) * (x3 - x1) 与 (y3 - y1) * (x2 - x1)
             不相等即为不在同一直线上
             */
            return (points[1][1] - points[0][1]) * (points[2][0] - points[0][0]) != (points[2][1] - points[0][1]) * (points[1][0] - points[0][0]);

            /*
             * 已知三个顶点坐标来计算三角形面积是否为0： 
             * 面积公式S=1/2[(x1y2-x2y1)+(x2y3-x3y2)+(x3y1-x1y3)]
             */
            return (points[0][0] * (points[1][1] - points[2][1]) + points[1][0] * (points[2][1] - points[0][1]) + points[2][0] * (points[0][1] - points[1][1])) != 0;
        }
    }
}
