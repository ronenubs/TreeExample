using PositionalListExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public interface Tree<E> : IEnumerable<E>
    {
        Position<E> Root();
        Position<E> Parent(Position<E> p);
        IEnumerable<E> Children(Position<E> p);

        int NumChildren(Position<E> p);
        bool IsInternal(Position<E> p);
        bool IsExternal(Position<E> p);
        bool IsRoot(Position<E> p);
        int Size();
        bool IsEmpty();
        IEnumerator<E> Iterator();
        IEnumerable<E> Positions();

        
    }
}
