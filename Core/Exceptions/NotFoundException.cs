using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object obj)
            : base($"{name} ({obj}) is not found!")
        { }
    }
}
