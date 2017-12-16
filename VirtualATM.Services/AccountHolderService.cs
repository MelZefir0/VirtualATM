using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class AccountHolderService
    {
        public AccountHolder GetAccountHolder(int userId)
        {

            return
                new VirtualATMdbEntities1()
                .AccountHolder
                .SingleOrDefault(e => e.AccountHolderId == userId);
        }
    }
}
