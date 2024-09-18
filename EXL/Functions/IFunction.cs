using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXL.Functions
{
    public interface IFunction
    {
        object Execute(params object[] argument);
    }
}
