using CalculateStops.Models;
using System;

namespace CalculateStops
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopsCalculator= new StopsCalculator();

            Console.WriteLine("Space: The Final Frontier.");
            Console.WriteLine("Hi, This is Faheem, I need to plan my next Journey.");
            Console.Write("Enter distance to cover in mega lights (MGLT) e.g. 1000000: ");
            Int64 distanceToCover = Int64.Parse(Console.ReadLine());
            Console.WriteLine($"The distance to my distination is: {distanceToCover}");
            Console.WriteLine("Wait, I am planning itenary......");

            GridResultDTO result = stopsCalculator.CalculateStops(distanceToCover.ToString());
            
            Console.WriteLine(Environment.NewLine + "...Itenary Starts..." + Environment.NewLine);

            foreach (var item in result.ResultDTO)
                Console.WriteLine("{0} :: {1} stops", item.Name, item.Value);

            Console.WriteLine(Environment.NewLine + "...Itenary Ends..." + Environment.NewLine);

            Console.WriteLine("Press any key to termincate the program ");
            Console.Read();
        }
    }
}
