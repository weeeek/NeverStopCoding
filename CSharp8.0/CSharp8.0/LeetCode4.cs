using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode4
    {
        /// <summary>
        /// 给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。
        /// 请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。
        /// 你可以假设 nums1和 nums2不会同时为空。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums = nums1.Concat(nums2).OrderBy(s => s).ToArray();

            var center = nums.Length / 2;
            if (nums.Length % 2 == 0) {
                return (nums[center] + nums[center + 1]) / 2.0f;
            }
            return nums[center];
        }
    }
}
