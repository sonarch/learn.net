using System;
using static System.Console;
using CryptographyLib;
using System.Security.Cryptography;
namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message that you want to encrypt: ");
            string message = ReadLine();
            Console.WriteLine("Enter password: ");
            string password = ReadLine();

            string cryptoText = Protector.Encrypt(message, password);

            WriteLine($"Encrypted text {cryptoText}");

            Write("Enter the password: ");
            string password2 = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text {clearText}");
            }
            catch (System.Exception e)
            {
                WriteLine(e);
                throw;
            }
        }
    }
}
