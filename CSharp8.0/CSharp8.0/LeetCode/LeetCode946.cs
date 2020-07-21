using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode946
    {
        // [1,2,3,4,5]
        // [4,5,3,2,1]
        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < popped.Length; i++)
            {
                var current = popped[i];
                var index = Array.IndexOf(pushed, current);
                // 需要pop的还在pushed里，就要把这个数和前面的都push掉，然后pop掉这个数
                if (index > -1)
                {
                    for (int j = 0; j <= index; j++)
                    {
                        stack.Push(pushed[0]);
                        pushed = pushed.Skip(1).ToArray();
                    }
                    stack.Pop();
                }
                // 已经push掉，然后找不到了
                else
                {
                    if (stack.Pop() != current) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
