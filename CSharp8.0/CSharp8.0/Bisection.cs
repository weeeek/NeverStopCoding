using System;
using System.Collections.Generic;
using System.Text;
using MySqlX.XDevAPI.CRUD;

namespace CSharp8._0
{
    /*
     二分法（Bisection method） 即一分为二的方法. 
    当数据量很大适宜采用该方法。采用二分法查找时，数据需是排好序的。

    基本思想：
        假设数据是按升序排序的，对于给定值key，从序列的中间位置k开始比较，
        如果当前位置arr[k]值等于key，则查找成功；
        若key小于当前位置值arr[k]，则在数列的前半段中查找,arr[low,mid-1]；
        若key大于当前位置值arr[k]，则在数列的后半段中继续查找arr[mid+1,high]，
        直到找到为止,时间复杂度:O(log(n))
     */
    public static class Bisection
    {
        // 一个长度为n-1的递增排序数组中的所有数字都是唯一的，并且每个数字都在范围0～n-1之内。
        // 在范围0～n-1内的n个数字中有且只有一个数字不在该数组中，请找出这个数字。

        public static int MissingNumber(int[] nums)
        {
            int i = 0, j = nums.Length - 1;
            while (i <= j)
            {
                int m = (i + j) / 2;
                if (nums[m] == m) i = m + 1;
                else j = m - 1;
            }
            return i;
        }
    }
}
