using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    //public delegate void Printer<T>(T data);

    public static class BufferExtensions
    {
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            Console.WriteLine("----------BufferExtension-----------");
            foreach (var item in buffer)
            {
                print(item);
            }
        }
        public static IEnumerable<Toutput> AsEnumerableOf<T, Toutput>(this IBuffer<T> Buffer) // This IBuffer<T> Buffer is that it is an extension method of IBuffer<T>.
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));

            foreach (var item in Buffer)
            {
                Toutput result = (Toutput)converter.ConvertTo(item, typeof(Toutput));
                yield return result;
            }
        }
        public static IEnumerable<Toutput> Map<T, Toutput>(this IBuffer<T> Buffer, Converter<T, Toutput> converter) // This IBuffer<T> Buffer is that it is an extension method of IBuffer<T>.
        {
            return Buffer.Select(i => converter(i));
        }

    }
}
