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
        private VirtualATMdbEntities1 db = new VirtualATMdbEntities1();

        public Account GetAccountById(int id)
        {
            return
                new VirtualATMdbEntities1()
                    .Account
                    .SingleOrDefault(e => e.AccountId == id);
        }

        public bool RetrieveBalance(int id)
        {
            var query = from a in db.Account
                        where a.AccountId == id
                        select a;
            foreach (var i in query)
            {
                return true;
            }
            return false;
        }

        public bool TransactionActivity(int id)
        {
            var query = from a in db.Transaction
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
