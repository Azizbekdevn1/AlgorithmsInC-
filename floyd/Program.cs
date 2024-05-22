//Here is Floyd alogoritm source code 
using System;

public class FloydAlgorithm
{
    public static void FloydWarshall(int[,] graph, int vertices)
    {
        int[,] distance = new int[vertices, vertices];

        // Barcha orqaga o'tkazmalarni uchun boshlang'ich masofalarni o'lchash
        for (int i = 0; i < vertices; ++i)
            for (int j = 0; j < vertices; ++j)
                distance[i, j] = graph[i, j];

        // Har bir node uchun quyidagi ifodani bajaramiz:
        // Agar uchta node i, j va k o'rtasida o'zaro bog'lanish bo'lsa,
        for (int k = 0; k < vertices; ++k)
            for (int i = 0; i < vertices; ++i)
                for (int j = 0; j < vertices; ++j)
                    if (distance[i, k] != int.MaxValue && distance[k, j] != int.MaxValue &&
                        distance[i, k] + distance[k, j] < distance[i, j])
                        distance[i, j] = distance[i, k] + distance[k, j];

        // Natijalarni chiqaramiz
        Console.WriteLine("Floyd Warshall algoritmi natijalari:");
        for (int i = 0; i < vertices; ++i)
        {
            for (int j = 0; j < vertices; ++j)
            {
                if (distance[i, j] == int.MaxValue)
                    Console.Write("inf\t");
                else
                    Console.Write(distance[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        int[,] graph = {
            {0, 5, 10, int.MaxValue},
            {int.MaxValue, 0, 3, 20},
            {int.MaxValue, int.MaxValue, 0, 1},
            {int.MaxValue, int.MaxValue, int.MaxValue, 0}
        };

        int vertices = 4;

        FloydWarshall(graph, vertices);
    }
}
