using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inv.MS.function
{
    public class KeyGen
    {
        public String Generate()
        {
            Random rdn = new Random();
            int number = rdn.Next(1000, 9999);
            string key = number.ToString();
            return key;
        }
    }
}
