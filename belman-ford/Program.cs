using System;

public class BellmanFordAlgorithm
{
    public static void BellmanFord(int[,] graph, int vertices, int source)
    {
        int[] distance = new int[vertices];

        // Barcha bo'lmalar uchun boshlang'ich masofalar inf
        for (int i = 0; i < vertices; ++i)
            distance[i] = int.MaxValue;

        // Boshlang'ich tug'unlik bo'lmasi
        distance[source] = 0;

        // Har bir bo'lmaga yo'l uchun masofani yangilash
        for (int i = 0; i < vertices - 1; ++i)
        {
            for (int j = 0; j < vertices; ++j)
            {
                for (int k = 0; k < vertices; ++k)
                {
                    if (graph[j, k] != 0 && distance[j] != int.MaxValue && distance[j] + graph[j, k] < distance[k])
                    {
                        distance[k] = distance[j] + graph[j, k];
                    }
                }
            }
        }

        // Negativ devorlar uchun tekshirish
        for (int j = 0; j < vertices; ++j)
        {
            for (int k = 0; k < vertices; ++k)
            {
                if (graph[j, k] != 0 && distance[j] != int.MaxValue && distance[j] + graph[j, k] < distance[k])
                {
                    Console.WriteLine("Negativ qadam mavjut");
                    return;
                }
            }
        }

        // Natijalarni chiqarish
        Console.WriteLine("Belman-Ford algoritmi natijalari:");
        for (int i = 0; i < vertices; ++i)
        {
            Console.WriteLine("Uchi " + i + " gacha masofa: " + distance[i]);
        }
    }

    public static void Main(string[] args)
    {
        int vertices = 7; // Bo'lmalar soni
        int[,] graph = {
            {0, 6, 5, 4,0,0,0},
            {0, 0, 0, 0,-1,0,0},
            {0, -2, 0, 0,5,0,0},
            {0, 0, -2, 0,0,-1,0},
            {0,0,0,0,0,0,3},
            {0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0}
        };

        int source = 0; // Boshlang'ich tug'unlik bo'lmasis

        BellmanFord(graph, vertices, source);
    }
}
