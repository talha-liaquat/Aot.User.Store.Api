using System;
using System.Collections.Generic;
using System.Text;

namespace Aot.User.Store.Contracts
{
    public class InsertFailedException : Exception
    {
        public InsertFailedException(string message): base(message)
        {

        }
    }
}
