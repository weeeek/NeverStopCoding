using System.Text;

namespace CSharp8._0
{
    public static class LeetCode6
    {
        /// <summary>
        /// 给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。
        /// 请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。
        /// 你可以假设 nums1和 nums2不会同时为空。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Convert(string s, int numRows)
        {
            if (s.Length < numRows || numRows == 1)
                return s;
            StringBuilder result = new StringBuilder(s.Length);
            // 行
            for (int i = 0; i < numRows; i++)
            {
                var index = i;
                while (index < s.Length)
                {
                    // 最左边
                    result.Append(s[index]);
                    index = index + 2 * (numRows - 1);
                    if (i > 0 && i < numRows - 1 && index - i * 2 < s.Length)
                    {
                        result.Append(s[index - i * 2]);
                    }
                }
            }
            return result.ToString();

            // ↓别人的
            StringBuilder res = new StringBuilder(s);
            if (s.Length < numRows || numRows == 1) { return res.ToString(); }
            int step = 2 * numRows - 2;
            int k = 0;
            for (int i = 0; i < numRows; ++i)
            {
                int left = step - 2 * i;
                int right = 2 * i;

                int idx = i;
                res[k++] = s[idx];
                while (true)
                {
                    if (left != 0)
                    {
                        idx += left;
                        if (idx >= s.Length) break;
                        res[k++] = s[idx];
                    }

                    if (right != 0)
                    {
                        idx += right;
                        if (idx >= s.Length) break;
                        res[k++] = s[idx];
                    }
                }
            }
            return res.ToString();
        }
    }
}
