using System;

namespace CSharp8._0
{
    public class ConstAndStatic
    {
        //A为运行时常量
        public static readonly int A = 2;
        //B为编译时常量
        public const int B = 3;


        //数据类型支持
        // 由于const常量在编译时将被替换为字面量，使得其取值类型受到了一定限制。const常量只能被赋予数字(整数、浮点数)、字符串以及枚举类型。
        // public const DateTime D = DateTime.MinValue;

        public readonly DateTime D = DateTime.MinValue;

        /// <summary>
        /// 静态常量(const)和动态常量(static和readonly)用法和区别
        /// </summary>
        public void Main()
        {
            /*
             * C#中有两种常量类型，分别为readonly(运行时常量)与const(编译时常量)
             * readonly为运行时常量，程序运行时进行赋值，赋值完成后便无法更改，因此也有人称其为只读变量。
             * const为编译时常量，程序编译时将对常量值进行解析，并将所有常量引用替换为相应值。
             */


            int C = A + B;
            // 经过编译后与下面的形式等价：
            // int C = A + 3;

            /*
             * 其中的const常量B被替换成字面量3，而readonly常量A则保持引用方式。
               声明及初始化
                readonly常量只能声明为类字段，支持实例类型或静态类型，可以在声明的同时初始化或者在构造函数中进行初始化，初始化完成后便无法更改。
                const常量除了可以声明为类字段之外，还可以声明为方法中的局部常量，默认为静态类型(无需用static修饰，否则将导致编译错误)，但必须在声明的同时完成初始化。
                
            
            
               性能比较
                const直接以字面量形式参与运算，性能要略高于readonly，但对于一般应用而言，这种性能上的差别可以说是微乎其微。

               适用场景
                在下面两种情况下：
                    a.取值永久不变(比如圆周率、一天包含的小时数、地球的半径等)
                    b.对程序性能要求非常苛刻
                可以使用const常量，除此之外的其他情况都应该优先采用readonly常量。


                const: 用const修饰符声明的成员叫常量，是在编译期初始化并嵌入到客户端程序 
                static readonly: 用static readonly修饰符声明的成员依然是变量，只不过具有和常量类似的使用方法：通过类进行访问、初始化后不可以修改。但与常量不同的是这种变量是在运行期初始化。
             */

        }
    }
}
