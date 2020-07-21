using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp8._0
{
    public static class LeetCode15
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            // 排序
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int k = 0; k < nums.Length - 2; k++)
            {
                // 最小的数一定是负的，所以第一个数为正数的时候，从K位开始，到最后都没有可能的结果，直接中断循环
                if (nums[k] > 0) break;
                // 与上一次的第一个数一样，跳过这次检索
                if (k > 0 && nums[k] == nums[k - 1]) continue;
                // i左边界，j右边界
                int i = k + 1, j = nums.Length - 1;
                while (i < j)
                {
                    int sum = nums[k] + nums[i] + nums[j];
                    if (sum < 0)
                    {
                        while (i < j && nums[i] == nums[++i]) ;
                    }
                    else if (sum > 0)
                    {
                        while (i < j && nums[j] == nums[--j]) ;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[k], nums[i], nums[j] });
                        // i和后面一个数一样大
                        while (i < j && nums[i] == nums[++i]) ;
                        // j和前面一个数一样大
                        while (i < j && nums[j] == nums[--j]) ;
                    }
                }
            }
            return res;
        }
    }
}
