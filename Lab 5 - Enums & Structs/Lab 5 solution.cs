// sample solution to Lab 5
// author GC

using System;

public enum CurrencyUnit { Euro, Dollar }                  // yen +....

namespace Shape
{

    public struct Money
    {
        // conversion rates
        private const double EuroToDollarRate = 1.31;
        private const double DollarToEuroRate = 0.76;

        public CurrencyUnit Currency { get; set; }
        public double Amount { get; set; }

        // default constuctor always provided

        // non-default constructor
        public Money(CurrencyUnit currency, double amount)
            : this()
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        // covert currency amount to another currency
        public double Convert(CurrencyUnit toCurrency)
        {

            if (Currency == toCurrency)             // no change
            {
                return Amount;
            }
            else
            {
                if (toCurrency == CurrencyUnit.Dollar)
                {
                    return Amount * EuroToDollarRate;
                }
                else                                // convert to euro
                {
                    return Amount * DollarToEuroRate;
                }
            }
        }

        // For VB.Net
        public static Money Add(Money lhs, Money rhs)
        {
            return lhs + rhs;
        }

        // overload + operator
        // add 2 money objects together, currency for object on left dictates currency for result
        // convert if necessary
        public static Money operator +(Money lhs, Money rhs)
        {
            if (lhs.Currency == rhs.Currency)                               // both same currency
            {
                return new Money(lhs.Currency, lhs.Amount + rhs.Amount);
            }
            else
            {
                return new Money(lhs.Currency, lhs.Amount + rhs.Convert(lhs.Currency));
            }
        }

        public override string ToString()
        {
            return this.Currency + ": " + this.Amount;
        }

    }


    // test class
    class Test
    {
        public static void Main()
        {
            Money m1 = new Money(CurrencyUnit.Euro, 50);
            Money m2 = new Money(CurrencyUnit.Dollar, 70);
            Money m3 = m1 + m2;
            Console.WriteLine(m3);
            Money m4 = m3 + (new Money(CurrencyUnit.Dollar, 100));
            Console.WriteLine(m4);
        }
    }
}