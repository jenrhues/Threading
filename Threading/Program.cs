/*
 * Name: Jennifer Huestis
 * Date: 03/12/2020
 * File: Program.cs
 * Description: 
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Welcome to Jennifer's Amazing Pi Calculator!\nHere, you will throw darts at 1/4 of a dart board" +
                " for a specified number of threads to calculate Pi.\nHow many darts would you like to throw?");
            int dartTotal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many threads would you like to run?");
            int threadTotal = Int32.Parse(Console.ReadLine());

            List<Thread> thread = new List<Thread>();
            List<FindPiThread> findPiThread = new List<FindPiThread>();

            Console.WriteLine("Running calculations...\n");
            for (int i = 0; i < threadTotal; i++) {
                FindPiThread piSimulation = new FindPiThread(dartTotal);
                findPiThread.Add(piSimulation);
                Thread piThread = new Thread(new ThreadStart(piSimulation.throwDarts));
                thread.Add(piThread);
                piThread.Start();
                Thread.Sleep(16);
            }
            for (int i = 0; i < thread.Count; i++)
            {
                thread[i].Join();
            }
            int dartCount = 0;
            for (int i = 0; i < findPiThread.Count; i++)
            {
                dartCount += findPiThread[i].GetDartCount();
            }
            double Pi = 4.0 * (dartCount / Convert.ToDouble(dartTotal * threadTotal));
            Console.WriteLine("Your Pi estimation is " + Pi + " for " + dartTotal + " darts in " + threadTotal + " threads!\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    class FindPiThread
    {
        int dartsToThrow;
        int countDarts;
        Random rand;
        public FindPiThread(int dartsToThrow)
        {
            this.dartsToThrow = dartsToThrow;
            countDarts = 0;
            rand = new Random();
        }
        public int GetDartCount()
        {
            return countDarts;
        }
        public void throwDarts()
        {
            for (int i = 0; i < dartsToThrow; i++)
            {
                double X = rand.NextDouble();
                double Y = rand.NextDouble();
                double hypotenuse = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
                if (hypotenuse <= 1.0)
                {
                    countDarts++;
                }
            }
        }
    }

}