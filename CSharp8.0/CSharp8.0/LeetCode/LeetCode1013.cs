namespace CSharp8._0
{
    public static class LeetCode1013
    {
        /// <summary>
        /// 给你一个整数数组 A，只有可以将其划分为三个和相等的非空部分时才返回 true，否则返回 false。
        /// 形式上，如果可以找出索引 i+1 < j 
        /// 且满足 A[0] + A[1] + ... + A[i] == A[i + 1] + A[i + 2] + ... + A[j - 1] == A[j] + A[j - 1] + ... + A[A.length - 1] 
        /// 就可以将数组三等分。
        /// 提示：
        ///     3 <= A.length <= 50000
        ///     -10^4 <= A[i] <= 10^4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CanThreePartsEqualSum(int[] A)
        {
            var sum = 0;
            for (int a = 0; a < A.Length; a++)
            {
                sum += A[a];
            }
            if (sum % 3 != 0)
                return false;
            sum = sum / 3;
            int tmp = 0;
            int j = 0;
            for (int i = 0; i < A.Length; i++)
            {
                tmp += A[i];
                if (tmp == sum)
                {
                    j++;
                    tmp = 0;
                    switch (j) {
                        case 2:
                            return i < A.Length - 1;
                        default:
                            break;
                    }
                }
            }
            return false;
        }
    }
}
