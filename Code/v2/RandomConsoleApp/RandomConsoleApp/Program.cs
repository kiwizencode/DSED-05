using System;
using System.Linq;

namespace RandomConsoleApp
{
    /*
     * 
     */
    class Program
    {
        enum Doy_Size { Small, Medium, Large, Giant };
        enum Speed { Level_1, Level_2, Level_3, Level_4};

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /*
                int [] int_array = { 0, 1, 2, 3 };
            */
            //
            Doy_Size[] size_array = { Doy_Size.Small, Doy_Size.Medium, Doy_Size.Large, Doy_Size.Giant };
            Speed[] speed_array = { Speed.Level_1, Speed.Level_2, Speed.Level_3, Speed.Level_4};
            Random rnd = new Random();

            for (int count = 1; count < 5; count++)
            {
                Doy_Size[] temp = size_array.OrderBy(x => rnd.Next()).ToArray();
                Speed[] level = speed_array.OrderBy(x => rnd.Next()).ToArray();
                for (int i = 0; i < temp.Length; i++)
                    Console.Write($"{temp[i]}:{level[i]}\t");
                Console.Write("\n");
            }
            

            Console.ReadLine();
        }       
    }
}