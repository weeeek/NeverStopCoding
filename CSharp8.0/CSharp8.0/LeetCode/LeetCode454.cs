using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode454
    {
        /// <summary>
        /// 给定四个包含整数的数组列表 A , B , C , D ,计算有多少个元组 (i, j, k, l) ，使得 A[i] + B[j] + C[k] + D[l] = 0。
        /// 为了使问题简单化，所有的 A, B, C, D 具有相同的长度 N，且 0 ≤ N ≤ 500 。所有整数的范围在 -228 到 228 - 1 之间，最终结果不会超过 231 - 1 。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public static int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        //{
        //    //建立一个哈希映射，一个记录AB数组的组合和，和为key，出现的次数为value
        //    //计算CD数组的组合和，得到相反数，若该数存在于key中，即符合要求，将答案加上AB组合和中该数出现的次数
        //    int N = A.Length;
        //    int result = 0;
        //    Dictionary<int, int> set = new Dictionary<int, int>();
        //    for (int i = 0; i < N; i++)
        //    {
        //        for (int j = 0; j < N; j++)
        //        {
        //            var sum = A[i] + B[j];
        //            if (set.ContainsKey(sum)) set[sum]++;
        //            else set.Add(sum, 1);
        //        }
        //    }
        //    for (int i = 0; i < N; i++)
        //    {
        //        for (int j = 0; j < N; j++)
        //        {
        //            if (set.Keys.Contains(-C[i] - D[j]))
        //                result+= set[-C[i] - D[j]];
        //        }
        //    }
        //    return result;
        //}

        public static int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            Dictionary<int, int> AB = FourSumCount(ToDictionary(A), ToDictionary(B));
            Dictionary<int, int> CD = FourSumCount(ToDictionary(C), ToDictionary(D));

            int result = 0;

            foreach (int ab in AB.Keys)
            {
                if (CD.ContainsKey(-ab))
                {
                    result += AB[ab] * CD[-ab];
                }
            }

            return result;
        }

        public static Dictionary<int, int> ToDictionary(int[] array)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach (var n in array)
            {
                if (result.ContainsKey(n))
                {
                    result[n] += 1;
                }
                else
                {
                    result[n] = 1;
                }
            }

            return result;
        }

        public static Dictionary<int, int> FourSumCount(Dictionary<int, int> a, Dictionary<int, int> b)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach (int numA in a.Keys)
            {
                foreach (int numB in b.Keys)
                {
                    result[numA + numB] = (result.ContainsKey(numA + numB) ? result[numA + numB] : 0) + a[numA] * b[numB];
                }
            }

            return result;
        }
    }
}
