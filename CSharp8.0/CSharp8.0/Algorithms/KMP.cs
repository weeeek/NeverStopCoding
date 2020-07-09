using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0.Algorithms
{
    /// <summary>
    /// KMP算法，视频：https://vdn3.vzuu.com/SD/8dd1f6a4-87b9-11ea-aa0b-16417ac20a0a.mp4?disable_local_cache=1&bu=http-com&expiration=1589450878&auth_key=1589450878-0-0-d7918d7d1dc6a1d6c9622b9a163bf3fe&f=mp4&v=tx
    /// </summary>
    public static class KMP
    {
        /// <summary>
        /// 求出一个字符串数组的next数组
        /// </summary>
        /// <param name="t">字符串组</param>
        /// <returns>next数组</returns>
        private static int[] GetNextArray(char[] t)
        {
            int[] next = new int[t.Length];
            next[0] = -1;
            next[1] = 0;
            int k;
            for (int j = 2; j < t.Length; j++)
            {
                k = next[j - 1];
                while (k != -1)
                {
                    if (t[j - 1] == t[k])
                    {
                        next[j] = k + 1;
                        break;
                    }
                    else
                        k = next[k]; // 当k == -1 而跳出循环时，next[j] = 0，否则next[j]会在break之前被赋值
                    next[j] = 0;
                }
            }
            return next;
        }

        /// <summary>
        /// 对主串和模式串进行kmp模式匹配
        /// </summary>
        /// <param name="s">主串</param>
        /// <param name="t">模式串</param>
        /// <returns>t在s中的第一个相同字符对应的位置，若匹配失败，返回-1</returns>
        public static int KmpMatch(string s, string t)
        {
            char[] SArr = s.ToCharArray();
            char[] TArr = t.ToCharArray();
            int[] next = GetNextArray(TArr);
            int i = 0, j = 0;
            while (i < SArr.Length && j < TArr.Length)
            {
                if (j == -1 || SArr[i] == TArr[j])
                {
                    i++; j++;
                }
                else
                    j = next[j];
            }
            if (j == TArr.Length)
                return i - j;
            else
                return -1;
        }
    }
}
