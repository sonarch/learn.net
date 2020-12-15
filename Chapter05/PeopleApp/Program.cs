using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
                | WondersOfTheAncientWorld.MausoleumAtHalicarnassus
                | WondersOfTheAncientWorld.StatueOfZeusAtOlympia
            ;
            bob.Children.Add(new Person {Name = "Alfred"});
            bob.Children.Add(new Person {Name = "Zoe"});

            Console.WriteLine(
                format: "{0} was born on {1: dddd, d MMMM yyyy}",
                arg0: bob.Name,
                arg1: bob.DateOfBirth
            );
            Console.WriteLine(
                format: "{0} favirute wonder is {1}",
                arg0: bob.Name,
                arg1: bob.BucketList
            );
            Console.WriteLine(
                format: "{0} has {1} children: ",
                arg0: bob.Name,
                arg1: bob.Children.Count
            );
            for (int i = 0; i < bob.Children.Count; i++)
            {
                Console.WriteLine($"{bob.Children[i].Name}");
            }
            
            BankAccount.InterestRate = 2040;

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest.", arg0: jonesAccount.AccountName,
            arg1: jonesAccount.Balance * BankAccount.InterestRate);
            BankAccount.InterestRate = 10;
            WriteLine(format: "{0} earned {1:C} interest.", arg0: jonesAccount.AccountName,
            arg1: jonesAccount.Balance * BankAccount.InterestRate);
        }
    }
}
