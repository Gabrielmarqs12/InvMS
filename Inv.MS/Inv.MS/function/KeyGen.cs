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
        public int Generate()
        {
            Random rdn = new Random();
            int key = rdn.Next(1000, 9999);
            return key;
        }
    }
}
