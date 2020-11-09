using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionalListExample
{
    public interface PositionalList<E>
    {
        int Size();
        bool IsEmpty();

        Position<E> First();
        Position<E> Last();
        Position<E> Before(Position<E> p);
        Position<E> After(Position<E> p);

        Position<E> AddFirst(E element);
        Position<E> AddLast(E element);

        Position<E> AddBefore(Position<E> p, E element);
        Position<E> AddAfter(Position<E> p, E element);

        E Set(Position<E> p, E element);
        E Remove(Position<E> p);
    }
}
