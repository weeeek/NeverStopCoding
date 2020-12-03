using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    /*
        假设你有 n 个版本 [1, 2, ..., n]，你想找出导致之后所有版本出错的第一个错误的版本。

        你可以通过调用 bool isBadVersion(version) 接口来判断版本号 version 是否在单元测试中出错。实现一个函数来查找第一个错误的版本。你应该尽量减少对调用 API 的次数。
    */
    public class LeetCode278 : VersionControl
    {
        public static int FirstBadVersion(int n)
        {
            // 最大的正确版本，最小的错误版本（第一个正确版本）
            int max = 1, min = n;
            while (max < min) {
                int index = max + (min - max) / 2;
                if (isBadVersion(index))
                    min = index;
                else
                    max = index + 1;
            }
            return max;
        }
    }

    public class VersionControl {
        public static bool isBadVersion(int n) {
            return n == 4;
        }
    }
}
