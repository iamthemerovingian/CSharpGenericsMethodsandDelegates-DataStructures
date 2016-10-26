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
            var buffer = new Buffer<double>();
            
            ProcessInput(buffer);

            //var consoleOut = new Printer<double>(ConsoleWrite);
            //Action<double> print = delegate (double data)
            //{
            //    Console.WriteLine(data);
            //};

            //Action<double> print = d => Console.WriteLine(d);
            

            buffer.Dump(d => Console.WriteLine(d));

            var asInt = buffer.AsEnumerableOf<double, int>();

            Console.WriteLine("---------As as Double-------------");

            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------As Int-------------");

            foreach(var item in asInt)
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
