using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualATM
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate ATMController
            ATMController appInstance = new ATMController();

            appInstance.Art();
            ATMController.StartATMJeremy();
        }
    }
}
