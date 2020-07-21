using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    /*
        给定两个字符串 s 和 t，判断它们是否是同构的。
        如果 s 中的字符可以被替换得到 t ，那么这两个字符串是同构的。
        所有出现的字符都必须用另一个字符替换，同时保留字符的顺序。两个字符不能映射到同一个字符上，但字符可以映射自己本身。
    */
    public static class LeetCode205
    {
        public static bool IsIsomorphic(string s, string t)
        {
            if (s == t)
                return true;
            Dictionary<char, char> dic = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    if (dic.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    dic[s[i]] = t[i];
                }
                else if (dic[s[i]] != t[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
