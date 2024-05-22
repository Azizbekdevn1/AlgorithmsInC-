using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Navbat
{
    public class Komputer
    {
        public string Name { get; set; }
        public int Volume { get; set; }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LQueue<T>
    {
        Node<T> head; // bosh/birinchi element
        Node<T> tail; // oxirgi/dum element
        int count;
        // Navbatga qo‘shish
        public void EnQueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                temp.Next = tail;
            count++;
        }
        // Navbatdan o‘chirish
        public T DeQueue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        // Birinchi elementni olish
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // oxirgi elementni olish
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
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

        public void AllMemory()
        {
            Node<T> current = head;
            int sum = 0;
            while (current != null)
            {
                sum += ((Komputer)Convert.ChangeType(current.Data, typeof(Komputer))).Volume;
                current = current.Next;
            }
            Console.WriteLine("Jamu operativ xotira xajmi: " + sum);
        }

        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(((Komputer)Convert.ChangeType(current.Data, typeof(Komputer))).Name);
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LQueue<Komputer> komps = new LQueue<Komputer>();
            komps.EnQueue(new Komputer { Name = "Dell 1", Volume = 128 });
            komps.EnQueue(new Komputer { Name = "Dell 2", Volume = 256 });
            komps.EnQueue(new Komputer { Name = "Dell 3", Volume = 512 });
            komps.AllMemory();
            komps.Print();
            Console.ReadKey();
        }
    }
}
