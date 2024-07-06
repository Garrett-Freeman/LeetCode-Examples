using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExamples
{
    /// <summary>
    /// Linked Lists are a data structure that consists of a sequence of elements where each element points to the next element in the sequence.
    /// It is great for when you need to insert or delete elements like a queue but not so great for searching for elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomLinkedList<T>
    {
        public class Node
        {
            private Node? next;
            private T data;


            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node? Next
            {
                get { return next; }
                set { next = value; }
            }


            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }


        private Node? head;

        public Node Head
        {
            get { return head; }
            set { head = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void Push(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        /// <summary>
        /// Reverses the linked list iteratively
        /// O(n) time complexity because we iterate through the linked list
        /// O(1) space complexity because we only use a few pointers
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node? IterativeReverseList()
        {
            Node? prev = null;
            Node? current = head;
            Node? next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        /// <summary>
        /// Reverses the linked list iteratively
        /// O(n) time complexity because we iterate through the linked list
        /// O(1) space complexity because we only use a few pointers
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node? RecursiveReverseLinkedList(Node head)
        {
            if (head == null || head.Next == null)
                return head;

            Node? rest = RecursiveReverseLinkedList(head.Next);
            head.Next.Next = head;

            head.Next = null;
                       
            return rest;
        }

        public Node? StackReverseLinkedList()
        {
            Stack<Node> stack = new Stack<Node>();
            Node? current = head;

            while (current != null)
            {
                stack.Push(current);
                current = current.Next;
            }

            Node? newHead = stack.Pop();
            current = newHead;

            while (stack.Count > 0)
            {
                current.Next = stack.Pop();
                current = current.Next;
            }

            current.Next = null;

            return newHead;
        }

        /// <summary>
        /// Gets the node at a specific index starting at 0
        /// O(n) time complexity because we iterate through the linked list
        /// O(1) space complexity because we only use a few pointers
        /// </summary>
        /// <param name="head"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node? GetIndex(int index)
        {
            if (index >= GetLength())
                throw new IndexOutOfRangeException("Index out of range");

            Node? current = head;
            int count = 0;

            while (current != null)
            {
                if (count == index)
                {
                    return current;
                }
                count++;
                current = current.Next;
            }

            return current;
        }

        /// <summary>
        /// Gets the length of the linked list assuming head it start of linked list
        /// Iterative approach
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GetLength()
        {
            Node? current = head;
            int count = 0;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        /// <summary>
        /// Gets the length of the linked list assuming head it start of linked list
        /// Recursive approach
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int GetLengthRecursive(Node? head)
        {
            if (head == null)
                return 0;

            return 1 + GetLengthRecursive(head.Next);
        }

        /// <summary>
        /// Prints the linked list
        /// </summary>
        /// <param name="head"></param>
        public string PrintLinkedList(Node? head = null)
        {
            var list = "";

            if (head == null || head.Next == null)
                head = Head;

            Node? current = head;

            while (current != null)
            {
                list += " " + current.Data;
                current = current.Next;
            }

            return list;
        }

        /// <summary>
        /// earches for a value in the linked list
        /// Iterative approach
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExistsInLinkedList(T t)
        {
            Node? current = head;

            while (current != null)
            {
                if (current.Data.Equals(t))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public bool ExistsInLinkedListRecursive(T t, Node? head = null, bool isFirst = true)
        {
            if (isFirst)
                head = Head;

            if (head == null)
                return false;

            if (head.Data.Equals(t))
                return true;

            return ExistsInLinkedListRecursive(t, head.Next, false);
        }

        public void Append(T t)
        {
            Node? current = head;
            Node? n = new Node(t);

            if (head == null)
            {
                head = n;
                return;
            }

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = n;
        }

        public void InsertAfter(T t, Node prev)
        {
            Node? current = head;
            Node? n = new Node(t);

            if (prev == null)
            {
                Console.WriteLine("Previous node cannot be null");
                return;
            }

            n.Next = prev.Next;
            prev.Next = n;
        }

        public void ChangeNodeIndex(int index, T t)
        {
            Node? current = head;
            int count = 0;

            while (current != null)
            {
                if (count == index)
                {
                    current.Data = t;
                    return;
                }
                count++;
                current = current.Next;
            }
        }

        public void DeleteNode(int index)
        {
            Node? current = head;
            Node? prev = null;
            int count = 0;

            if (index == 0)
            {
                head = current.Next;
                return;
            }

            while (current != null)
            {
                if (count == index)
                {
                    prev.Next = current.Next;
                    return;
                }
                count++;
                prev = current;
                current = current.Next;
            }
        }

        public void SwapNodes(T t1, T t2)
        {
            Node? current = head;
            Node? prev1 = null;
            Node? prev2 = null;
            Node? node1 = null;
            Node? node2 = null;

            while (current != null)
            {
                if (current.Data.Equals(t1))
                {
                    node1 = current;
                    break;
                }
                prev1 = current;
                current = current.Next;
            }

            current = head;

            while (current != null)
            {
                if (current.Data.Equals(t2))
                {
                    node2 = current;
                    break;
                }
                prev2 = current;
                current = current.Next;
            }

            if (node1 == null || node2 == null)
                return;

            if (prev1 != null)
                prev1.Next = node2;
            else
                head = node2;

            if (prev2 != null)
                prev2.Next = node1;
            else
                head = node1;

            Node? temp = node1.Next;
            node1.Next = node2.Next;
            node2.Next = temp;
        }
    }
}
