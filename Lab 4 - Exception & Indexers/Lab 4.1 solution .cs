// sample solution to Lab 4 part 1
// author GC

using System;


namespace Divisor
{
    public class Calculator
    {
        // divde lhs by rhs unless rhs is zero
        public static double Divide(double lhs, double rhs)
        {
            if (rhs == 0)
            {
                throw new ArgumentException("Error: attempt to divide by 0");
            }
            else
            {
                return lhs / rhs;
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
                double num1 = 0, num2 = 0;

                // take in inputs

                bool valid = true;
                do
                {
                    try
                    {
                        Console.Write("Enter 1st number: ");
                        num1 = Double.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (FormatException)
                    {
                        valid = false;
                    }
                    catch (OverflowException)
                    {
                        valid = false;
                    }
                } while (!valid);

               
                do
                {
                    try
                    {
                        Console.Write("Enter 2nd number: ");
                        num2 = Double.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception)                                   // cathes both Format and Overflow exceptuons
                    {
                        valid = false;
                    }
                   
                } while (!valid);
                
                Console.WriteLine(Calculator.Divide(num1, num2));
            }
            catch (ArgumentException e1)                                // i.e. divide by zero attempt
            {
                Console.WriteLine(e1.Message);
            }

        }
    }
}