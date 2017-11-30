using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualATM.Models;
using VirtualATM.Services;

namespace VirtualATM
{
    [System.Runtime.InteropServices.Guid("27F1B572-5DAA-4B02-A01A-29C6FF6CB78D")]
    public class ATMController
    {
        private static AuthService authService = new AuthService();
        private static AccountService accountService = new AccountService();
        private static TransactionService transactionService = new TransactionService();
 
        public static Account AccountId { get; private set; }

        public void Art()
        {
            Console.WriteLine(@"
                               
                               
                               .--------------------------------------------------------------------.
                               | .--                    FEDERAL REVERSE NOTE                    .-- |
                               | |_       ......    THE UNTIED STATES OF AMERICA                |_  |
                               | __)    ``````````             ______            B93810455B     __) |
                               |      2        ___            /      \                     2        |
                               |              /|~\\          /  _-\\  \           __ _ _ _  __      |
                               |             | |-< |        |  //   \  |         |_  | | | |_       |
                               |              \|_//         | |-  Ó ó| |         |   | `.' |__      |
                               |               ~~~          | |\   b.' |                            |
                               |       B83910455B           |  \ '~~|  |                            |
                               | .--  2                      \_/ ```__/    ....            2    .-- |
                               | |_        ///// ///// ////   \__\'`\/      ``  //// / ////     |_  |
                               | __)                   F I V E  D O L L A R S                   __) |
                               `--------------------------------------------------------------------'");
        }

        public static Account getAccountById(int id)
        {
            return accountService.GetAccountById(id);
        }

        //public static void Balance(int id)
        //{

        //    int id = accountService.GetAccId(id, userId);
        //    accountService.RetrieveBalance(id);
        //    Console.WriteLine($"Account ID: {id.AccountId} \n" +
        //                      $"Type:       {account.AccountType} \n" +
        //                      $"Balance:    {account.Balance}");
        //}

        public static void Withdrawal(int id)
        {
            Console.WriteLine("How much would you like to withdraw?");
            decimal withdrawalAmount = Int32.Parse(Console.ReadLine());

            if (withdrawalAmount > AccountId.Balance)
            {
                Console.WriteLine("Insufficient funds");
            }

            transactionService.Withdrawal(id, withdrawalAmount);
        }

        public static void Deposit(int id)
        {
            Console.WriteLine("How much would you like to deposit?");
            decimal depositAmount = Int32.Parse(Console.ReadLine());
            transactionService.Deposit(id, depositAmount);
        }

        //public static void Activity(int id)
        //{
        //    var transactionActivity = new TransactionActivity(id);
        //    foreach (var i in query)
        //    {
        //        Console.WriteLine($"{i.AccountId}" +
        //                      $"{i.TransactionId}" +
        //                      $"{i.TransactionType}" +
        //                      $"{i.TransactionDateTime}" +
        //                      $"{i.Amount}" +
        //                      $"{i.TransactionDescription}");
        //    }
        //}

        public static void StartATM()
        {
            bool auth = false;

            while (!auth)
            {
                Console.WriteLine("Please enter your Personal ID Number: ");
                int userid = Int32.Parse(Console.ReadLine().Trim());

                Console.WriteLine("PIN: ");
                int pin = Int32.Parse(Console.ReadLine().Trim());

                auth = authService.VerifyUser(userid, pin);

                Account account = null;
                while(account == null)
                {
                    Console.WriteLine($"Welcome back, ??. Which account would you like to access? Account ID: ");
                    int id = Int32.Parse(Console.ReadLine().Trim());

                    account = getAccountById(id);
                }
                    Console.WriteLine(@"How may I assist you?
                                1...................Check Balance
                                2...................Make a Withdrawal
                                3...................Make a Deposit
                                4...................Account Activity
                                5...................Exit");
                    var option = int.Parse(Console.ReadLine().Trim());

                    switch (option)
                    {
                        case 1:
                            //Balance(id);
                            Thread.Sleep(300);
                            break;
                        case 2:
                            //Withdrawal(id);
                            Thread.Sleep(300);
                            break;

                        case 3:
                            //Deposit(id);
                            Thread.Sleep(300);
                            break;

                        case 4:
                            //Activiy(id);
                            Thread.Sleep(300);
                            break;

                        case 5:
                            Environment.Exit(0);
                        break;
                    }
                Console.WriteLine("Invalid Entry");
                break;
            }
        }
    }
}
