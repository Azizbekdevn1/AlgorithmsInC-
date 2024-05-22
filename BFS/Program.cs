//Here is BFS in graph 



using System;
using System.Collections.Generic;

namespace BFSGraph
{
    class GraphAdj
    {
    public int n; // uchlar soni
    public int m;  // qirralar soni
    public int [,] Adj; //qo’shnilik matritsasi
    public GraphAdj() { }

    public GraphAdj(int n1,int m1,int [,]a)
    {
        n = n1;
        m = m1;
        int u, v;
        Adj = new int[n, n];
        for (int i = 0; i < m; i++)
        {
            v = a[i, 0]; u=a[i,1];
            Adj[v,u] = Adj[u,v] = 1; //n-graf uchun
        // Adj[v,u] =1; Adj[u,v] = -1; //orgraf uchun  
        }
    }
    

    public void Print()
    {
        Console.WriteLine("Grafning qo’shnilik matritsasi:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < n; j++)
               Console.Write($" {Adj[i, j]} ");
            Console.WriteLine();
         }
       }
   }
    class Program
    {
        static void Main(string[] args)
        {
            int[] BFS(GraphAdj G) // Kenglik bo’yicha o’tish
            {
                int k = 0, v, u;
                bool[] Vizit = new bool[G.n];
                int[] V = new int[G.n];
                Queue<int> Qu = new Queue<int>();

                // Algoritm 0 - uchdan boshlanadi
                Vizit[0] = true; V[0] = 0; Qu.Enqueue(0);
                while (Qu.Count != 0) // Navbat bo’shamagunga qadar
                {
                    v = Qu.Dequeue(); u = -1;
                    for (int j = 0; j < G.n; j++)
                        if (G.Adj[v, j] == 1 && !Vizit[j]) { 
                            u = j; Vizit[u] = true; 
                            V[++k] = u; Qu.Enqueue(u);
                        }
                }
                return V;
            }http://azizbek.daadoo.live/
            
            Console.Write("Graf uchlari sonini kiriting:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Graf qirralar sonini kiriting:");
            int m = int.Parse(Console.ReadLine());
            int[,] vect = new int[m, 2];
            int[] Vertex = new int[n];
            for (int i = 0; i < m; i++)
            {
                Console.Write($"{i + 1} - qirraning birinchi uchi raqamini kiriting:");
                vect[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"{i + 1} - qirraning ikkinchi uchi raqamini kiriting:");
                vect[i, 1] = int.Parse(Console.ReadLine());
            }
            GraphAdj gAdj = new GraphAdj(n, m, vect);
            gAdj.Print();
            Vertex = BFS(gAdj);
            Console.WriteLine("Kenglik bo’yicha o’tish");
            for (int i = 0; i < n; i++)
                Console.Write($"V[{i}]={Vertex[i]}   ");
            Console.ReadKey();
        }
    }
}
