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
        private VirtualATMdbEntities db = new VirtualATMdbEntities();

        public Account GetAccountById(int id)
        {
            return
                new VirtualATMdbEntities()
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
        //public IEnumerable<IList> TransactionActivity(int id)
        //{
        //    using (var ctx = new VirtualATMdbEntities())
        //    {
        //        var query =
        //            ctx
        //                .Transaction
        //                .Where(e => e.AccountId == id)
        //                .Select(
        //                    e =>
        //                        new Transaction
        //                        {
        //                            AccountId = e.AccountId,
        //                            TransactionId = e.TransactionId,
        //                            TransactionType = e.TransactionType,
        //                            TransactionDateTime = e.TransactionDateTime,
        //                            Amount = e.Amount,
        //                            TransactionDescription = e.TransactionDescription

        //                        }
        //                );
        //        return query.ToArray();
        //    }
        //}   

    }   
}
