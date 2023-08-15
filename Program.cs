using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vinos_Blancos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calling start method from controller
            Start();
            // Readline so we can observe the graph
            Console.ReadLine();

        }

        #region MODEL
        // Getting our statistics
        static int[] Statistics(int choice)
        {
            // We can choose to get either winSaleStats or years with the if statement, and int parameter in our method.
            int[] wineSaleStats = { 175134, 175388, 172818, 142709, 151437 + 35432, 152620, 150979, 152210, 149450, 154398, 150160 };
            int[] years =         { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 };
            if (choice == 0)
            {
                return wineSaleStats;
            }
            else
            {
                return years;
            }
        }

        // With this method we find out how many stars should be instead of the actual data.
        static int[] GetGraph(int[] stats)
        {
            Array.Sort(stats);
            int max = stats[stats.GetUpperBound(0)];
            int maxStar = 100;
            int[] starsGraph = new int[stats.Length];
            for (int i = 0; i < stats.Length; i++)
            {
                int star = maxStar * stats[i] / max;
                starsGraph[i] = star;
            }
            Array.Sort(starsGraph);
            return starsGraph;
        }
        #endregion MODEL

        #region CONTROLLER
        // This is our controller, here we call data from our model and gives it to view
        static void Start()
        {
            int[] statistics = Statistics(0);
            int[] starsAmount = GetGraph(statistics);
            string[] stars = GetStars(starsAmount);
            Print(stars);
        }


        #endregion CONTROLLER


        #region GUI/View
        // Creating our stars in an array.
        static string[] GetStars(int[] stars)
        {
            Array.Sort(stars);
            int maxHeight = stars[stars.GetUpperBound(0)];
            string[] starGraph = new string[stars.Length];
            for (int i = 0; i < stars.Length; i++)
            {
                int spaces = maxHeight - stars[i];
                string temp = "";
                string star = "*";
                for (int l = 0; l < stars[i]; l++)
                {
                    temp = temp + star;
                }
                
                starGraph[i] = temp;
            }
            return starGraph;
        }
        // Printing our stars and years.
        static void Print(string[] starGraph)
        {
            int[] years = Statistics(2);
            for (int x = 0; x < starGraph.Length; x++)
            {
                Console.Write(years[x] + "\t");
                Console.WriteLine(starGraph[x]);
            }
        }
        #endregion GUI/View
    }
}
