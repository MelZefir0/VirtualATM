using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;
using VirtualATM.Services;

namespace VirtualATM
{
    public class ATMController
    {
        //instantiating Services
        private static LoginService loginService = new LoginService();

        private static CustomerService customerService = new CustomerService();

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

        public static void StartATM()
        {
            Console.WriteLine("Welcome to Hank Bank. We do not sell propane or propane accessories, we only provide ATM services. Now wouldya please enter your ID number..");
            int accIdNum = Int32.Parse(Console.ReadLine().Trim());

            Console.WriteLine("We're also gonna need a PIN from ya..");
            int pinNum = Int32.Parse(Console.ReadLine().Trim());

            //running VerifyAccount method from loginService with user entered information passed through
            loginService.VerifyAccount(accIdNum, pinNum);
            Console.ReadLine();

            //TODO: loop back to login screen when not verified
            //user has been verified. Menu is diplayed
            while (true)
                {
                    Console.WriteLine($@"Wlecome back, ??. How may I assist you?
                                   1...................Select Language
                                   2...................Check Balance
                                   3...................Make a Withdrawl
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
                            int accNum = Int32.Parse(Console.ReadLine().Trim());

                            //running DisplayBalance method from CustomerService with user entered information passed through
                            customerService.DisplayBalance(accNum);
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Which account would you like to make a withdrawl from? Account ID: ");
                            accNum = Int32.Parse(Console.ReadLine().Trim());

                            Console.WriteLine("How much would you like to withdraw?");
                            int amount = Int32.Parse(Console.ReadLine());

                            transactionService.Withdrawl(accNum, amount);
                            Console.ReadLine();
                            break;

                        case 4:
                             Console.WriteLine("Which account would you like to make a deposit to? Account ID: ");
                             accNum = Int32.Parse(Console.ReadLine().Trim());

                             Console.WriteLine("How much would you like to deposit?");
                             amount = Int32.Parse(Console.ReadLine());

                             transactionService.Withdrawl(accNum, amount);
                             Console.ReadLine();
                             break;

                        case 5:
                             Console.WriteLine("Please enter account number..");
                             accNum = Int32.Parse(Console.ReadLine().Trim());

                             customerService.TransactionActivity(accNum);
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
