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

        public bool VerifyAccount(int accntHolder, int pinNum)
        {
            var query = from a in db.AccountHolders
                        where a.PIN == pinNum && a.AccountHolderId == accntHolder
                        select a;
            foreach(var i in query)
            { 
                return true;
            }

            return false;
        }

    }
}
