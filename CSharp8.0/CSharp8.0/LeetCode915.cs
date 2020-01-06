using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode915
    {
        public static int PartitionDisjoint(int[] A)
        {
            // 左部分最大值
            var max = 0;
            // 右部分
            var min = 1000000;

            var dic = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                dic[i] = new int[] { max, min };
            }

            for (int i = 0; i < A.Length; i++)
            {
                max = Math.Max(max, A[i]);
                dic[i][0] = max;
                min = Math.Min(min, A[A.Length - 1 - i]);
                dic[A.Length - 1 - i][1] = min;
            }

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (dic[i][0] <= dic[i + 1][1])
                    return i + 1;
            }
            return 0;
        }
    }
}
