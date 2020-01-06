using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public static class LeetCode858
    {
        public static int MirrorReflection(int p, int q)
        {
            int g = Gcd(p, q);
            p /= g; p %= 2;
            q /= g; q %= 2;

            if (p == 1 && q == 1) return 1;
            return p == 1 ? 0 : 2;
        }

        private static int Gcd(int a, int b)
        {
            if (a == 0) return b;
            return Gcd(b % a, a);
        }
    }
}
