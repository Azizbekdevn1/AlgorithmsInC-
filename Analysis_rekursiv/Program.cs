using System.Text;

namespace Analysis_rekursiv
{
    internal class Program
    {

        //public static int Sum(int n)
        //{
        //    int s = 0;
        //    for (int i = 1; i <= n; i++) s += i;
        //    return s;
        //}
        //public static int Sum(int n)
        //{
        //    if (n == 1) return 1;
        //    return n + Sum(n - 1);
        //}

        public static int Sum(int n)
        {
            Console.WriteLine($"Chaqiruv: n ={n}");
            if (n == 1)
            {
                Console.WriteLine("Qaytarildi: 1");
                return 1;
            }
            int s = n + Sum(n - 1);
            Console.WriteLine($"Qaytarildi: {s}");
            return s;
        }


        public static int Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }




        static void Main(string[] args)
        {
            //Rekursiya 
            //sum
            // Console.WriteLine(Sum(7));

            //Faktorial
            // Console.WriteLine(Factorial(7));



            //Anogrammalar

            char[] arrChar = new char[100];
            StringBuilder str;
            int size;
            int count;
            void Anagram(int newSize)
            {

                if (newSize == 1) { return; }

                for (int j = 0; j < newSize; j++)
                {
                    Anagram(newSize - 1);
                    if (newSize == 2)
                        Console.WriteLine($"Variant:N{++count} so’z: {str} ");
                    rotate(newSize);
                }
            }
            void rotate(int newSize)
            {
                int j;
                int position = size - newSize;
                char temp = str[position];
                for (j = position + 1; j < size; j++)
                    str[j - 1] = str[j];
                str[j - 1] = temp;
            }


            Console.WriteLine("Satrni kiriting");
            str = new StringBuilder();
            str.Append(Console.ReadLine());
            size = str.Length;
            count = 0;
            Anagram(size);
            Console.ReadKey();


        }
}
}