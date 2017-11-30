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
        public bool Withdrawal(int id, decimal amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Withdrawal",
                    AccountId = id,
                    Amount = amount
                };
                ctx.Transaction.Add(transaction);

                ctx.Account.SingleOrDefault(e => e.AccountId == id).Balance -= amount;

                                 //please explain further
                return ctx.SaveChanges() == 1;
            }
        }

        public bool Deposit(int id, decimal amount)
        {
            using (var ctx = new VirtualATMdbEntities())
            {
                var transaction = new Transaction
                {
                    TransactionType = "Deposit",
                    AccountId = id,
                    Amount = amount
                };
                ctx.Transaction.Add(transaction);

                ctx.Account.SingleOrDefault(e => e.AccountId == id).Balance += amount;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
