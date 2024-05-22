




//Graph tasvirlash usullarini analiz qilamiz 

//1.Qo'shnilik matritsasi yordamida tasvirlash 


using System.Runtime.Intrinsics.X86;

class GraphAdj
{
    public int n; // uchlar soni
    public int m;  // qirralar soni
    public int[,] Adj; //qo’shnilik matritsasi
    public GraphAdj() { }
    public GraphAdj(int n1, int m1, int[,] a)
    {
        n = n1;
        m = m1;
        int u, v;
        Adj = new int[n, n];
        for (int i = 0; i < m; i++)
        {
            v = a[i, 0]; u = a[i, 1];
            Adj[v, u] = Adj[u, v] = 1; //n-graf uchun
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
                Console.Write($"    {Adj[i, j]}");
            Console.WriteLine();
        }
    }
}

//2.Hodisa matritsasi orqali tasvirlash 

class GraphInc
{
    public int n; // uchlar soni
    public int m;  // qirralar soni
    public int[,] Inc; //qo’shnilik matritsasi
    public GraphInc() { }
    public GraphInc(int n1, int m1, int[,] a)
    {
        n = n1;
        m = m1;
        int u, v;
        Inc = new int[n, m];
        for (int i = 0; i < m; i++)
        {
            v = a[i, 0]; u = a[i, 1];
            Inc[v, i] = Inc[u, i] = 1; //n -graf uchun
                                       // Inc[v,i] =1; Inc[u,i]] =- 1; //orgraf uchun 
        }
    }
    public void Print()
    {
        Console.WriteLine("Grafni hodisa matritsasi:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < m; j++)
            Console.Write($"    {Inc[i, j]}");
            Console.WriteLine();
        }
    }
}

//3.Qo'shnilik ro'yhati orqali tasvirlash

// qo’shnikik matritsasi bitta elementini tuzilmasi
class NodeAdj
{
    public int num;// uch raqami
    public int ves;// vaznlangan graf uchun 
    public NodeAdj next;// keyingi uch uchun ko’rsatkich
}
// qo’shnilik matritsasi orqali grafning tasvirlanishi
class GraphAdjList
{
    public int n;  // uchlar soni
    public int m;  // qirralar soni
    public NodeAdj[] Adj; //qo’shnilikning dinamik ro’yxati
    public GraphAdjList() { }
    public GraphAdjList(int n1, int m1, int[,] a)
    {
        n = n1;
        m = m1;
        Adj = new NodeAdj[n];
        int u, v;
        for (int i = 0; i < n; i++)
        {
            Adj[i] = new NodeAdj();
            Adj[i].num = i;
        }
        for (int i = 0; i < m; i++)
        {
            v = a[i, 0]; u = a[i, 1];
            var tmp = new NodeAdj();
            tmp.num = v;
            if (Adj[u].next != null) tmp.next = Adj[u].next;
            Adj[u].next = tmp;
            tmp = new NodeAdj();
            tmp.num = u;
            if (Adj[v].next != null) tmp.next = Adj[v].next;
            Adj[v].next = tmp;
        }
    }
    public void Print()
    {
        Console.WriteLine("Grafning qo’shnilik matritsasi:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            NodeAdj tmp = Adj[i];
            while (tmp != null)
            {
                Console.Write($"   {tmp.num}");
                tmp = tmp.next;
            }
            Console.WriteLine();
        }
    }
}


//4.Grafni qirralarning roʻyxati orqali tasvirlash.


// qirralarning ro'yxatining bir elementining tuzilishi
struct Edge
{
    public int beg;// bo’shlanish uchi raqami
    public int end;// oxirgi uchi raqami
    public int ves; // vaznlangan graf uchun qirra vazni
}



//Qo’shnilik ro’yxati orqali graf tasviri
class GraphEdge
{
    public int n;  // uchlar soni
    public int m;  // qirralar soni
    public Edge[] Edg; //qo’shnilikning dinamik ro’yxati
    public GraphEdge() { }
    public GraphEdge(int n1, int m1, int[,] a)
    {
        n = n1;
        m = m1;
        Edg = new Edge[m];
        int u, v;
        for (int i = 0; i < m; i++)
        {
            v = a[i, 0]; u = a[i, 1];
            Edg[i].beg = v; Edg[i].end = u;
        }
    }
    public void Print()
    {
        Console.WriteLine("Grafning qirralari ro’yxati:");
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Qirra:{i},  Uchlari:  {Edg[i].beg}  {Edg[i].end}");
        }
    }


    public static void GraphEdgeToGraphAdj(GraphEdge GE, GraphAdj GMA)
    {
        int u, v;
        GMA.n = GE.n; GMA.m = GE.m;
        GMA.Adj = new int[GMA.n, GMA.n];
        for (int i = 0; i < GE.m; i++)
        {
            v = GE.Edg[i].beg; u = GE.Edg[i].end;
            GMA.Adj[v, u] = GMA.Adj[u, v] = 1; // n -graf uchun
                                               // GMA.Adj[v,u] =1; GMA.Adj[u,v] = -1; //orgraf uchun 
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Graf uchlar sonini kiriting:");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Graf qirralari sonini kiriting:");
        int m = int.Parse(Console.ReadLine());
        int[,] vect = new int[m, 2];
        for (int i = 0; i < m; i++)
        {
            Console.Write($" {i + 1} qirraning birinchi uchi raqamini kiriting:");
            vect[i, 0] = int.Parse(Console.ReadLine());
            Console.Write($"{i + 1} qirraning ikkinchi uchi raqamini kiriting:");
            vect[i, 1] = int.Parse(Console.ReadLine());
        }
        GraphAdj gAdj = new GraphAdj(n, m, vect);
        gAdj.Print();
        GraphInc gInc = new GraphInc(n, m, vect);
        gInc.Print();
        GraphAdjList gAdjList = new GraphAdjList(n, m, vect);
        gAdjList.Print();
        GraphEdge gEdge = new GraphEdge(n, m, vect);
        gEdge.Print();
        GraphAdj gAdj1 = new GraphAdj();
        GraphEdgeToGraphAdj(gEdge, gAdj1);
        gAdj1.Print();
        Console.ReadKey();
    }

}



