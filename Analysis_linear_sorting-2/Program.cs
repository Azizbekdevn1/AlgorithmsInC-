namespace Analysis_linear_sorting_2
{
    internal class Program
    {

        public static void CountSort(int[] A, int m)
        {
            int i, j, n = A.Length;
            int[] C = new int[m];
            int[] B = new int[n];
            for (j = 0; j < m; j++) C[j] = 0;
            for (i = 0; i < n; i++) C[A[i]]++;
            for (j = 1; j < m; j++) C[j] += C[j - 1];
            for (i = n - 1; i >= 0; i--) B[C[A[i]]-- - 1] = A[i];
            for (i = 0; i < n; i++) A[i] = B[i];
        }

        public static void RadixSort(int[] A, int M)
        {
            int i, j, k, d, n = A.Length;
            int[] C = new int[10];
            int[] B = new int[n];
            for (k = 1, d = 0; d < M; d++, k *= 10)
            {
                for (j = 0; j < 10; j++) C[j] = 0;
                for (i = 0; i < n; i++) C[A[i] / k % 10]++;
                for (j = 1; j < 10; j++) C[j] += C[j - 1];
                for (i = n - 1; i >= 0; i--) B[C[A[i] / k % 10]-- - 1] = A[i];
                for (i = 0; i < n; i++) A[i] = B[i];
            }

        }

        public void BucketSort(int[] A)
        {
            int max = A.Length;
            int[][] bucket = new int[10][];
            for (int i = 0; i < 10; i++)
                bucket[i] = new int[max + 1];
            for (int i = 0; i < 10; i++) bucket[i][max] = 0;
            for (long digit = 1; digit <= 1000000; digit *= 10)
            {
                for (int i = 0; i < max; i++)
                {
                    int d = (int)((long)A[i] / digit) % 10;
                    bucket[d][bucket[d][max]++] = A[i];
                }
                int idx = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < bucket[i][max]; j++)
                    {
                        A[idx++] = bucket[i][j];
                    }
                    bucket[i][max] = 0;
                }
            }
        }








        static void Main(string[] args)
        {
            //Hisoblash orqali tartiblash
            int[] nums = new int[10];
            Random n = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = n.Next(100,400);
            }
            string unsortedArray = string.Join(" ,", nums);
            Console.WriteLine("Tartiblanmagan massiv:" + unsortedArray);

            CountSort(nums, 400);
            string sortedArray = string.Join(" ,", nums);
            Console.WriteLine("Tartiblangan massiv:" + sortedArray);

            //RadixSort(nums, 3);
            //string sortedArray1 = string.Join(" ,", nums);
            //Console.WriteLine("Tartiblangan massiv:" + sortedArray1);

        }
    }
}



