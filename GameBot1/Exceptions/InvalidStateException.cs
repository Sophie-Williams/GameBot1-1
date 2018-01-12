using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Exceptions
{
    class InvalidStateException:ApplicationException
    {
        public InvalidStateException() { }
        public InvalidStateException(string message) 
            :base(message)
        { }

    }
}
