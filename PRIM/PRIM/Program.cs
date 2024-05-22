using System;

class PrimAlgo
{
    private const int V = 5; // Graf uchun tugunlar soni

    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
        {
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    private void PrintMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Minimal qoldiq daraxti  (MST):");
        Console.WriteLine("Uchlar \t qirralar ");
        for (int i = 1; i < V; i++)
        {
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
        }
    }

    public void PrimMST(int[,] graph)
    {
        int[] parent = new int[V];
        int[] key = new int[V];
        bool[] mstSet = new bool[V];

        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        PrintMST(parent, graph);
    }
}

class Program
{
    static void Main(string[] args)
    {
        PrimAlgo mst = new PrimAlgo();
        int[,] graph = new int[,] {
                {0, 2, 0, 6, 0},
                {2, 0, 3, 8, 5},
                {0, 3, 0, 0, 7},
                {6, 8, 0, 0, 9},
                {0, 5, 7, 9, 0}
            };

        // MST ni topish
        mst.PrimMST(graph);
    }
}

