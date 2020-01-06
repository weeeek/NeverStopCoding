using System.Collections.Generic;

namespace CSharp8._0
{
    public class ContravariantAndCovariant
    {
        /*
         可变性是以一种类型安全的方式，将一个对象当做另一个对象来使用。
         如果不能将一个类型替换为另一个类型，那么这个类型就称之为：不变量。
         协变和逆变是两个相互对立的概念：
            如果某个返回的类型可以由其派生类型替换，那么这个类型就是支持协变的
            如果某个参数类型可以由其基类替换，那么这个类型就是支持逆变的。
        */
        public void Main()
        {
            Bird bird1 = new Bird();
            Bird bird2 = new Sparrow();
            Sparrow sparrow1 = new Sparrow();

            //Sparrow sparrow2 = new Bird();//这个是编译不通过的，违反了继承性。

            // 但是我们放在集合中，去实例化，是无法通过的

            List<Bird> birdList0 = new List<Bird>();

            // List<Bird> birdList2 = new List<Sparrow>();
            // ↑不是父子关系，没有继承关系。     隐式转换报错

            //一群麻雀一定是一群鸟

            /*
             那么我们如何去实现在泛型中的继承性呢？
             这就引入了协变和逆变得概念，为了保证类型的安全，C#编译器对使用了 out 和 in 关键字的泛型参数添加了一些限制：
                支持协变(out)的类型参数只能用在输出位置：函数返回值、属性的get访问器以及委托参数的某些位置
                支持逆变(in)的类型参数只能用在输入位置：方法参数或委托参数的某些位置中出现。

             “System.Collections.Generic”命名空间下的IEnumerable泛型 接口，会发现他的泛型参数使用了out
            
                上述实例使用 IEnumerable  接口，会发现，我们的泛型有了继承关系。
             */

            IEnumerable<Bird> birdList1 = new List<Bird>();

            //协变  在泛型中，子类指向父类，我们称为协变
            IEnumerable<Bird> birdList2 = new List<Sparrow>();
            // List<Bird> birdList2 = new List<Sparrow>().Select(c => (Bird)c).ToList(); // 4.0以前的写法

            // 自己定义的泛型接口和泛型类进行实例化，编译通过
            ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
            ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            //这也是能编译的，在泛型中，子类指向父类，我们称为协变

            // IEnumerable<Sparrow> birdList3 = new List<Bird>();
            // ↑逆变的泛型参数是不能作为泛型方法的返回值的。

            ICustomerListIn<Sparrow> customerList4 = new CustomerListIn<Sparrow>();
            ICustomerListIn<Sparrow> customerList3 = new CustomerListIn<Bird>(); //逆变 父类指向子类

            ICustomerListIn<Bird> birdList5 = new CustomerListIn<Bird>();
            birdList5.Show(new Sparrow());
            birdList5.Show(new Bird());

            /*
             总结
                逆变与协变只能放在泛型接口和泛型委托的泛型参数里面，

                在泛型中out修饰泛型称为协变，协变（covariant）    修饰返回值，  协变的原理是把子类指向父类的关系，拿到泛型中。
                在泛型中in 修饰泛型称为逆变，逆变（contravariant）修饰传入参数，逆变的原理是把父类指向子类的关系，拿到泛型中。


             NET 中自带的协变逆变泛型
            	 类别	 名称
            	 接口	 IEnumerable<out T> 
            	 委托	 Action<in T>
            	 委托	 Func<out TResult>
             	 接口	 IReadOnlyList<out T> 
            	 接口	 IReadOnlyCollection<out T>

            值类型不能协变和逆变
             */
        }
    }

    /// <summary>
    /// 鸟
    /// </summary>
    public class Bird
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// 麻雀
    /// </summary>
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// out 协变 只能是返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T>
    {
        T Get();
        // 在泛型协变的时候，泛型不能作为方法的参数。
        // void Show(T t);//T不能作为传入参数
    }

    /// <summary>
    /// 类没有协变逆变
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void Show(T t)
        {

        }
    }

    /// <summary>
    /// 逆变
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T>
    {
        //T Get();//不能作为返回值

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void Show(T t)
        {
        }
    }
}
