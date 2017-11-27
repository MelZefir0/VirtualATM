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
        public bool Withdrawl(Account accNum, int amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Withdrawl",
                    AccountId = accNum.AccountId,
                    Amount = amount
                };
                ctx.Transactions.Add(transaction);

                ctx.Accounts.SingleOrDefault(e => e.AccountId == accNum.AccountId).Balance -= amount;
                accNum.Balance -= amount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Deposit(Account accNum, int amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Deposit",
                    AccountId = accNum.AccountId,
                    Amount = amount
                };
                ctx.Transactions.Add(transaction);

                ctx.Accounts.SingleOrDefault(e => e.AccountId == accNum.AccountId).Balance += amount;
                accNum.Balance += amount;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
