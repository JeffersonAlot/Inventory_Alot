using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Alot
{
    internal class StringFormatException : Exception
    {
        public StringFormatException(string varName) : base(varName){ }
    }
}
