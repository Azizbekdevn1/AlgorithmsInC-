using System;
using System.Collections.Generic;

class KruskalAlgorithm
{
    // Grafikni yaratish uchun tugunlarni belgilash
    static int[] parent;

    // Grafikda bo'lgan to'plamlar
    static List<List<int>> components = new List<List<int>>();

    // Kruskal algoritmi
    static List<Tuple<int, int, int>> Kruskal(int[][] graph)
    {
        List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();

        // Grafik tugunlari soni
        int V = graph.Length;

        // Barcha tugunlarni to'plamlarga ajratish
        for (int i = 0; i < V; i++)
        {
            components.Add(new List<int> { i });
            parent[i] = i;
        }

        // Barcha birlashmalarni ro'yxatga qo'shish
        List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
        for (int i = 0; i < V; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                if (graph[i][j] != 0)
                {
                    edges.Add(new Tuple<int, int, int>(i, j, graph[i][j]));
                }
            }
        }

        // Birlashmalarni masofalar bo'yicha saralash
        edges.Sort((x, y) => x.Item3.CompareTo(y.Item3));

        // Barcha birlashmalarni tekshirish
        foreach (Tuple<int, int, int> edge in edges)
        {
            int u = edge.Item1;
            int v = edge.Item2;
            int weight = edge.Item3;

            // Bo'lmagan birlashmalarni tekshirish
            int setU = FindSet(u);
            int setV = FindSet(v);

            if (setU != setV)
            {
                result.Add(new Tuple<int, int, int>(u, v, weight));
                Union(setU, setV);
            }
        }

        return result;
    }

    // Tugunni qaysi to'plamga tegishli ekanligini aniqlash
    static int FindSet(int i)
    {
        if (parent[i] == i)
            return i;
        return parent[i] = FindSet(parent[i]);
    }

    // Ikkita to'plamni bir-biriga qo'shish
    static void Union(int i, int j)
    {
        parent[i] = j;
    }

    // Natijalarni ko'rsatish
    static void PrintResult(List<Tuple<int, int, int>> result)
    {
        Console.WriteLine("Minimal hosil qilingan grafik:");

        foreach (var edge in result)
        {
            Console.WriteLine($"{edge.Item1 + 1} - {edge.Item2 + 1}: {edge.Item3}");
        }
    }

    static void Main()
    {
        // Grafik
        int[][] graph = {
            new int[] {0, 2, 4, 0, 0, 0},
            new int[] {2, 0, 0, 3, 0, 0},
            new int[] {4, 0, 0, 1, 3, 0},
            new int[] {0, 3, 1, 0, 6, 2},
            new int[] {0, 0, 3, 6, 0, 1},
            new int[] {0, 0, 0, 2, 1, 0},
        };

        // Tugunlarni belgilash
        parent = new int[graph.Length];

        // Minimal hosil qilingan grafikni topish
        List<Tuple<int, int, int>> result = Kruskal(graph);

        // Natijalarni ko'rsatish
        PrintResult(result);
    }
}

