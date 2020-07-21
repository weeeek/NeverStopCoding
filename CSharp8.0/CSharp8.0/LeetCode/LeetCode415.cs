using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode415
    {
        /// <summary>
        /// 给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。
        /// num1 和num2 的长度都小于 5100.
        /// num1 和num2 都只包含数字 0-9.
        /// num1 和num2 都不包含任何前导零。
        /// 你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式。
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string AddStrings(string num1, string num2)
        {
            // int carry = 0;
            // 当使用StringBuilder时，请注意，应在构造StringBuilder对象时指明初始容量，否则默认容量是16个字符，
            // 当由于追加字符而超出默认容量时，就会分配一个新的串缓冲区，大小是原缓冲区的两倍

            /*
             * 字符串一旦创建就不可修改大小，每次使用System.String类中的方法之一时，都要在内存中创建一个新的字符串对象，
             * 这就需要为该新对象分配新的空间。在需要对字符串执行重复修改的情况下，与创建新的String对象相关的系统开销可能会非常昂贵。
             * 如果要修改字符串而不创建新的对象，则可以使用System.Text.StringBuilder类。
             * 例如当在一个循环中将许多字符串连接在一起时，使用StringBuilder类可以提升性能
             */
            //var sb = new StringBuilder(Math.Max(num1.Length, num2.Length) + 1);
            //for (int i = num1.Length - 1, j = num2.Length - 1; i >= 0 || j >= 0; i--, j--)
            //{
            //    int a = (i >= 0) ? num1.ElementAt(i) - '0' : 0;
            //    int b = (j >= 0) ? num2.ElementAt(j) - '0' : 0;
            //    int sum = a + b + carry;
            //    sb.Insert(0, sum % 10);
            //    carry = sum / 10;
            //}
            //if (carry > 0)
            //{
            //    sb.Insert(0, 1);
            //}
            //return sb.ToString();

            int maxLength = Math.Max(num1.Length, num2.Length);

            string[] result = new string[maxLength + 1];
            
            int carry = 0, l = maxLength;
            int i = num1.Length - 1, j = num2.Length - 1;

            while (i >= 0 || j >= 0 || carry != 0)
            {
                if (i >= 0)
                {
                    char a = Convert.ToChar(num1.Substring(i, 1));
                    carry += a - '0';
                    i--;
                }
                if (j >= 0)
                {
                    char b = Convert.ToChar(num2.Substring(j, 1));
                    carry += b - '0';
                    j--;
                }
                result[l] = Convert.ToString(carry % 10);
                l--;
                carry /= 10;
            }

            return string.Join("", result);
        }
    }
}
