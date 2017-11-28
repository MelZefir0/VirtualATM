using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class AccountService
    {
        private VirtualATMdbEntities db = new VirtualATMdbEntities();

        public Account GetAccountById(int accntHolder, int accntId)
        {
            return
                new VirtualATMdbEntities()
                    .Accounts
                    .SingleOrDefault(e => e.AccountId == accntId && e.AccountHolderId == accntHolder);
        }

        public bool RetrieveBalance(Account accntId)
        {
            var query = from a in db.Accounts
                        where a.AccountId == accntId
                        select a;
            foreach (var i in query)
            {
                return true;
            }
            //TODO: loop back to account id request
            Console.WriteLine("You don't seem to have an account with that ID. Please re-enter your account ID...");
            return false;
        }

        public bool TransactionActivity(int accntId)
        {
            var query = from a in db.Transactions
                        where a.AccountId != 0
                        select a;
            foreach (var i in query)
            {
                return true;
            }
            return false;
        }
    }
}
