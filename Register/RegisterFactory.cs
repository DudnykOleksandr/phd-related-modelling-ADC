using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFI.SCHVN;

namespace PFI.RegisterDevice
{
    public static class RegisterFactory
    {
        public static Register Create(NotationSystem notSystem)
        {
            if (notSystem.alpha == 2.0)
                return new BinaryRegister(notSystem);
            else
                return new SCHVNRegister(notSystem);
        }
    }
}
