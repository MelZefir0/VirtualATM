﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VirtualATM.Models;

namespace VirtualATM.Services
{
    public class AuthService
    {
        private VirtualATMdbEntities1 db = new VirtualATMdbEntities1();

        public bool VerifyUser(int pin, int userId)
        {
            var query = from a in db.AccountHolder
                        where a.PIN == pin && a.AccountHolderId == userId
                        select a;
            foreach (var i in query)
            {
                return true;
            }
            return false;
        }

        public bool AuthenticateUser(int accountHolderId, int pin)
        {
            using (var ctx = new VirtualATMdbEntities1())
            {
                var holder = ctx
                    .AccountHolder
                    .SingleOrDefault(ah => ah.AccountHolderId == accountHolderId);

                if (holder == null) return false;

                if (holder.PIN == pin) return true;
                else return false;
            }
        }
    }
}
