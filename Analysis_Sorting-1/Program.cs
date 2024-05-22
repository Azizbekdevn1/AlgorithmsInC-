namespace Analysis_Sorting_1
{


    internal class Program
    {



        public static void BubbleSort(int[] A)
        {
            int tmp;
            for (int k = A.Length - 1; k >= 0; k--)
            {
                for (int i = 0; i <= k - 1; i++)
                    if (A[i] > A[i + 1])
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                    }
            }
        }

        public static void SBubbleSort(int[] A)
        {
            int tmp, k;
            bool swp = true;
            for (k = A.Length - 1; k >= 0 && swp; k--)
            {
                swp = false;
                for (int i = 0; i <= k - 1; i++)
                    if (A[i] > A[i + 1])
                    {
                        tmp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = tmp;
                        swp = true;
                    }
            }
        }

        public static void SelectionSort(int[] A)
        {
            int min, tmp;
            int n = A.Length;
            for (int i = 0; i < n; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                    if (A[j] < A[min]) min = j;
                tmp = A[min];
                A[min] = A[i];
                A[i] = tmp;
            }
        }

        void InsertionSort(int[] A)
        {
            int i, j, v;
            int n = A.Length;
            for (i = 1; i < n; i++)
            {
                v = A[i]; j = i;
                while (j >= 1 && A[j - 1] > v)
                {
                    A[j] = A[j - 1]; j--;
                }
                A[j] = v;
            }
        }

        public static void ShellSort(int[] A)
        {
            int i, j, v;
            int h = 1;
            int n = A.Length;
            while (h <= n / 3) h = h * 3 + 1;
            while (h > 0)
            {
                for (i = h; i < n; i++)
                {
                    v = A[i]; j = i;
                    while (j > h - 1 && A[j - h] >= v)
                    {
                        A[j] = A[j - h]; j -= h;
                    }
                    A[j] = v;
                }
                h /= 3;
            }
        }





        static void Main(string[] args)   {
            Console.WriteLine("Hello, World!");
            int[] nums = { -23, 52, 642, 86, 123, -76, 98, 0 };
            ShellSort(nums);
            Console.WriteLine("Bubble Sort");
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine("Bubble sort optimal rog'i");
            //SBubbleSort(nums);
            //foreach (int i in nums)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("Selection Sort");
            //SelectionSort(nums);
            //foreach (int i in nums)
            //{
            //    Console.WriteLine(i);
            //}

        }
    }
}