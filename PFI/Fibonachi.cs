using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFI.SCHVN
{
    public static class Fibonachi
    {
            public static int GetNFibonachi(int n)
            {
            if ((n==0)|(n==1))
              return 1;
            return GetNFibonachi(n-1)+GetNFibonachi(n-2);
            }
    }
}
