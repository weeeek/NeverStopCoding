using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    public class OutInRef
    {
        public void Main() {
            /*
             * in:过程不会改写in的内容
             * out:传入的值不会被过程所读取,但过程可以写
             * ref:传入的值,过程会读,也会写
             */

            Console.WriteLine(In(1, 2, 300));
            int number;
            Console.WriteLine(Out(1, 2, out number));
            Console.WriteLine(number);

            Console.WriteLine(Ref(2,4,ref number));
            Console.WriteLine(number);

            int x = 10, y = 20, z = 30;
            var a = Final(in x,out y,ref z);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine(a);

            Console.WriteLine(Params(1, 2, 3, "4", 5, 6));
            Console.WriteLine(Params(new object[] { 1, 2, 3, "4" }));
        }

        public string In(int x, int y, in int number) {
            // number = x + y; // 无法分配倒变量，因为它是只读变量
            return $"{x} + {y} = {number}";
        }

        public string Out(int x, int y, out int number) {
            // 控制离开当前方法之前必须对out参数number赋值
            number = x + y;
            return $"{x} + {y} = {number}";
        }

        public string Ref(int x, int y, ref int number)
        {
            number = x + y;
            return $"{x} + {y} = {number}";
        }

        public int Final(in int x, out int y, ref int z) {
            y = x + z;
            z = x + y + z;
            return z + y;
        }

        public int Params(params object[] arr) {
            return arr.Length;
        }
    }
}
