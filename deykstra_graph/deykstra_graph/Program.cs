//


using System;
using System.Collections.Generic;
using System.Linq;

class DijkstraAlgorithm
{
    // Dijkstra algoritmi uchun grafikni hisoblash funksiyasi
    static Dictionary<int, Dictionary<int, int>> Graph = new Dictionary<int, Dictionary<int, int>>();
    // Grafikka yangi birlashma qo'shish funksiyasi
    static void AddEdge(int source, int destination, int weight)
    {
        if (!Graph.ContainsKey(source))
            Graph[source] = new Dictionary<int, int>();

        Graph[source].Add(destination, weight);
    }

    // Dijkstra algoritmi
    static Dictionary<int, int> Dijkstra(int start)
    {;
        // Shaharlarning masofalarini saqlash uchun ro'yxat
        Dictionary<int, int> distances = new Dictionary<int, int>();
        HashSet<int> unvisited = new HashSet<int>(Graph.Keys);

        // Barcha shaharlarni boshlang'ich masofaga o'rnating
        foreach (int vertex in Graph.Keys)
        {
            if (vertex == start)
                distances[vertex] = 0; // Boshlang'ich shahar uchun masofa 0
            else
                distances[vertex] = int.MaxValue; // Boshqa shaharlar uchun infinity masofa
            unvisited.Add(vertex); // Barcha shaharlarni unvisited ro'yxatiga qo'shish
        }

        // Ochiq shaharlarni tekshirish
        while (unvisited.Count >0)
        {
            int current = unvisited.Min(); // Eng yaqin shaharni aniqlash
            unvisited.Remove(current); // Ochiq shaharni unvisited ro'yxatidan olib tashlash

            // Boshqa shaharlarga yo'l yo'q bo'lgan shaharlarni qarzda qoldirmaslik uchun tekshirish qo'shing
            if (!Graph.ContainsKey(current))
                continue;

            foreach (int neighbor in Graph[current].Keys)
            {
                // Mavjud bo'lmagan kalitlarni tekshirish
                if (!distances.ContainsKey(neighbor))
                    continue;

                int distance = distances[current] + Graph[current][neighbor];
                if (distance < distances[neighbor])
                    distances[neighbor] = distance;
            }
        }


        return distances;
    }
    static void Main()
    {
        // Grafikni yaratish
        AddEdge(1, 2, 5); // Shahar 1 dan Shahar 2 gacha masofa 5
        AddEdge(1, 3, 9); // Shahar 1 dan Shahar 3 gacha masofa 9
        AddEdge(1, 4, 2); // Shahar 1 dan Shahar 4 gacha masofa 2
        AddEdge(2, 5, 2); // Shahar 2 dan Shahar 5 gacha masofa 2
        AddEdge(3, 6, 3); // Shahar 3 dan Shahar 6 gacha masofa 3
        AddEdge(4, 6, 9); // Shahar 4 dan Shahar 6 gacha masofa 9
        AddEdge(5, 6, 3); // Shahar 5 dan Shahar 6 gacha masofa 2
        AddEdge(6, 5, 3);

        // Boshlang'ich shahar
        int start = 1;
        // Ochiq ro'yxat bo'ylab Dijkstra algoritmini bajarish
        Dictionary<int, int> distances = Dijkstra(start);

        // Natijalarni ekranga chiqarish
        Console.WriteLine("Shahar\t\tMasofa boshlang'ich shahardan");
        foreach (KeyValuePair<int, int> kvp in distances)
        {
            Console.WriteLine($"{kvp.Key}\t\t{kvp.Value}");
        }
    }


}

