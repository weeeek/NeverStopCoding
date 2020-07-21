using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCodeM1611
    {
        /// <summary>
        /// 你正在使用一堆木板建造跳水板。有两种类型的木板，其中长度较短的木板长度为shorter，长度较长的木板长度为longer。
        /// 你必须正好使用k块木板。编写一个方法，生成跳水板所有可能的长度。
        /// 返回的长度需要从小到大排列。
        /// 0 < shorter <= longer
        /// 0 <= k <= 100000
        /// </summary>
        /// <returns></returns>
        public static int[] DivingBoard(int shorter, int longer, int k)
        {
            if (k == 0)
                return new int[] { };
            if (shorter == longer || k == 1)
                return new int[] { shorter * k };

            var result = new int[k + 1];
            for (int i = 0; i <= k; i++)
            {
                result[i] = shorter * (k - i) + longer * i;
            }
            return result;
        }
    }
}
