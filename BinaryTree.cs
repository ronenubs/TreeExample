using PositionalListExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public interface BinaryTree<E> : Tree<E>
    {
        Position<E> Left(Position<E> p);
        Position<E> Right(Position<E> p);
        Position<E> Sibling(Position<E> p);
    }
}
