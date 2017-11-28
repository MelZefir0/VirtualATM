using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class TransactionService
    {
        public bool Withdrawal(Account accntId, int amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Withdrawal",
                    AccountId = accntId.AccountId,
                    Amount = amount
                };
                ctx.Transactions.Add(transaction);

                ctx.Accounts.SingleOrDefault(e => e.AccountId == accntId.AccountId).Balance -= amount;
                accntId.Balance -= amount;

                                 //please explain further
                return ctx.SaveChanges() == 1;
            }
        }

        public bool Deposit(Account accntId, int amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Deposit",
                    AccountId = accntId.AccountId,
                    Amount = amount
                };
                ctx.Transactions.Add(transaction);

                ctx.Accounts.SingleOrDefault(e => e.AccountId == accntId.AccountId).Balance += amount;
                accntId.Balance += amount;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
