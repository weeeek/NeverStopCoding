using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode482
    {
        /// <summary>
        /// 给定一个整数 n，返回 n! 结果尾数中零的数量。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string LicenseKeyFormatting(string S, int K)
        {
            // 124ms
            //var str = S.Replace("-", "");
            //var arr = new string[str.Length / K + 1];
            //var ys = str.Length % K;
            //arr[0] = str.Substring(0, ys);
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    arr[i] = str.Substring(ys + (i-1)* K, K);
            //}
            //return String.Join("-", arr).TrimStart('-').ToUpper();

            var s = "";
            int counter = 0;
            for (int i = S.Length - 1; i >= 0 ; i--)
            {
                var c = S.Substring(i, 1);
                if (c != "-") {
                    if (counter == K)
                    {
                        counter = 1;
                        s += "-";
                    }
                    else
                        counter++;
                    s = c.ToUpper() + s;
                }
            }
            return s;
        }
    }
}
