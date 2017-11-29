using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtualATM.Models;
using VirtualATM.Services;

namespace VirtualATM
{
    public class ATMController
    {
        private static AuthService authService = new AuthService();
        private static AccountService accountService = new AccountService();
        private static TransactionService transactionService = new TransactionService();
        private static AccountService getAccount = new AccountService();

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

        public static void AccountId(int id)
        {
            accountService.GetAccountById(id);
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
            int withdrawalAmount = Int32.Parse(Console.ReadLine());
            transactionService.Withdrawal(id, withdrawalAmount);
        }

        public static void Deposit(int id)
        {
            Console.WriteLine("How much would you like to deposit?");
            int depositAmount = Int32.Parse(Console.ReadLine());
            transactionService.Deposit(id, depositAmount);
        }

        //public static void Activity(int id)
        //{
        //    accountService.TransactionActivity(id);
        //    Console.WriteLine($"{id.AccountId}" +
        //                      $"{id.TransactionId}" +
        //                      $"{id.TransactionType}" +
        //                      $"{id.TransactionDateTime}" +
        //                      $"{id.Amount}" +
        //                      $"{accntId.TransactionDescription}");
        //}
        //is this necessary?

        public static void StartATM()
        {
            Console.WriteLine("Welcome. Please enter your Personal ID Number: ");
            int userid = Int32.Parse(Console.ReadLine().Trim());

            Console.WriteLine("PIN: ");
            int pin = Int32.Parse(Console.ReadLine().Trim());

            authService.VerifyAccount(userid, pin);
            

                Console.WriteLine($"Welcome back, ??. Which account would you like to access? Account ID: ");
                int id = Int32.Parse(Console.ReadLine().Trim());

                AccountId(id);

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
                        break;
                    case 2:
                        Withdrawal(id);
                        Thread.Sleep(300);
                        break;

                    case 3:
                        Deposit(id);
                        Thread.Sleep(300);
                        break;

                    case 4:

                        Thread.Sleep(300);
                        break;

                    case 5:
                        Environment.Exit(0);
                        Thread.Sleep(300);
                        break;

                }
            
        }
    }
}
