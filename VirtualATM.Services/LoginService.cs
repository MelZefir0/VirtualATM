using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class LoginService
    {
        private VirtualATMdbEntities db = new VirtualATMdbEntities();

        public bool VerifyAccount(int accIdNum, int pinNum)
        {
            var query = from a in db.AccountHolders
                        where a.PIN == pinNum && a.AccountHolderId == accIdNum
                        select a;
            foreach(var i in query)
            {
                return true;
            }

            Console.WriteLine("Please enter a valid ID and PIN...");
            return false;
        }

        public static Account GetAccountById(int accIdNum, int id)
        {
            return
                new VirtualATMdbEntities()
                    .Accounts
                    .SingleOrDefault(e => e.AccountId == id && e.AccountHolderId == accIdNum);
        }
    }
}
