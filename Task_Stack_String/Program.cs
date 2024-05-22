using System;
using System.Collections.Generic;
using System.Text;

namespace ListStack
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LStack<T>
    {
        Node<T> head;
        int count;

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }
        public void Push(T item)
        {
            // Stekni kattalashtiramiz
            Node<T> node = new Node<T>(item);
            node.Next = head; // stek uchini yangi elementga qayta o’rnatish
            head = node;
            count++;
        }
        public T Pop()
        {
            // Stek bo’sh bo’lsa istisno xolatini yuzaga keltirish
            if (IsEmpty)
                throw new InvalidOperationException("Stek bo’sh");
            Node<T> temp = head;
            head = head.Next; // stek uchini keyingi elementga qayta o’rnatish
            count--;
            return temp.Data;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stek bo’sh");
            return head.Data;
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void PrintStartT()
        {
            Node<T> current = head;
            while (current != null)
            {
                string instring = current.Data.ToString();
                if (instring[0] == 't')
                {
                    Console.WriteLine(instring);
                }
                current = current.Next;
            }
        }
    }

}

namespace ListStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LStack<string> stack = new LStack<string>();
                stack.Push("Students");
                stack.Push("of");
                stack.Push("the");
                stack.Push("group");
                stack.Push("TE");
                stack.Push("there");
                stack.Push("that");
                stack.Push("Thought");
                stack.Print();

                Console.WriteLine();
                string header = stack.Peek();
                Console.WriteLine($"Stek uchi: {header}");
                Console.WriteLine();
                header = stack.Pop();
                stack.Print();
                Console.WriteLine("Bosh harfi t bilan boshlanuvchi so'zlar:");
                stack.PrintStartT();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

}

