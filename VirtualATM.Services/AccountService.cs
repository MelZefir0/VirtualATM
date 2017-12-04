using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class AccountService
    {
        private VirtualATMdbEntities1 db = new VirtualATMdbEntities1();

        public Account GetAccountById(int id)
        {
            return
                new VirtualATMdbEntities1()
                    .Account
                    .SingleOrDefault(e => e.AccountId == id);
        }



        //public AccountHolder GetName(int userId, AccountHolder name)
        //{
                 
        //    return
        //        new VirtualATMdbEntities1()
        //        .AccountHolder
        //        .SingleOrDefault(e => e.AccountHolderId == userId);
        //        name = AccountHolder.FirstName;
        //}

        public IEnumerable<Account> RetrieveBalance(int id)
        {
            var query = from a in db.Account
                        where a.AccountId == id
                        select a;
            foreach (var i in query)
            {
                var account = GetAccountById(id);
                var balance = account.Balance;
                balance = (decimal)balance;
            }
            return query;
        }
        public IEnumerable<Transaction> TransactionActivity(int id)
        {
            using (var ctx = new VirtualATMdbEntities1())
            {
                var query =
                    ctx
                        .Transaction
                        .Where(e => e.AccountId == id)
                        .Select(
                            e =>
                                new Transaction
                                {
                                    AccountId = e.AccountId,
                                    TransactionId = e.TransactionId,
                                    TransactionType = e.TransactionType,
                                    TransactionDateTime = e.TransactionDateTime,
                                    Amount = e.Amount,
                                    TransactionDescription = e.TransactionDescription

                                }
                        );
                return query;
            }
        }   

    }   
}
