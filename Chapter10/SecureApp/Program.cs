using System;
using CryptographyLib;
using static System.Console;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;

namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Protector.Register("Alice", "Pa", new[] { "Admins" });
            Protector.Register("Bob", "Pa", new[] { "Sales", "TeamLeads" });
            Protector.Register("Eve", "Pa");

            Write($"Enter your user name: "); string username = ReadLine();
            Write($"Enter your password: "); string password = ReadLine();

            Protector.LogIn(username, password);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Log in failed."); return;
            }

            var p = Thread.CurrentPrincipal;

            WriteLine(
                $"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine(
            $"AuthenticationType: {p.Identity.AuthenticationType}"); 
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");

            if (p is ClaimsPrincipal)
            {
                WriteLine($"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }

        }
    }
}
