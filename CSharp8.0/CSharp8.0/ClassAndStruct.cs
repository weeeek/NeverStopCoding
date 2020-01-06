using System;
using System.Linq;
using System.Linq.Expressions;
using CSharp8._0.Model;

namespace CSharp8._0
{
    public class ClassAndStruct
    {
        /*
         * https://www.cnblogs.com/to-creat/p/4944911.html
         * 1，class 是引用类型，struct是值类型
        
         * Men men = null;
         * Boy boy = null;        // error
         * 既然class是引用类型，class可以设为null。
         * 但是我们不能将struct设为null,因为它是值类型。


         * 2，当你实例化一个class，它将创建在堆上。而你实例化一个struct，它将创建在栈上

         **** 3，你使用的是一个对class实例的引用。而你使用的不是对一个struct的引用。（而是直接使用它们）

         **** 4，当我们将class作为参数传给一个方法，我们传递的是一个引用。struct传递的是值而非引用。
        
         * 7，类使用前必须new关键字实例化，Struct不需要
         
         * 8，class支持继承和多态，struct不支持. 注意：但是struct 可以和类一样实现接口

         * 9，既然struct不支持继承，其成员不能以protected 或Protected Internal 修饰

         * 12，class比较适合大的和复杂的数据，struct适用于作为经常使用的一些数据组合成的新类型。

         **** 适用场合：struct有性能优势，class有面向对象的扩展优势。

         * 用于底层数据存储的类型设计为struct类型，将用于定义应用程序行为的类型设计为Class。
         * 如果对类型将来的应用情况不能确定，应该使用Class。
         */

        public void Main()
        {
            /*
             * 一、从赋值的角度体验struct和class的不同
                引用类型赋值，是把地址赋值给了变量
            */






            SizeClass oldSizeClass = new SizeClass() { Width = 10 };
            Console.WriteLine("赋值前：width={0}", oldSizeClass.Width); // 10

            SizeClass newSizeClass = new SizeClass() { Width = oldSizeClass.Width };
            newSizeClass.Width = 30;
            Console.WriteLine("旧对象：width={0}", oldSizeClass.Width); // ？
            Console.WriteLine("新对象：width={0}", newSizeClass.Width); // ？ 

            var copyOfSizeClass = oldSizeClass;
            copyOfSizeClass.Width = 50;
            Console.WriteLine("赋值后的旧对象：width={0}", oldSizeClass.Width); // ？

            /*
             * 当把oldSizeClass赋值给copyOfSize变量的时候，是把oldSizeClass所指向的地址赋值给了copyOfSize变量，
             * 2个变量同时指向同一个地址。
             * 所以，当改变copyOfSizeClass变量的值，也相当于改变了sizeClass的值。
             */


            Console.ReadKey(false);

            SizeStruct sizeStruct = new SizeStruct() { Width = 1 };
            Console.WriteLine($"赋值前：width={sizeStruct.Width}");

            var copyOfSizeStruct = sizeStruct;
            copyOfSizeStruct.Width = 5;
            Console.WriteLine($"赋值后：width={sizeStruct.Width}");
            Console.ReadKey(false);

            Console.WriteLine("-----------Compare-----------");

            attendance_devContext db = new attendance_devContext();
            var Classes = db.ClockInfo.ToList();
            var Structs = Classes.Select(s => new ClockInfoStruct() { Type = s.Type, EmpName = s.EmpName, EmpNo = s.EmpNo }).ToList();
            var Structs2 = Classes.Select(s => new ClockInfoStructGuid() { Id = s.Id, EmpName = s.EmpName, EmpNo = s.EmpNo }).ToList();

            Console.WriteLine("----------Init Done---------");

            Func<ClockInfoStruct, bool> exp1 = s => s.EmpName == "蓝亮亮";
            Func<ClockInfo, bool> exp2 = s => s.EmpName == "蓝亮亮";
            Func<ClockInfoStructGuid, bool> exp3 = s => s.EmpName == "蓝亮亮";

            Console.WriteLine("----------Count---------");

            Console.WriteLine("Structs" + ActionExtension.Profiler(() => Structs.Count(exp1), 10));
            Console.WriteLine("Classes:" + ActionExtension.Profiler(() => Classes.Count(exp2), 10));
            Console.WriteLine("Structs2" + ActionExtension.Profiler(() => Structs2.Count(exp3), 10));
            Console.WriteLine();

            Console.ReadKey(false);

            /* struct在C#中被用来定义结构，它是一种比类小的数据类型。和类一样都是创建对象的模板，可以有自己的数据以及处理和访问数据的方法。
             * 
             * 何时使用struct，何时使用class?
             * 
             * 在多数情况下，推荐使用class类，
             * 因为无论是类的赋值、作为参数类型传递，还是返回类的实例，实际拷贝的是托管堆上引用地址，也就大概4个字节，这非常有助于性能的提升。
             *
             * 而作为struct类型，无论是赋值，作为参数类型传递，还是返回struct类型实例，是完全拷贝，会占用栈上的空间。
             * 根据Microsoft's Value Type Recommendations，在如下情况下，推荐使用struct：
                ● 小于16个字节
                ● 偏向于值，是简单数据，而不是偏向于"面向对象"
                ● 希望值不可变
            */
        }
    }

    /*
     class（类）是面向对象编程的基本概念，是一种自定义数据结构类型，通常包含字段、属性、方法、属性、构造函数、索引器、操作符等。
     在.NET中，所有的类都最终继承自System.Object类，因此是一种引用类型，
     也就是说，new一个类的实例时，在堆栈（stack）上存放该实例在托管堆（managed heap）中的地址，
     而实例的值保存在托管堆（managed heap）中。
    */
    public class Size
    {
        public int Width { get; set; }
    }
    public class SizeClass : Size
    {
        public SizeClass(int w)
        {
            Width = w;
        }
        public SizeClass() { }
    }

    /*
     struct（结构）是一种值类型，用于将一组相关的变量组织为一个单一的变量实体 。
     所有的结构都继承自System.ValueType类，因此是一种值类型，
     也就是说，struct实例在创建时分配在线程的堆栈（stack）上，它本身存储了值。
     所以在使用struct时，我们可以将其当作int、char这样的基本类型类对待。
    */

    //struct Boy: Animal { // error：接口列表中的类型"Animal"不是接口
    public struct SizeStruct
    {
        // public int Width = 1; // 5，struct 不可以有初始化器，class可以有初始化器。

        public int Width { get; set; }

        /*6，class 可以有明显的无参数构造器，但是struct不可以
        public SizeStruct() { 

        }
        */

        //10，Class的构造器不需要初始化全部字段，Struct的构造器必须初始化所有字段
        public SizeStruct(int w)
        {
            Width = w;
        }
    }
}
