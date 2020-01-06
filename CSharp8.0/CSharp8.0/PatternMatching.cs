using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0
{
    /// <summary>
    /// 模式匹配 switch
    /// </summary>
    public class PatternMatching
    {
        public void Main() { 

        }

        public static int SumPositiveNumbers(IEnumerable<object> sequence)
        {
            int sum = 0;
            foreach (var i in sequence)
            {
                switch (i)
                {
                    // 常见的常量模式
                    case 0:
                        break;
                    // 类型模式
                    // 自 C# 7.1 起，is 和 switch 类型模式的模式表达式的类型可能为泛型类型参数。 
                    // 这可能在检查 struct 或 class 类型且要避免装箱时最有用
                    case IEnumerable<int> childSequence:
                        {
                            foreach (var item in childSequence)
                                sum += (item > 0) ? item : 0;
                            break;
                        }
                    // 具有附加 when 条件的类型模式
                    case int n when n > 0:
                        sum += n;
                        break;
                    case int n when n < 0:
                        sum -= n;
                        break;
                    // null 模式
                    case null:
                        throw new NullReferenceException("Null found in sequence");
                    // 常见的默认事例
                    default:
                        throw new InvalidOperationException("Unrecognized type");
                }
            }
            return sum;
        }
    }

    public class Square
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }
    }
    public class Circle
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public struct Rectangle
    {
        public double Length { get; }
        public double Height { get; }

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }
    public class Triangle
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
}
