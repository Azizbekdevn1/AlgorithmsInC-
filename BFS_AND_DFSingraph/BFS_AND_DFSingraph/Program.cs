// See https://aka.ms/new-console-template for more information
//Here is graph learing source code 



//    // Hodisa matrisasini qaytaruvchi funksiya
//    public int[,] ConvertToIncidenceMatrix()
//    {
//        int[,] incidenceMatrix = new int[n, m];
//        int edgeIndex = 0;

    //        for (int i = 0; i < n; i++)
    //        {
    //            for (int j = i + 1; j < n; j++)
    //            {
    //                if (Adj[i, j] == 1)
    //                {
    //                    incidenceMatrix[i, edgeIndex] = 1;
    //                    incidenceMatrix[j, edgeIndex] = 1;
    //                    edgeIndex++;
    //                }
    //            }
    //        }

    //        return incidenceMatrix;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int[,] adjacencyMatrix = {
    //            {0, 1},
    //            {0, 3},
    //            {0, 2},
    //            {2, 3},
    //            {2, 4},
    //            {3, 4}
    //        };

    //        GraphAdj graph = new GraphAdj(5, 6, adjacencyMatrix);
    //        graph.Print();

    //        int[,] incidenceMatrix = graph.ConvertToIncidenceMatrix();

    //        Console.WriteLine("\nGrafning hodisa matritsasi:");
    //        for (int i = 0; i < incidenceMatrix.GetLength(0); i++)
    //        {
    //            Console.WriteLine();
    //            for (int j = 0; j < incidenceMatrix.GetLength(1); j++)
    //                Console.Write($"    {incidenceMatrix[i, j]}");
    //            Console.WriteLine();
    //        }
    //    }
    //}

    //DFS VA BFS







namespace DFSGraph
{
    class GraphAdj
    {
        public int n; // uchlar soni
        public int m; // qirralar soni
        public int[,] Adj; // qo’shnilik matritsasi

        public GraphAdj() { }
        public GraphAdj(int n1, int m1, int[,] a)
        {
            n = n1;
            m = m1;
            Adj = new int[n, n];
            for (int i = 0; i < m; i++)
            {
                int v = a[i, 0];
                int u = a[i, 1];
                Adj[v, u] = Adj[u, v] = 1; // n-graf uchun
            }
        }

        public void Print()
        {
            Console.WriteLine("Grafning qo’shnilik matritsasi:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write($"    {Adj[i, j]}");
                Console.WriteLine();
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            int[] DFS(GraphAdj G) //Chuqurlik bo’yicha o’tish
            {
                int k = 0, v, u;
                bool[] Vizit = new bool[G.n];
                int[] V = new int[G.n];
                Stack<int> St = new Stack<int>();

                // Algoritm 1-uchdan boshlanadi
                Vizit[0] = true; V[0] = 0; St.Push(0);
                while (St.Count != 0) // Stek bo’sh bo’lmasa
                {
                    v = St.Peek(); u = -1;
                    for (int j = 0; j < G.n; j++)
                        if (G.Adj[v, j] == 1 && !Vizit[j]) { u = j; break; }
                    if (u == -1) St.Pop();
                    else { Vizit[u] = true; V[++k] = u; St.Push(u); }
                }
                return V;
            }
            int[] DFSREC(GraphAdj G)
            {
                bool[] Vizit = new bool[G.n];
                int[] V = new int[G.n];
                int k = -1;
                void DFSU(GraphAdj G, int v)
                {
                    Vizit[v] = true;
                    V[++k] = v;
                    for (int j = 0; j < G.n; j++)
                        if (G.Adj[v, j] == 1 && !Vizit[j]) DFSU(G, j);

                }
                for (int i = 0; i < G.n; i++)
                    if (Vizit[i] == false) DFSU(G, i);
                return V;
            }
            Console.Write("Graf uchlari sonini kiriting:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Graf qirralari sonini kiriting:");
            int m = int.Parse(Console.ReadLine());
            int[,] vect = new int[m, 2];
            int[] Vertex = new int[n];
            for (int i = 0; i < m; i++)
            {
                Console.Write($" {i + 1} qirraning birinchi uchi raqamini kiriting:");
                vect[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"{i + 1} qirraning ikkinchi uchi raqamini kiriting:");
                vect[i, 1] = int.Parse(Console.ReadLine());
            }
            GraphAdj gAdj = new GraphAdj(n, m, vect);
            gAdj.Print();
            Vertex = DFS(gAdj);
            Console.WriteLine("Grafni chuqurlik bo’yicha o’tish");
            for (int i = 0; i < n; i++)
                Console.Write($"V[{i}]={Vertex[i]}   ");
            Console.ReadKey();
        }
    }
}

