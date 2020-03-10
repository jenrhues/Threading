/*
 * Name: Jennifer Huestis
 * Date: 03/12/2020
 * File: Program.cs
 * Description: 
 */

using System;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
        }
    }

    class FindPiThread
    {
        int dartsToThrow;
        int countDarts;
        Random rand;
        FindPiThread(int dartsToThrow)
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

            }
        }
    }

}