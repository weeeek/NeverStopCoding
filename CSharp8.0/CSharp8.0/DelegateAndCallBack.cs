using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    public static class Delegates
    {
        public delegate void AreaDelegate(double length, double width);
        public static void Run()
        {
            double length = 2;
            double width = 5;
            AreaDelegate areaDelegate = delegate
            {
                Console.WriteLine("长方形的面积为：" + length * width);
            };
            areaDelegate(length, width);
        }
    }

    public static class CallBacks //用户层，执行输入等操作
    {
        public static void Run()
        {
            int result1 = DeleageClass<int, int>.Do(1, FunctionClass.GetSum);

            Console.WriteLine("处理后返回结果：" + result1);

            Console.ReadKey();
        }
    }

    static class FunctionClass //开发层处理，开发人员编写具体的计算方法
    {
        public static int GetSum(int result)
        {
            Console.WriteLine("调用了开发人员的函数");
            result++;
            return result;
        }
    }

    #region 实际开发中，下面这个类会封装起来，只提供函数接口。相当于系统底层
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">返回类型</typeparam>
    /// <typeparam name="R">传入类型</typeparam>
    static class DeleageClass<T, R>
    {
        public delegate T CallBack(R Request);

        //将传入参数在系统底层进行某种处理，具体计算方法由开发者开发，函数仅提供执行计算方法后的返回值
        public static T Do(R Request, CallBack callBack)
        {
            // ToDo：某种处理
            return callBack(Request);//调用传入函数的一个引用
        }
        //可以封装更多的业务逻辑方法

    }
    #endregion
}
