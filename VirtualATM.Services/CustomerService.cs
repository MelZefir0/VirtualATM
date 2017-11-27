using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class CustomerService
    {
        private VirtualATMdbEntities db = new VirtualATMdbEntities();

        public bool DisplayBalance(int accNum)
        {
            var query = from a in db.Accounts
                        where a.AccountId == accNum
                        select a;
            foreach (var i in query)
            {
                Console.WriteLine($"Account ID: {i.AccountId} \n" +
                                  $"Type:       {i.AccountType} \n" +
                                  $"Balance:    {i.Balance}");
                return true;
            }
            //TODO: loop back to account id request
            Console.WriteLine("You don't seem to have an account with that ID. Please re-enter your account ID...");
            return false;
        }

        public bool TransactionActivity(int accNum)
        {
            var query = from a in db.Transactions
                        where a.AccountId != 0
                        select a;
            foreach (var i in query)
            {
                Console.WriteLine($"{i.AccountId}" +
                                  $"{i.TransactionId}" +
                                  $"{i.TransactionType}T" +
                                  $"{i.TransactionDateTime}" +
                                  $"{i.Amount}" +
                                  $"{i.TransactionDescription}");
                return true;
            }
            return false;
        }
    }
}
