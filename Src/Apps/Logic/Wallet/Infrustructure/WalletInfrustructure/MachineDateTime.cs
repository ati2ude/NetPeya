using NPCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace WalletInfrustructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
