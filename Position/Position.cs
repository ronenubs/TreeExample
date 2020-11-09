using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionalListExample
{
    public interface Position<E>
    {
        
        E GetElement();
    }
}
