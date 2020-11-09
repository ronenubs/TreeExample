using PositionalListExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public class LinkedBinaryTree<E> : AbstractBinaryTree<E>
    {
        protected Node<E> CreateNode(E element, Node<E> parent,
            Node<E> left, Node<E> right)
        {
            return new Node<E>(element, parent, left, right);
        }

        protected Node<E> root = null;
        private int size = 0;

        public LinkedBinaryTree()
        {

        }

        protected class Node<E> : Position<E>
        {
            private E element;
            private Node<E> parent, left, right;

            public Node(E element, Node<E> parent, Node<E> left, Node<E> right)
            {
                this.Element = element;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public E Element { set => element = value; }
            public Node<E> Parent { get; set; }
            public Node<E> Left { get; set; }
            public Node<E> Right { get; set; }


            public E GetElement()
            {
                return element;
            }
        }//end of Node class

        protected Node<E> Validate(Position<E> p)
        {
            if(!(p.GetType() == typeof(Node<E>)))
            {
                throw new Exception("Not a valid node.");
            }

            Node<E> node = (Node<E>)p;
            if(node.Parent == node)
            {
                throw new Exception("Node is no longer in the tree.");
            }
            return node;
        }

        public new int Size()
        {
            return size;
        }

        public new Position<E> Root()
        {
            return root;
        }

        public new Position<E> Parent(Position<E> p)
        {
            Node<E> node = Validate(p);
            return node.Parent;
        }

        public new Position<E> Left(Position<E> p)
        {
            Node<E> node = Validate(p);
            return node.Left;
        }

        public new Position<E> Right(Position<E> p)
        {
            Node<E> node = Validate(p);
            return node.Right;
        }

        public Position<E> AddRoot(E element)
        {
            if(!IsEmpty())
            {
                throw new Exception("The tree is not empty.");
            }

            root = CreateNode(element, null, null, null);
            size = 1;
            return root;
        }

        public Position<E> AddLeft(Position<E> p, E element)
        {
            Node<E> parent = Validate(p);

            if(parent.Left != null)
            {
                throw new Exception("p already has a left child.");
            }

            Node<E> child = CreateNode(element, parent, null, null);
            parent.Left = child;
            size++;
            return child;
        }

        public Position<E> AddRight(Position<E> p, E element)
        {
            Node<E> parent = Validate(p);

            if (parent.Right != null)
            {
                throw new Exception("p already has a right child.");
            }

            Node<E> child = CreateNode(element, parent, null, null);
            parent.Right = child;
            size++;
            return child;
        }

        public E Set(Position<E> p, E element)
        {
            Node<E> node = Validate(p);
            E temp = node.GetElement();
            node.Element = element;
            return temp;
        }

        public void Attach(Position<E> p, LinkedBinaryTree<E> t1,
            LinkedBinaryTree<E> t2)
        {
            Node<E> node = Validate(p);
            if(!IsInternal(p))
            {
                throw new Exception("p is must be a leaf.");
            }

            size += t1.size + t2.size;

            if(!t1.IsEmpty())
            {
                t1.root.Parent = node;
                node.Left = t1.root;
                t1.root = null;
                t1.size = 0;
            }

            if(!t2.IsEmpty())
            {
                t2.root.Parent = node;
                node.Right = t2.root;
                t2.root = null;
                t2.size = 0;
            }
        }

        public E Remove(Position<E> p)
        {
            Node<E> node = Validate(p);
            if(NumChildren(p) == 2)
            {
                throw new Exception("p has two children.");
            }

            Node<E> child =
                node.Left != null ? node.Left : node.Right;

            //if(node.Left != null)
            //{
            //    child = node.Left;
            //}
            //else
            //{
            //    child = node.Right;
            //}

            if(child != null)
            {
                child.Parent = node.Parent;
            }

            if(node == root)
            {
                root = child;
            }
            else
            {
                Node<E> parent = node.Parent;
                if(node == parent.Left)
                {
                    parent.Left = child;
                }
                else
                {
                    parent.Right = child;
                }
            }

            size--;

            E temp = node.GetElement();
            node.Element = default;
            node.Left = null;
            node.Right = null;
            node.Parent = node;

            return temp;
        }
    }//end of LinkedBinaryTree class
}
