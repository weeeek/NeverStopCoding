using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8._0.Helper
{

    public class DateRange
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Range<T> where T : IComparable<T>
    {
        protected T FromValue;
        protected T ToValue;

        public Range()
        {

        }

        public Range(T from, T to)
        {
            if (from.CompareTo(to) > 0)
            {
                throw new Exception($"无效的参数, 起始值{from}必须小于等于结束值{to}");
            }

            FromValue = from;
            ToValue = to;
        }

        public virtual T From
        {
            get => FromValue;
            protected set => FromValue = value;
        }

        public virtual T To
        {
            get => ToValue;
            protected set => ToValue = value;
        }

        public virtual bool Contains(T value)
        {
            return value.CompareTo(From) >= 0 && To.CompareTo(value) >= 0;
        }

        public virtual bool Contains(Range<T> value)
        {
            return Contains(value.From) || Contains(value.To);
        }

        public T[] Values => new[] { From, To };

    }
}
