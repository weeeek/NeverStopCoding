using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode43
    {
        public static string Multiply(string num1, string num2)
        {
            //if (num1 == "0" || num2 == "0")
            //{
            //    return "0";
            //}
            //int[] res = new int[num1.Length + num2.Length];
            //for (int i = num1.Length - 1; i >= 0; i--)
            //{
            //    for (int j = num2.Length - 1; j >= 0; j--)
            //    {
            //        int sum = res[i + j + 1] + (num1.ElementAt(i) - '0') * (num2.ElementAt(j) - '0');
            //        res[i + j + 1] = sum % 10;
            //        res[i + j] += sum / 10;
            //    }
            //}

            //StringBuilder result = new StringBuilder(res.Length);
            //for (int i = 0; i < res.Length; i++)
            //{
            //    if (i == 0 && res[i] == 0) continue;
            //    result.Append(res[i]);
            //}
            //return result.ToString();

            string shorter, longer;
            int[] ans = new int[num1.Length + num2.Length];
            if (num1.Length < num2.Length) { shorter = num1; longer = num2; }
            else { shorter = num2; longer = num1; }
            int insertPos = 0, length = 0, validPos = 0;
            for (int i = shorter.Length - 1; i >= 0; --i) { length = Insert(ans, insertPos, shorter[i], longer); ++insertPos; }
            for (int i = length; i >= 0; --i) { if (ans[i] != 0) { validPos = i; break; } }
            StringBuilder strBuilder = new StringBuilder(validPos + 1);
            for (int i = validPos; i >= 0; --i) { strBuilder.Append((char)(ans[i] + '0')); };
            /*
            string str = "";
            for (int i = validPos; i >= 0; --i) { str += ("" + (char)(ans[i] + '0')); }
            */
            return strBuilder.ToString();
        }

        private static int Insert(int[] ansList, int startIndex, char mulCof, string longer)
        {
            for (int pos = longer.Length - 1; pos >= 0; --pos)
            {
                int mulResult = (longer[pos] - '0') * (mulCof - '0');
                ansList[startIndex] += mulResult;
                ansList[startIndex + 1] += ansList[startIndex] / 10;
                ansList[startIndex] %= 10;
                ++startIndex;
            }
            if (ansList[startIndex] == 0) return startIndex - 1;
            return startIndex;
        }
    }
}
