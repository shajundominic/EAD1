// sample solution to Lab 4 part 2
// author GC

using System;

namespace AcademicRecord
{
    public class ModuleCAResults
    {
        public String Name { get; set; }
        public int Credits { get; set; }
        public String StudentName { get; set; }

        private const int MAX = 50;                             // max 50 results
        private double[] results = new double[MAX];             // create array
        private int next = 0;                                   // next free slot for a result in the results array

        // return a string contain all module details including results
        public override string ToString()
        {
            String output = "Module: " + Name + " Credits: " + Credits + " Student Name: " + StudentName + "\nResults ";
            for (int i=0; i < next; i++)
            {
                output += results[i] + " ";
            }
            return output;
        }

        // indexer based on CA
        public double this[int CA]
        {
            get
            {
                int index = CA - 1;                             // CA1 is at index 0 etc.
                if ((index >= 0) && (index < next))             // valid range
                {
                    return results[index];                      // return the result
                }
                else
                {
                    throw new Exception("Invalid CA number");
                }
            }
            set
            {
                // add a result or change an existing result

                int index = CA - 1;
                // no gaps allowed, must overwrite existing result or add at end, and must have space in array
                if ((index >= 0) && (index <= next) && (index < (MAX)))
                {
                    results[index] = value;                     // set the result
                    if (index == next)                          
                    {
                        next++;                                 // that was a new result
                    }
                }
                else
                {
                    throw new Exception("Invalid CA number");
                }
            }
        }
    }

 
    // run some tests
    class Test
    {
        public static void Main()
        {
            try
            {
                ModuleCAResults results = new ModuleCAResults() { Name = "oosdev2", Credits = 10, StudentName = "Jane Doe" };
                results[1] = 20;                    // new result for CA1
                results[2] = 40;
                results[3] = 60;
                results[1] = 25;                    // overwrite
                results[3] = 65;                    // overwrite
                results[4] = 99;
             
                Console.WriteLine(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}