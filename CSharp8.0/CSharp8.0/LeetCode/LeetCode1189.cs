using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode1189
    {
        public static int MaxNumberOfBalloons(string text)
        {
            //int ans = 10000; String began = "balloon";
            //int[] arr = new int[26];
            //char[] textCharArr = text.ToCharArray();
            //for (int i = 0; i < textCharArr.Length; i++)
            //{
            //    arr[textCharArr[i] - 'a']++;
            //}
            //arr['l' - 'a'] = arr['l' - 'a'] / 2;//因为气球单词中l为两个，因此除2减半
            //arr['o' - 'a'] = arr['o' - 'a'] / 2;// 因为气球单词中o为两个，因此除2减半
            //int[] arrNew = new int[7];
            //for (int i = 0; i < arrNew.Length; i++)
            //{
            //    arrNew[i] = arr[began.ElementAt(i) - 'a'];
            //}

            //for (int i = 0; i < arrNew.Length; i++)
            //{
            //    ans = Math.Min(ans, arrNew[i]);
            //}
            //return ans;

            char[] charArray = text.ToCharArray();
            int[] count = new int[26];
            for (int i = 0; i < charArray.Length; i++)
            {
                int n = charArray[i] - 97;
                count[n]++;
            }
            int num = Math.Min(count[0], count[1]);
            num = Math.Min(num, count[11] / 2);
            num = Math.Min(num, count[13]);
            num = Math.Min(num, count[14] / 2);
            //num = num % 1;
            return num;
        }
    }
}
