using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace LList
//{
//    public class Node<T>
//    {
//        public Node(T data)
//        {
//            Data = data;
//        }
//        public T Data { get; set; }
//        public Node<T> Next { get; set; }
//        public override string ToString() => Data.ToString();
//    }

//    public class LList<T>
//    {
//        public Node<T> Head;
//        public void Print()
//        {
//            Node<T> current = Head;
//            while (current != null)
//            {
//                Console.WriteLine(current.Data);
//                current = current.Next;
//            }
//        }
//        public int Count()
//        {
//            int count = 0;
//            Node<T> current = Head;
//            while (current != null)
//            {
//                count++;
//                current = current.Next;
//            }
//            return count;
//        }

//        public void Doubled()
//        {
//            Node<T> current = Head;
//            while (current != null)
//            {
//                current.Data = (T)Convert.ChangeType(Convert.ToInt32(current.Data) * 2, typeof(T));
//                current = current.Next;
//            }
//        }

//        public void AppendFirst(T data)
//        {
//            Node<T> node = new Node<T>(data);
//            node.Next = Head;
//            Head = node;
//        }
//        public void Add(T data)
//        {
//            Node<T> node = new Node<T>(data);
//            Node<T> current = Head;
//            if (current == null)
//                Head = node;
//            else
//            {
//                while (current.Next != null)
//                { current = current.Next; }
//                current.Next = node;
//            }
//        }
//        public void Insert(T data, int pos)
//        {
//            int k = 1;
//            Node<T> node = new Node<T>(data);
//            Node<T> current = Head;
//            while (current.Next != null && k < pos)
//            { k++; current = current.Next; }
//            node.Next = current.Next;
//            current.Next = node;
//        }
//        public void Delete(int pos)
//        {
//            int k = 1;
//            Node<T> current = Head;
//            Node<T> previous = null;
//            while (current.Next != null && k < pos)
//            {
//                k++; previous = current; current = current.Next;
//            }
//            if (pos <= 1) Head = Head.Next;
//            else previous.Next = current.Next;
//        }
//        public void Clear()
//        {
//            Head = null;
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            LList<int> LinkedList = new LList<int>();
//            LinkedList.Add(13);
//            LinkedList.Add(13);
//            LinkedList.Add(-13);
//            LinkedList.Add(12);
//            LinkedList.Add(32);
//            LinkedList.Add(-2);
//            Console.WriteLine("Initialized version");
//            LinkedList.Print();
//            Console.WriteLine("First task result");
//            FirstTask(LinkedList, 13, 1);
//            LinkedList.Print();
//            Console.WriteLine("Second task result");
//            SecondTask(LinkedList);
//            LinkedList.Print();
//            Console.Write("Third task result (number of negative numbers): ");
//            Console.WriteLine(ThirdTask(LinkedList));
//            Console.WriteLine("Fourth task result");
//            FourthTask(LinkedList);
//            LinkedList.Print();
//        }

//        private static void FirstTask(LList<int> linkedList, int given_number, int newValue)
//        {
//            Node<int> current = linkedList.Head;
//            Node<int> previous = null;

//            while (current != null)
//            {
//                if (current.Data == given_number)
//                {
//                    Node<int> newNode = new Node<int>(newValue);

//                    Dehqonov Fazliddin, [25.09.2023 21:39]


//                    if (previous == null)
//                    {
//                        newNode.Next = linkedList.Head;
//                        linkedList.Head = newNode;
//                    }
//                    else
//                    {
//                        newNode.Next = current;
//                        previous.Next = newNode;
//                    }
//                }

//                previous = current;
//                current = current.Next;
//            }
//        }
//        private static void SecondTask(LList<int> LinkedList)
//        {
//            Node<int> current = LinkedList.Head;
//            int position = 1;
//            while (current != null)
//            {
//                if (current.Data < 0)
//                {
//                    LinkedList.Delete(position);
//                    break;
//                }
//                current = current.Next;
//                position++;
//            }
//        }

//        private static int ThirdTask(LList<int> LinkedList)
//        {
//            Node<int> current = LinkedList.Head;
//            int count = 0;
//            while (current != null)
//            {
//                if (current.Data < 0)
//                {
//                    count++;
//                }
//                current = current.Next;
//            }
//            return count;
//        }
//        private static void FourthTask(LList<int> LinkedList)
//        {
//            Node<int> current = LinkedList.Head;
//            int position = 1;
//            while (current != null)
//            {
//                if (current.Data % 2 == 0)
//                {
//                    LinkedList.Delete(position);
//                    break;
//                }
//                current = current.Next;
//                position++;
//            }
//        }
//    }
//}
