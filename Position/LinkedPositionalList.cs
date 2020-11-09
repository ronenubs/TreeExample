using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample;

namespace PositionalListExample
{
    public class LinkedPositionalList<E> : PositionalList<E>
    {
        private Node<E> header, trailer;
        private int size;

        public LinkedPositionalList()
        {
            header = new Node<E>(null, default, null);
            trailer = new Node<E>(header, default, null);
            header.Next = trailer;
        }
        
        //Validates the position and returns it as a node
        private Node<E> Validate(Position<E> p)
        {
            if(!(p.GetType() == typeof(Node<E>)))
            {
                throw new InvalidPositionException("Invalid position.");
            }

            Node<E> node = (Node<E>) p;
            if (node.Next == null)
            {
                throw new InvalidPositionException("P is no longer in the list.");
            }

            return node;
        }

        private Position<E> Position(Node<E> node)
        {
            if(node == header || node == trailer)
            {
                return null;
            }

            return node;
        }

        private Position<E> AddBetween(Node<E> prev, E element, Node<E> next)
        {
            Node<E> newNode = new Node<E>(prev, element, next);
            prev.Next = newNode;
            next.Prev = newNode;
            newNode.Prev = prev;
            newNode.Next = next;
            size++;
            return Position(newNode);
        }

        // p aftr p.Next
        public Position<E> AddAfter(Position<E> p, E element)
        {
            Node<E> pos = Validate(p);
            return AddBetween(pos, element, pos.Next);
        }

        //p.Prev b4 p
        public Position<E> AddBefore(Position<E> p, E element)
        {
            Node<E> pos = Validate(p);
            return AddBetween(pos.Prev, element, pos);
        }

        public Position<E> AddFirst(E element)
        {
            
            return AddBetween(header, element, header.Next);
        }

        public Position<E> AddLast(E element)
        {
            return AddBetween(trailer.Prev, element, trailer);
        }

        public Position<E> After(Position<E> p)
        {
            Node<E> pos = Validate(p);
            return Position(pos.Next);
        }

        public Position<E> Before(Position<E> p)
        {
            Node<E> pos = Validate(p);
            return Position(pos.Prev);
        }

        public Position<E> First()
        {
            return Position(header.Next);
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public Position<E> Last()
        {
            return Position(trailer.Prev);
        }

        public E Remove(Position<E> p)
        {
            Node<E> node = Validate(p);
            Node<E> prev = node.Prev;
            Node<E> next = node.Next;

            prev.Next = next;
            next.Prev = prev;

            size--;

            E temp = node.GetElement();
            node.Next = null;
            node.Prev = null;
            node.Element = default;

            return temp;
        }

        public E Set(Position<E> p, E element)
        {
            Node<E> node = Validate(p);
            E temp = node.GetElement();
            node.Element = element;
            return temp;
        }

        public int Size()
        {
            return size;
        }

        //CLASS NODE
        private class Node<E> : Position<E>
        {
            private Node<E> prev;
            private E element;
            private Node<E> next;

            public Node<E> Prev { get; set; }
            public E Element
            {
                set
                {
                    element = value;
                }
            }
            
            public Node<E> Next { get; set; }

            public Node(Node<E> prev, E element, Node<E> next)
            {
                this.prev = prev;
                this.element = element;
                this.next = next;
            }


            public E GetElement()
            {
                if (next == null)
                {
                    throw new Exception("Position is no longer valid.");
                }

                return element;
            }
        }//end of Node<E> class

    }
}
