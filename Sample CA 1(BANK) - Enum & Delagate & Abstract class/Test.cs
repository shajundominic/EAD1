// sample solution to CA1 - author GC

using System;
using Bank;

// simple test class
public class Test
{
	public static void Main()
	{
		try
		{
			// create an account, make some deposits and withdrawals
			CurrentAccount myAccount = new CurrentAccount("GC", 1000);
			
			// register handler for when account becomes overdrawn
			myAccount.LowFunds += new AccountLowFunds(LowFunds);

			myAccount.MakeDeposit(100);
			myAccount.MakeDeposit(100);
			myAccount.MakeWithdrawal(50);
			myAccount.MakeWithdrawal(500);

			// Console.WriteLine(myAccount)
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	// low funds, 
	private static void LowFunds(BankAccount b)
	{
		Console.WriteLine("Account is overdrawn!\n" + b);
	}
}
