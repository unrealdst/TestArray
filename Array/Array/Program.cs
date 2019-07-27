using System;
using System.Linq;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inProgress = true;
            var generator = new ArrayGenerator();
            do
            {
                Console.WriteLine("What size array generate:");
                string input = Console.ReadLine();
                int size = 0;
                if (int.TryParse(input, out size))
                {
                    int[] array = generator.Generate(size);

                    Console.WriteLine($"Size: {array.Count()}, Array: {String.Join(", ", array)}");
                }
                else
                {
                    Console.WriteLine("Please put valid number");
                }

                Console.WriteLine("Press 'y' to continue");

                var key = Console.ReadKey();
                if (key.KeyChar != 'y')
                {
                    inProgress = false;
                }
                Console.WriteLine();
            } while (inProgress);

        }
    }
}
