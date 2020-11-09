using PositionalListExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public abstract class AbstractBinaryTree<E> : AbstractTree<E>,
        BinaryTree<E>
    {
        public Position<E> Left(Position<E> p)
        {
            throw new NotImplementedException();
        }

        public Position<E> Right(Position<E> p)
        {
            throw new NotImplementedException();
        }

        public Position<E> Sibling(Position<E> p)
        {
            Position<E> parent = Parent(p);
            if(parent == null)
            {
                return null;
            }

            if(p == Left(parent))
            {
                return Right(parent);
            }
            else
            {
                return Left(parent);
            }
        }

        public new int NumChildren(Position<E> p)
        {
            int count = 0;
            if(Left(p) != null)
            {
                count++;
            }
            if(Right(p) != null)
            {
                count++;
            }

            return count;
        }

        public new IEnumerable<Position<E>> Children(Position<E> p)
        {
            List<Position<E>> snapshot = new List<Position<E>>(2);
            if(Left(p) != null)
            {
                snapshot.Add(Left(p));
            }
            if(Right(p) != null)
            {
                snapshot.Add(Right(p));
            }

            return snapshot;
        }
    }
}
