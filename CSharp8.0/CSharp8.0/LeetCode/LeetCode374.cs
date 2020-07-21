using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode374
    {
        private static int pick = 3;
        private static int Guess(int n) => n switch
        {
            var N when n == pick => 0,
            var N when n < pick => 1,
            var N when n > pick => -1,
            _ => 0
        };

        public static int GuessNumber(int n)
        {
            int i = 1, j = n, current, res;
            do
            {
                if (i == j)
                    return i;
                current = i / 2 + j / 2;
                res = Guess(current);
                switch (res)
                {
                    case 1:
                        if (current == i)
                            ++i;
                        else
                            i = current;
                        break;
                    case -1:
                        if (j == current)
                            --j;
                        else
                            j = current;
                        break;
                    default:
                        break;
                }
            } while (res != 0);
            return current;
        }
    }
}
