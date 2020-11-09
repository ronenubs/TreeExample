using PositionalListExample;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public abstract class AbstractTree<E> : Tree<E>
    {
        public IEnumerable<E> Children(Position<E> p)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<E> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool IsExternal(Position<E> p)
        {
            return NumChildren(p) == 0;
        }

        public bool IsInternal(Position<E> p)
        {
            return NumChildren(p) > 0;
        }

        public bool IsRoot(Position<E> p)
        {
            return p == Root();
        }

        public IEnumerator<E> Iterator()
        {
            throw new NotImplementedException();
        }

        public int NumChildren(Position<E> p)
        {
            throw new NotImplementedException();
        }

        public Position<E> Parent(Position<E> p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> Positions()
        {
            throw new NotImplementedException();
        }

        public Position<E> Root()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //Depth of p
        public int Depth(Position<E> p)
        {
            if (IsRoot(p))
            {
                return 0;
            }
            else
            {
                return 1 + Depth(Parent(p));
            }
        }

        //Height
        public int Height(Position<E> p)
        {
            int h = 0;
            foreach(Position<E> c in Children(p))
            {
                h = Math.Max(h, 1 + Height(c));
            }

            return h;
        }
    }
}
