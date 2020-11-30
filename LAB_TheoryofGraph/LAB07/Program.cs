using System;
using System.Collections.Generic;

namespace Dijsktra
{
    class Program
    {
        static int n, m, s, t;
        static LinkedList<(int, int)>[] adj;
        static int[] pre;
        static int[] dist;
        static bool[] processed;
        static LinkedList<int> path;
        const int INF = (int)1e9;


        // Add for bài 2
        static int x;

        static void ReadData()
        {
            string[] tokens = Console.ReadLine().Split(' ');

            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            s = int.Parse(tokens[2]);
            t = int.Parse(tokens[3]);

            adj = new LinkedList<(int, int)>[n];

            for (int i = 0; i< n; i++)
            {
                adj[i] = new LinkedList<(int, int)>();
            }
            for(int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                if (line == "") continue;
                tokens = line.Split(' ');
                int u = int.Parse(tokens[0]) - 1;
                int v = int.Parse(tokens[1]) - 1;
                int w = int.Parse(tokens[2]);
                adj[u].AddLast((v, w));
                adj[v].AddLast((u, w));
            }
        }

        static void Dijkstra()
        {
            dist = new int[n];
            pre = new int[n];
            processed = new bool[n];

            for(int i = 0; i < n; i++)
            {
                dist[i] = INF;
                pre[i] = -1;
                processed[i] = false;
            }
            dist[s] = 0;
            for(int k = 0; k < n; k++)
            {
                int a = -1;
                int min = INF;
                for(int i = 0; i < n; i++)               
                    if (processed[i] == false && (a == -1 || dist[a] > dist[i]))
                        a =i;
                if (dist[a] == INF) break;
                processed[a] = true;

                foreach(var edge in adj[a])
                {
                    int b = edge.Item1;
                    int w = edge.Item2;
                    if(dist[b] > dist[a] + w)
                    {
                        dist[b] = dist[a] + w;
                        pre[b] = a;
                    }
                }
                
            }
            
        }

        static LinkedList<int> root = new LinkedList<int>();

        static void DijsktraMod()
        {
            dist = new int[n];
            pre = new int[n];
            processed = new bool[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = INF;
                pre[i] = -1;
                processed[i] = false;
            }
            dist[s] = 0;
            for (int k = 0 ; k < x - 1; k++) // Config here
            {
                int a = -1;
                int min = INF;
                for (int i = 0; i < n; i++)
                    if (processed[i] == false && (a == -1 || dist[a] > dist[i]))
                        a = i;

                if (dist[a] == INF) break;
                processed[a] = true;

                foreach (var edge in adj[a])
                {
                    int b = edge.Item1;
                    int w = edge.Item2;
                    if (dist[b] > dist[a] + w)
                    {
                        dist[b] = dist[a] + w;
                        pre[b] = a;
                    }
                }

            }

            int e = x - 1;
            while (pre[e] != -1) // Khi chưa đụng thằng có pre= -1 tức chưa hết
            {
                root.AddFirst(pre[e] + 1);
                e = pre[e];
            }
            root.AddFirst(s);
           
            // Custom

            for (int i = 0; i < n; i++)
            {
                dist[i] = INF;
                pre[i] = -1;
                processed[i] = false;
            }
            dist[s] = 0;
            for (int k = x -1 ; k < n; k++) // Config here
            {
                int a = -1;
                int min = INF;
                for (int i = 0; i < n; i++)
                    if (processed[i] == false && (a == -1 || dist[a] > dist[i]))
                        a = i;

                if (dist[a] == INF) break;
                processed[a] = true;

                foreach (var edge in adj[a])
                {
                    int b = edge.Item1;
                    int w = edge.Item2;
                    if (dist[b] > dist[a] + w)
                    {
                        dist[b] = dist[a] + w;
                        pre[b] = a;
                    }
                }

            }

            foreach(var x in root)
            {
                Console.Write(x + " ");
            }
        }

       

        static void processPreviousPath()
        {
            path = new LinkedList<int>();
            int e = t; // Lấy đỉnh kết thúc 
            t = t - 1; // Trong danh sách đánh số từ 0 nên phải trừ 1 để đủ size cho Graph
            path.AddLast(e);

            while (pre[t] != -1) // Khi chưa đụng thằng có pre= -1 tức chưa hết
            {
                path.AddFirst(pre[t] + 1); // Add First để đảo chiều
                t = pre[t];
            }
            path.AddFirst(s);

            Console.WriteLine(dist[s-1] + dist[e-1]);
            foreach(var x in path)
            {
                Console.Write(x + " ");
            }

        }

        static void ReadDataGraph()
        {
            string[] tokens = Console.ReadLine().Split(' ');

            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            s = int.Parse(tokens[2]);
            t = int.Parse(tokens[3]);
            x = int.Parse(tokens[4]);

            adj = new LinkedList<(int, int)>[n];

            for (int i = 0; i < n; i++)
            {
                adj[i] = new LinkedList<(int, int)>();
            }
            for (int i = 0; i < m; i++)
            {
                string line = Console.ReadLine();
                if (line == "") continue;
                tokens = line.Split(' ');
                int u = int.Parse(tokens[0]) - 1;
                int v = int.Parse(tokens[1]) - 1;
                int w = int.Parse(tokens[2]);
                adj[u].AddLast((v, w));
                adj[v].AddLast((u, w));
            }
        }


        static void Main(string[] args)
        {
            /* Bài 1. Đường đi ngắn nhất */
            //ReadData();
            //Dijkstra();
            //processPreviousPath();

            /* Bài 2.  Đường đi ngắn nhất qua đỉnh trung gian 
             * Chỉ cần chạy Dijsktra từ s-> x rồi chạy từ x -> t là ra 
             */
            ReadDataGraph();
            //DijsktraModStart();
            DijsktraMod();
        }
    }
}
