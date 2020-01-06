using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    public class StringBuilderAndString
    {
        public void Main()
        {
            // 一个string实例是不可变的。创建后便无法更改。更改字符串的任何操作都将返回一个新实例：

            Console.WriteLine("string:" + ActionExtension.Profiler(() => InitString(), 1000));

            // 使用StringBuilder的相同示例：
            Console.WriteLine("StringBuilder:" + ActionExtension.Profiler(() => InitStringBuilder(), 1000));

            // 这样可以减轻内存分配器的压力



            /*
             * 关于string类型的一些琐碎知识：
                string类型是.NET Framework 中String的别名。
                string类型其实是一个数组，我们可以使用[]，来找到一个字符串中的某个字符，
                    比如：string str="abcdef"; str[1]就是b,注意str[1]是Char类型的字符。
                string类型是引用类型。
                    对于连接字符串，我们使用 + 号，比如 string a="as"; a=a+"df"; 这个时候a就是asdf；
                对于string类型，关系运算符 “==”和“！=”，我们比较的是string定义的值，而不是其引用的值。
                    比如：
             */

            string a = "hello";
            string b = "h";
            b = b + "ello";
            Console.WriteLine(a == b);
            Console.WriteLine((object)a == (object)b);
            Console.ReadKey();

            /*
             * string类型有个重要的特性：就是不可变性，因为string是引用类型，
             * 我们定义一个string类型的时候，定义的值就是堆内存中的某个存储的值的地址，
             * 虽然我们可以改变string的值，
             *   
             *   比如string a="string1",a="string2"，a的值的确是变了，但是它此时在堆内存中的引用已经变了，不是string1的引用，而是string2的引用，
             *   string1与string2指向的是不同的堆内存位置，
             *   这就是string类型的不可变性。
             *   这也是为什么我们会使用StringBuilder类的原因，
             *   因为当我们改变string类型定义的值的时候，相当于我们换了一块堆内存，
             *   然后原先的堆内存就会等待着被GC回收掉，这无形中就消耗了性能。
           
             *  StringBuilder类型是一个可变字符串类，可变性意味着，一旦创建类的实例后，可以修改通过追加、 删除、 替换或插入字符。
             *  一个 StringBuilder 对象会维护一个缓冲区(默认16个字符)来容纳扩展到字符串。
             *  如果没有可用空间，将新数据追加到缓冲区否则为系统会分配新的、 更大的缓冲区、 从原始缓冲区的数据复制到新的缓冲区和新的数据则追加到新的缓冲区。
             *     比如，我们在创建一个StringBuilder类型的实例的时候给它16大小的空间，如果16不够，那么它就会自动的增加到32，也就是2倍，
             *     但是不会创建新的实例，也就没有了频繁GC，所以性能损耗就会减少。
             *  
             *  请考虑在以下情况下使用 String 类：
             *     当你的应用将对字符串进行的更改数量很小时。
             *         在这些情况下，StringBuilder 可能会对 String提供可忽略或不会提高性能。
             *     当你执行固定数量的串联操作时，尤其是字符串文本。 
             *         在这种情况下，编译器可能会将串联操作合并为单个操作。
             *     在生成字符串时，必须执行大量的搜索操作。 
             *         StringBuilder 类缺少搜索方法，如 IndexOf 或 StartsWith。
             *         必须将 StringBuilder 对象转换为这些操作的 String，这可能会使使用 StringBuilder时的性能优势抵消。
             *         
             *  请考虑在以下情况下使用 StringBuilder 类：
             *     希望应用在设计时对字符串进行未知数量的更改（例如，当使用循环来连接包含用户输入的随机数量的字符串时）。
             *     希望应用对字符串进行大量更改时。
             */
        }


        // 在此处创建20001个字符串，其中的20000个将被丢弃。
        public void InitString()
        {
            string s = string.Empty;
            for (var i = 0; i < 10000; i++)
            {
                s += i.ToString() + " ";
            }
        }

        public void InitStringBuilder() {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < 10000; i++)
            {
                sb.Append(i);
                sb.Append(' ');
            }
        }
    }
}
