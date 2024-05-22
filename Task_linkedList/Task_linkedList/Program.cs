

using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
namespace LList
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T head;
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public override string ToString() => Data.ToString();
    }

    public class LList<T>
    {
        public Node<T> head; // bosh/birinchi element
        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public int Count()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void Doubled()
        {
            Node<T> current = head;
            while (current != null)
            {
                current.Data = (T)Convert.ChangeType(Convert.ToInt32(current.Data) * 2, typeof(T));
                current = current.Next;
            }
        }


        // ro‘yxat boshiga qo‘shish
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            if (current == null)
                head = node;
            else
            {
                while (current.Next != null)
                { current = current.Next; }
                current.Next = node;
            }
        }
        public void Insert(T data, int pos)
        {
            int k = 1;
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            while (current.Next != null && k < pos)
            { k++; current = current.Next; }
            node.Next = current.Next;
            current.Next = node;
        }
        public void Delete(int pos)
        {
            int k = 1;
            Node<T> current = head;
            Node<T> previous = null;
            while (current.Next != null && k < pos)
            {
                k++; previous = current; current = current.Next;
            }
            if (pos <= 1) head = head.Next;
            else previous.Next = current.Next;
        }
        public void Clear()
        {
            head = null;
        }
        public void Remove(T value)
        {
            if (head == null)
                return;

            if (head.Data.Equals(value))
            {
                head = head.Next;
                return;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(value))
                {
                    current.Next = current.Next.Next;
                    return;

                }
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LList<int> linkedList = new LList<int>();
            // Elementlar qo‘shish
            linkedList.Add(33);
            linkedList.Add(23);
            linkedList.Add(13);
            linkedList.Add(65);
            linkedList.Add(13);
            linkedList.Add(-54);
            linkedList.Add(13);
            linkedList.Add(-12);
            linkedList.Add(13);
            linkedList.Add(87);
            linkedList.Add(90);
            linkedList.Add(13);


            linkedList.Print();
            linkedList.Remove(13);
            linkedList.AppendFirst(13);
            Console.WriteLine("Natija:");
            linkedList.Print();


            Console.ReadKey();
        }

        public static void FirstTask(LList<int> linked_list)
        {

            Node<int> currentNode = linked_list.head;
            while (currentNode != null)
            {
                if (currentNode.Data % 2 != 0) // 
                {

                    Node<int> node = new Node<int>(currentNode.Data);
                    node.Next = currentNode.Next;
                    currentNode.Next = node;
                    break;

                }
                currentNode = currentNode.Next;
            }


            if (currentNode == null)
            {
                Console.WriteLine("Toq elementli node yo'q ");
            }

        }

        public static void SecondTask(LList<int> linked_list, int given_number)
        {
            Node<int> current = linked_list.head;
            int position = 0;
            while (current != null)
            {
                position++;
                if (current.Data > given_number)
                {
                    linked_list.Delete(position);
                    break;
                }
                current = current.Next;

            }


        }
        public static void ThreeTask(LList<int> linked_list)
        {
            Node<int> current = linked_list.head;
            int positive_Sum = 0;
            while (current != null)
            {
                if (current.Data > 0)
                {
                    positive_Sum += current.Data;
                }
                current = current.Next;
            }
            Console.WriteLine($"Musbat sonlarni yig'indisi:{positive_Sum}");

        }


        public static void FourTask(LList<int> linked_list, int given_number)
        {
            Node<int> current = linked_list.head;
            int position = 0;
            while (current != null)
            {
                if (current.Data == given_number)
                {
                    linked_list.Remove(given_number);
                    Console.WriteLine($"{position} dagi elementni olib tashlandi.");
                }
                current = current.Next;
                position++;
            }
        }
        public static void Samandar(LList<int> linked_list, int raqam)
        {
            Node<int> current = linked_list.head;
            int position = 1;
            while (current != null)
            {
                if (current.Data == raqam)
                {
                    linked_list.Insert(raqam, position);
                    Console.WriteLine($"{position} dagi elementdan keyin o'zi qo'shildi.");
                }
                current = current.Next;
                position++;
            }
        }

        public static void Masala1(LList<int> linked_list, int raqam,int son)
        {
            //Bu yerda son siz xohalgan son istal son yozsangiz boladi 
            Node<int> current= linked_list.head;
            int position = 1;
            while (current != null)
            {
                if(current.Data == raqam)
                {
                    linked_list.Insert(12,position);
                    Console.WriteLine($"{position} dagi elementdan keyin {son} qo'shildi.");
                }
                current = current.Next;
                position++;
            }
        }

    }
}


