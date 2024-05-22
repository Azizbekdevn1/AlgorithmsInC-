using System;

class FloydWarshallAlgorithm
{
    static int INF = int.MaxValue; // O'zgaruvchini chegaralash

    static void Main()
    {
        // Yo'naltirilgan grafik matrisini yaratish
        int[,] graph = {
            {0, 2, 4, INF, INF, INF},
            {INF, 0, INF, 3, INF, INF},
            {INF, INF, 0, 1, 3, INF},
            {INF, INF, INF, 0, 6, 2},
            {INF, INF, INF, INF, 0, 1},
            {INF, INF, INF, INF, INF, 0}
        };

        int V = graph.GetLength(0); // Tugunlar sonini aniqlash

        // Floyd-Warshall algoritmini chaqirish
        FloydWarshall(graph, V);
    }

    // Floyd-Warshall algoritmi
    static void FloydWarshall(int[,] graph, int V)
    {
        int[,] dist = new int[V, V]; // Masofalar matrisini yaratish

        // Boshlang'ich masofalar matrisini to'ldirish
        for (int i = 0; i < V; ++i)
        {
            for (int j = 0; j < V; ++j)
            {
                dist[i, j] = graph[i, j];
            }
        }

        // Har bir tugunni topish uchun
        for (int k = 0; k < V; ++k)
        {
            // Har bir tugunni boshlang'ich shaxaraga qo'shish uchun
            for (int i = 0; i < V; ++i)
            {
                // Har bir tugunni tugunlar orasida yuritish uchun
                for (int j = 0; j < V; ++j)
                {
                    // Tugun i dan tugun j gacha yuritilishi uchun qo'shimcha masofa orqali
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        // Natijalarni chiqarish
        PrintSolution(dist, V);
    }

    // Natijalarni chiqarish
    static void PrintSolution(int[,] dist, int V)
    {
        Console.WriteLine("Barcha tugunlar orasidagi eng qisqa yo'l uzunligi:");

        for (int i = 0; i < V; ++i)
        {
            for (int j = 0; j < V; ++j)
            {
                if (dist[i, j] == INF)
                {
                    Console.Write("INF".PadLeft(5));
                }
                else
                {
                    Console.Write(dist[i, j].ToString().PadLeft(5));
                }
            }
            Console.WriteLine();
        }
    }
}
