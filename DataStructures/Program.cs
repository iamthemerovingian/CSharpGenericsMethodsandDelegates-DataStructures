using System;

namespace DataStructures
{
    class Program
    {
        static void ConsoleWrite(double data)
        {
            Console.WriteLine(data);
        }
        static void Main(string[] args)
        {
            Action<bool> print = d => Console.WriteLine(d);
            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x, y) => x + y;
            Predicate<double> isLessThanTen = d => d < 10;
            
            print(isLessThanTen(square(add(3,5))));

            //var consoleOut = new Printer<double>(ConsoleWrite);
            //Action<double> print = delegate (double data)
            //{
            //    Console.WriteLine(data);
            //};

            //Action<double> print = d => Console.WriteLine(d);


            var buffer = new Buffer<double>();
            ProcessInput(buffer);
            buffer.Dump(d => Console.WriteLine(d));

            Console.WriteLine("-----------As as Double-------------");

            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------As date-------------");

            Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);

            var asDates = buffer.Map(converter);

            foreach (var item in asDates)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------As date with only labda expression-------------");

            var adDatewithLambda = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));

            foreach (var item in adDatewithLambda)
            {
                Console.WriteLine(item);
            }

            ProcessBuffer(buffer);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
