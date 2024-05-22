namespace KMPSM
{
    internal class Program
    {
        
		static int KMPSM(string T, string P)
        {
            int i=0,j=0;
            int[] F = new int[P.Length];
            PrefixTable(P);
            while (i < T.Length)
            {
                if (T[i] == P[j])
                {
                   if (j == P.Length - 1) return i - j;
                   else { i++; j++; }
                }
                else if (j > 0) j = F[j - 1];
                else i++;
            }
            return -1;
            void PrefixTable(string P)
        	   {
            		int i = 1, j = 0;
            		while (i < P.Length)
            		{
                		if (P[i] == P[j]) F[i++] = ++j;
                		else if (j > 0) j = F[j - 1];
                		else i++;
            		}
        		}
         
        }
        static void Main(string[] args)
        {
            
            string P = "ababaca";
            string T = "bacbabababacaca";
            int rez=KMPSM(T, P);
            if (rez < 0) Console.WriteLine("P satr ostisi Т da mavjud emas");
            else Console.WriteLine($"Т satrda Р satr ostisi {rez} o’rindan uchraydi");

            Console.ReadKey();
        }
    }
}


