/*
 * Name: Jennifer Huestis
 * Date: 03/12/2020
 * File: Program.cs
 * Description: This program contains two classes, Program and FindPiThread, that work together to calculate pi by throwing darts
 *  at a dart board. A circle is inscribed in the square dart board, which is the area that is equal to pi.
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

            //initializes threads
            List<Thread> thread = new List<Thread>();
            List<FindPiThread> findPiThread = new List<FindPiThread>();

            Console.WriteLine("Running calculations...\n");
            
            //sets up threads and starts them
            for (int i = 0; i < threadTotal; i++) {
                FindPiThread piSimulation = new FindPiThread(dartTotal);
                findPiThread.Add(piSimulation);
                Thread piThread = new Thread(new ThreadStart(piSimulation.throwDarts));
                thread.Add(piThread);
                piThread.Start();
                Thread.Sleep(16); //pauses Main() for 16ms
            }

            //forces Main() to wait until each thread is completed
            for (int i = 0; i < thread.Count; i++)
            {
                thread[i].Join();
            }

            //adds total dart count inside circle from each thread 
            int dartCount = 0;
            for (int i = 0; i < findPiThread.Count; i++)
            {
                dartCount += findPiThread[i].GetDartCount();
            }

            //calculates pi and prints to console
            double Pi = 4.0 * (dartCount / Convert.ToDouble(dartTotal * threadTotal));
            Console.WriteLine("Your Pi estimation is " + Pi + " for " + dartTotal + " darts in " + threadTotal + " threads!\n");

            //makes sure console does not automatically close
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    class FindPiThread
    {
        //class attributes
        int dartsToThrow;
        int countDarts;
        Random rand;

        //initializes class attributes
        public FindPiThread(int dartsToThrow)
        {
            this.dartsToThrow = dartsToThrow;
            countDarts = 0;
            rand = new Random();
        }

        //returns dart count for those within specified circle area of dart board
        public int GetDartCount()
        {
            return countDarts;
        }

        //throws darts onto dart board and increments countDarts when darts are within specified circle area of square dart board
        public void throwDarts()
        {
            for (int i = 0; i < dartsToThrow; i++)
            {
                //sets X and Y coordinates to random double between or equal to 0 and 1
                double X = rand.NextDouble();
                double Y = rand.NextDouble();

                //hypotenuse = sqrt(X^2 + Y^2)
                double hypotenuse = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

                //checks if darts landed inside circle area of square dart board
                if (hypotenuse <= 1.0)
                {
                    countDarts++;
                }
            }
        }
    }

}