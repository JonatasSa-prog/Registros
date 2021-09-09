using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registros.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(String message) : base(message)
        {
        }
    }
}
