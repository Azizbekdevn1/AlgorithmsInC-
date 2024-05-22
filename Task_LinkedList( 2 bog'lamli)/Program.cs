using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SimpleAlgorithmsApp2
{
    public class DNode<T>
    {
        public DNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        // keyingi tugunga ko'rsatgich 
        public DNode<T> Next { get; set; }
        // oldingi tugunga ko'rsatgich
        public DNode<T> Prev { get; set; }
    }
    public class DList<T>
    {

        // bosh/birinchi element
        public  DNode<T> head;
        // quyruq /oxirgi element
        public DNode<T> tail;
        int count;  // ro'yxatdagi elementlar
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public bool ContainsH(T data)
        {
            DNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool ContainsT(T data)
        {
            DNode<T> current = tail;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Prev;
            }
            return false;
        }
        public void AddFirst(T data)
        {
            DNode<T> node = new DNode<T>(data);
            DNode<T> temp = head;
            node.Next = head;
            head = node;
            if (count == 0)
                tail = node;
            else
                head.Prev = node;
            head = node;
            count++;
        }
        // Elementni ro’yxat oxiriga qo’shish
        public void Add(T data)
        {
            DNode<T> node = new DNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
            }
            tail = node;
            count++;
        }

        public void Insert(T data, int pos)
        {
            int k = 1;
            DNode<T> node = new DNode<T>(data);
            DNode<T> current = head;
            while (current.Next != null && k < pos)
            { k++; current = current.Next; }
            node.Next = current.Next;
            node.Prev = current;
            current.Next.Prev = node;
            current.Next = node;
            count++;
        }
        // ro’yxatni bosh/birinchi tugunini o’chirish usuli
        public void DeleteFirst()
        {
            head = head.Next;
            head.Prev = null;
            count--;
        }
        // ro’yxatni oxirgi tugunini o’chirish usuli
        public void DeleteLast()
        {
            tail = tail.Prev;
            tail.Next = null;
            count--;
        }
        // ro’yxatdan ko’rsatilgan o’rindagi tugunni o’chirish usuli
        public void Delete(int pos)
        {
            int k = 1;
            DNode<T> current = head;
            DNode<T> previous = null;
            while (current.Next != null && k < pos)
            {
                k++; current = current.Next;
            }
            if (k == 1)
            {
                head = head.Next;
                head.Prev = null;
            }
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }
            count--;
        }
        public void Print()
        {
            DNode<T> current=head;
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //2  bog'lamli ro'yhat bo'yicha berilgan masala yechimi kodlari shu yerda

            DList<int> linkedList = new DList<int>();
            linkedList.Add(0);
            linkedList.Add(13);
            linkedList.Add(-23);
            linkedList.Add(0);
            linkedList.Add(253);
            linkedList.Add(-987);
            linkedList.Add(13);
            linkedList.Add(0);
            linkedList.Add(54);
            linkedList.Print();
            //LastFirstAdd(linkedList);
            Console.WriteLine("Natija:");
            SecondTask(linkedList);
            linkedList.Print();




        }

        //1-Ro'yxatdagi barcha nol elementlarni olib tashlang.
        public static void SecondTask(DList <int> DList)
        {
            DNode<int> current = DList.head;
            int pos = 1;
            while (current!= null)
            {
                if (current.Data==0)
                {
                    DList.Delete(pos);
                    pos--;
                }
                current = current.Next;
                pos++;
            }

        }

    }
}














