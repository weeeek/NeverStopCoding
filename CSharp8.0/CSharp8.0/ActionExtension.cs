using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharp8._0
{
    public static class ActionExtension
    {
        public static string Profiler(this Action func, int runcount)
        {
            Stopwatch watch = Stopwatch.StartNew();//创建一个监听器
            MemoryWatcher mWatcher = new MemoryWatcher();
            mWatcher.startWatch();
            for (int i = 0; i < runcount; i++)
            {
                func();//执行某个方法
            }
            watch.Stop();
            mWatcher.stoptWatch();

            float sec = watch.ElapsedMilliseconds;
            float freq = sec / runcount;

            return string.Format("总体执行时间为:{0}ms,总体执行次数为:{1},平均执行时间为:{2}ms", sec, runcount, freq);
        }
    }

    /// <summary>
    /// 监视类
    /// </summary>
    public class MemoryWatcher
    {
        long size;
        public void startWatch()
        {
            size = 0;
            size = GC.GetTotalMemory(true);
        }
        public void stoptWatch()
        {
            var latersize = GC.GetTotalMemory(true);
            latersize = latersize - size;
            switch (latersize)
            {
                case var n when n > 1024 * 1024:
                    Console.WriteLine("分配内存:" + (latersize / (1024 * 1024)).ToString() + "MB");
                    break;
                case var n when n > 1024:
                    Console.WriteLine("分配内存:" + (latersize / 1024).ToString() + "KB");
                    break;
                default:
                    Console.WriteLine("分配内存:" + (latersize).ToString() + "B");
                    break;
            }
        }
    }
}
