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
        private static LoginService loginService = new LoginService();
        private static AccountService accountService = new AccountService();
        private static TransactionService transactionService = new TransactionService();

        public void Art()
        {
            Console.WriteLine(@" ………………_„-,-~''~''':::'':::':::::''::::''... 
                                 ………._,-'':::::::::::::::::::::::::::::... 
                                 ………..,-'::::::::::::::::::::::::::::::... 
                                 ………,-'::::::::::::„:„„-~-~--'~-'~--~-~... 
                                ……..,'::::::::::,~'': : : : : : : : : : : : : : : : : : '-| 
                                ……..|::::::::,-': : : : : : : : - -~''''¯¯''-„: : : : :\ 
                                ……..|::::::::|: : : : : : : : : _„„--~'''''~-„: : : : '| 
                              ……..'|:::::::,': : : : : : :_„„-: : : : : : : : ~--„_: |' 
                                ………|::::::|: : : „--~~'''~~''''''''-„…_..„~''''''''''''¯| 
                                ………|:::::,':_„„-|: : :_„---~: : :|''¯¯''''|: ~---„_: || 
                               ……..,~-,_/'': : : |: :(_ o__): : |: : : :|:(_o__): \..| 
                               ……../,'-,: : : : : ''-,_______,-'': : : : ''-„_____| 
                               ……..\: :|: : : : : : : : : : : : : :„: : : : :-,: : : : : : : :\ 
                                ………',:': : : : : : : : : : : : :,-'__: : : :_',: : : : ;: ,' 
                                 ……….'-,-': : : : : :___„-: : :'': : ¯''~~'': ': : ~--|' 
                                  ………….|: ,: : : : : : : : : : : : : : : : : : : : : :: : :| 
                                 ………….'|: \: : : : : : : : -,„_„„-~~--~--„_: :: | 
                                 …………..|: \: : : : : : : : : : : :-------~: : : : : | 
                                 …………..|: :''-,: : : : : : : : : : : : : : : : : : : : :| 
                                 …………..',: : :''-, : : : : : : : : : : : : : : : : :: ,' 
                                  ……………| : : : : : : : : :_ : : : : : : : : : : ,-' 
                                  ……………|: : : : : : : : : : '''~----------~'' 
                                 …………._|: : : : : : : : : : : : : : : : : : : :| 
                                ……….„-''. '-,_: : : : : : : : : : : : : : : : : ,' 
                               ……,-''. . . . . '''~-„_: : : : : : : : : : : : :,-'''-„");
        }
        
        public static void DisplayBalance(Account accntId)
        {
            accountService.RetrieveBalance(accntId);
            Console.WriteLine($"Account ID: {accntId.AccountId} \n" +
                              $"Type:       {accntId.AccountType} \n" +
                              $"Balance:    {accntId.Balance}");
        }

        public static void ConfirmWithdrawal(Transaction withdrawal, Account accntId, int amount)
        {
            transactionService.Withdrawal(accntId, amount);
        }

        public static void ConfirmDeposit(Transaction Deposit, Account accntId, int amount)
        {
            transactionService.Withdrawal(accntId, amount);
        }

        public static void DisplayActivity(Transaction accntId)
        {
            accountService.TransactionActivity(accntId);
            Console.WriteLine($"{accntId.AccountId}" +
                              $"{accntId.TransactionId}" +
                              $"{accntId.TransactionType}" +
                              $"{accntId.TransactionDateTime}" +
                              $"{accntId.Amount}" +
                              $"{accntId.TransactionDescription}");
        }
        //is this necessary?
        public static void Name(AccountHolder name)
        {
             name.FirstName = name.FirstName;
        }

        public static void StartATM()
        {
            Console.WriteLine("Welcome to Hank Bank. We do not sell propane or propane accessories, we only provide ATM services. Please enter your ID number..");
            int accntHolder = Int32.Parse(Console.ReadLine().Trim());

            Console.WriteLine("We're also gonna need a PIN..");
            int pinNum = Int32.Parse(Console.ReadLine().Trim());

            //running VerifyAccount method from loginService with user entered information passed through
            loginService.VerifyAccount(accntHolder, pinNum);
            Console.ReadLine();

            //TODO: loop back to login screen when not verified
            //user has been verified. Menu is diplayed
            while (true)
                {
                    Console.WriteLine($@"Welcome back, {firstName}. How may I assist you?
                                         1...................Select Language
                                         2...................Check Balance
                                         3...................Make a Withdrawal
                                         4...................Make a Deposit
                                         5...................Account Activity
                                         6...................Make a Transfer
                                         7...................Exit");
                    var option = int.Parse(Console.ReadLine().Trim());

                    switch(option)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.WriteLine("Please enter account number..");
                            int accntId = Int32.Parse(Console.ReadLine().Trim());
                            
                            DisplayBalance(accntId);

                            Thread.Sleep(300);
                            break;

                        case 3:
                            Console.WriteLine("Which account would you like to make a withdrawal from? Account ID: ");
                            accntId = Int32.Parse(Console.ReadLine().Trim());

                            Console.WriteLine("How much would you like to withdraw?");
                            int amount = Int32.Parse(Console.ReadLine());

                           
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Which account would you like to make a deposit to? Account Number: ");
                            accntId = Int32.Parse(Console.ReadLine().Trim());

                            Console.WriteLine("How much would you like to deposit?");
                            amount = Int32.Parse(Console.ReadLine());

                            Thread.Sleep(300);
                            break;

                        case 5:
                            Console.WriteLine("Please enter account number..");
                            accntId = Int32.Parse(Console.ReadLine().Trim());

                            Thread.Sleep(300);
                            break;

                        case 6:
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                    }
            }
        }
    }
}
