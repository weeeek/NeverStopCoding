using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharp8._0
{
    /*
     Dictionary<TKey, TValue> ()      Hashtable()

     第一、存储的数据类型

        Hashtable不是泛型的，不是类型安全的；
        Dictionary是泛型的，是类型安全的；

        Hashtable的键值都是Object类型的;
        Dictionary的键值的数据类型是可以指定的。

        也就是说如果往Hashtable里面存入Object以外的数据类型，则在取出该数据时，需要对其进行显式的类型转换，才能够正常使用。
        而Dictionary则没有这个问题。

        从这方面讲的话，Hashtable相当于Dictionary<Object,Object>


    第二、读取数据的顺序与添加数据的顺序的一致性

        Dictionary和Hashtable的读取数据的顺序和添加数据时的数据的顺序的一致性均不能够保证，或者可以说没有一致性。

        Dictionary在只添加不删除的时候能够保持读取数据的顺序和添加时候的顺序是一致的；

        但是经过删除和添加操作之后，就不能够保证读取数据的顺序和添加时候的顺序一致了。


    第三、当用一个不存在的Key值到Hashtable或者Dictionary中取值时

        对于Hashtable而言，如果用一个不存在的Key值进行取值的话，会返回一个null;

        对于Dictionary而言，如果用一个不存在的Key值进行取值的话，会引发“System.Collections.Generic.KeyNotFoundException”类型的异常。

        所以在从Dictionary或者Hashtable取值时，可以先判断Key值是否存在（用ContainsKey()方法进行判断），以防止出现预期以外的值或者异常。


    第四、线程安全性

        Dictionary不是线程安全的，Hashtable是线程安全的。
     */
    public class DictionaryAndHashtable
    {
        static Hashtable _Hashtable;
        static Dictionary<string, object> _Dictionary;
        public void Main(int[] numbers)
        {
            Compare(10);
            Compare(10000);
            Compare(5000000);
            Console.ReadLine();
        }
        public static void Compare(int dataCount)
        {
            Console.WriteLine("-------------------------------------------------\n");
            _Hashtable = new Hashtable();
            _Dictionary = new Dictionary<string, object>();
            Stopwatch stopWatch = new Stopwatch();
            //HashTable插入dataCount条数据需要时间
            stopWatch.Start();
            for (int i = 0; i < dataCount; i++)
            {
                _Hashtable.Add("Str" + i.ToString(), i);
            }
            stopWatch.Stop();
            Console.WriteLine(" HashTable插入" + dataCount + "条数据需要时间：" + stopWatch.Elapsed);
            //Dictionary插入dataCount条数据需要时间
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < dataCount; i++)
            {
                _Dictionary.Add("Str" + i.ToString(), i);
            }
            stopWatch.Stop();

            Console.WriteLine("Dictionary插入" + dataCount + "条数据需要时间：" + stopWatch.Elapsed);
            //Dictionary插入dataCount条数据需要时间
            stopWatch.Reset();
            int si = 0; stopWatch.Start(); for (int i = 0; i < _Hashtable.Count; i++) { si++; }
            stopWatch.Stop();
            Console.WriteLine(" HashTable遍历时间：" + stopWatch.Elapsed + " ,遍历采用for方式");
            //Dictionary插入dataCount条数据需要时间
            stopWatch.Reset();
            si = 0;
            stopWatch.Start();
            foreach (var s in _Hashtable)
            {
                si++;
            }
            stopWatch.Stop();
            Console.WriteLine(" HashTable遍历时间：" + stopWatch.Elapsed + " ,遍历采用foreach方式");
            //Dictionary插入dataCount条数据需要时间           
            stopWatch.Reset();
            si = 0;
            stopWatch.Start();
            IDictionaryEnumerator _hashEnum = _Hashtable.GetEnumerator();
            while (_hashEnum.MoveNext()) { si++; }
            stopWatch.Stop();
            Console.WriteLine(" HashTable遍历时间：" + stopWatch.Elapsed + " ,遍历采用HashTable.GetEnumerator()方式");
            //Dictionary插入dataCount条数据需要时间            
            stopWatch.Reset();
            si = 0;
            stopWatch.Start();
            for (int i = 0; i < _Dictionary.Count; i++)
            { si++; }
            stopWatch.Stop();
            Console.WriteLine("Dictionary遍历时间：" + stopWatch.Elapsed + " ,遍历采用for方式");
            //Dictionary插入dataCount条数据需要时间        
            stopWatch.Reset();
            si = 0;
            stopWatch.Start();
            foreach (var s in _Dictionary)
            {
                si++;
            }
            stopWatch.Stop();
            Console.WriteLine("Dictionary遍历时间：" + stopWatch.Elapsed + " ,遍历采用foreach方式");
            //Dictionary插入dataCount条数据需要时间        
            stopWatch.Reset();
            si = 0;
            stopWatch.Start();
            _hashEnum = _Dictionary.GetEnumerator();
            while (_hashEnum.MoveNext()) { si++; }
            stopWatch.Stop();
            Console.WriteLine("Dictionary遍历时间：" + stopWatch.Elapsed + " ,遍历采用Dictionary.GetEnumerator()方式");
            Console.WriteLine("\n-------------------------------------------------");

            /*
             从上面的结果可以看出

　　　　        1.HashTable大数据量插入数据时需要花费比Dictionary大的多的时间。

　　　　        2.for方式遍历HashTable和Dictionary速度最快。

　　　　        3.在foreach方式遍历时Dictionary遍历速度更快。

　　        在单线程的时候使用Dictionary更好一些，多线程的时候使用HashTable更好。

　　　　        因为HashTable可以通过Hashtable tab = Hashtable.Synchronized(new Hashtable());获得线程安全的对象。

             */
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(_Dictionary[$"Str{_Dictionary.Count - i}"]);
            }
            Console.WriteLine("Dictionary Find时间：" + stopWatch.Elapsed);
            stopWatch.Stop();

            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(_Hashtable[$"Str{_Dictionary.Count - i}"]);
            }
            Console.WriteLine(" Hashtable Find时间：" + stopWatch.Elapsed);
            stopWatch.Stop();

            /*
                数组：
                    在初始化时必须指定其大小和类型，他在内存中是连续存储的，所以可以看出数组的索引速度是非常快的。
                    在确定了数组的长度和类型后，选择数组存储数据是比较好的选择。不适合插入操作。

　　            ArrayList：
                    在初始化的时候不需要指定其大小和类型。
                    他可以存储不同的数据类型，但是在存取得过程中会引起装箱和拆箱，降低了性能。插入操作方便。

　　            List：
                    在初始化的时候必须指定其类型，但是不需要指定大小，所以他不会像ArraryList那样在存取过程中引起装箱和拆箱操作。
                    在类型相同的情况下，List和数组的性能相当。插入操作方便。

　　            Dictionary：
                    在初始化的时候也必须指定其类型，而且他还需要指定一个Key,并且这个Key是唯一的。
                    正因为这样，Dictionary的索引速度非常快。
                    但是也因为他增加了一个Key,Dictionary占用的内存空间比其他类型要大。
                    他是通过Key来查找元素的，元素的顺序是不定的。


                类型	 确定大小	确定类型	索引速度	性能
                数组	    Y	       Y	      很快	    最高
                ArrayList   N	       N       	  一般       低
                List	    N	       Y     	  很快   	 高
                Dictionary	N	       Y    	  最快  	一般
                HashTable	N	       N    	  最快  	一般
             */
        }
    }

}
