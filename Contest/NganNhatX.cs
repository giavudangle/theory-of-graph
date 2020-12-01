using System;
using System.Collections.Generic;

namespace Dijsktra
{
    class Program
    {
        static int n, m, s, t;
        static LinkedList<Tuple<int,int>>[] adj;
        static int[] pre;
        static int[] dist;
        static bool[] processed;
        static LinkedList<int> path;
        const int INF = (int)1e9;


        // Add for bài 2
        static int x;
        static LinkedList<int> pathFromX;
        static LinkedList<int> pathToY;
        static int totalCost = 0;

        static void ReadData()
        {
            string[] tokens = Console.ReadLine().Split(' ');

            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            s = int.Parse(tokens[2]);
            t = int.Parse(tokens[3]);

            adj = new LinkedList<Tuple<int, int>>[n + 1];

            for (int i = 1; i <= n; i++)
            {
                adj[i] = new LinkedList<Tuple<int, int>>();
            }
            for (int i = 1; i <= m; i++)
            {
                string line = Console.ReadLine();
                if (line == "") continue;
                tokens = line.Split(' ');
                int u = int.Parse(tokens[0]);
                int v = int.Parse(tokens[1]);
                int w = int.Parse(tokens[2]);
                adj[u].AddLast(new Tuple<int, int>(v, w));
                adj[v].AddLast(new Tuple<int, int>(u, w));
            }
        }

        static void Dijkstra(int start)
        {
            dist = new int[n + 1];
            pre = new int[n + 1];
            processed = new bool[n + 1];

            for (int i = 1; i <= n; i++)
            {
                dist[i] = INF;
                pre[i] = -1;
                processed[i] = false;
            }
            dist[start] = 0;

            for (int k = 1; k <= n; k++)
            {
                int a = -1;            
                for (int i = 1; i <= n; i++)
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

        }

        static void FindPreviousPath()
        {
            path = new LinkedList<int>();
            
            for (int i = t ; i != -1; i = pre[i] )           
                path.AddFirst(i);
            
            foreach (int z in path)           
                Console.Write(z + " ");
        }

        static void ReadDataGraph()
        {
            string[] tokens = Console.ReadLine().Split(' ');

            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            s = int.Parse(tokens[2]);
            t = int.Parse(tokens[3]);
            x = int.Parse(tokens[4]);

            adj = new LinkedList<Tuple<int, int>>[n + 1];

            for (int i = 1; i <= n; i++)
            {
                adj[i] = new LinkedList<Tuple<int, int>>();
            }
            for (int i = 1; i <= m; i++)
            {
                string line = Console.ReadLine();
                if (line == "") continue;
                tokens = line.Split(' ');
                int u = int.Parse(tokens[0]);
                int v = int.Parse(tokens[1]);
                int w = int.Parse(tokens[2]);
                adj[u].AddLast(new Tuple<int, int>(v, w));
                adj[v].AddLast(new Tuple<int, int>(u, w));
            }
        }


        static void Main(string[] args)
        {
            /* Bài 1. Đường đi ngắn nhất */
            //ReadData();
            //Dijkstra(s);
            //Console.WriteLine(dist[t]);
            //FindPreviousPath();

            /* Bài 2.  Đường đi ngắn nhất qua đỉnh trung gian 
             * Chỉ cần chạy Dijsktra từ s-> x rồi chạy từ x -> t là ra 
             */
            ReadDataGraph();
            /*Chạy Dijsktra từ S -> X*/
            Dijkstra(s);
            totalCost = dist[x];
            pathFromX = new LinkedList<int>();
            for (int i = x; i != -1; i = pre[i])            
                pathFromX.AddFirst(i);            
            Dijkstra(x);
            totalCost += dist[t];
            pathToY = new LinkedList<int>();
            for (int i = t; i != -1; i = pre[i])
                pathToY.AddFirst(i);
            Console.WriteLine(totalCost);
            pathToY.RemoveFirst();
            foreach (int item in pathFromX)
                Console.Write(item + " ");
            foreach (int item in pathToY)
                Console.Write(item + " ");





        }
    }

    class FloydWarshall
    {
        public int n { get; set; }


    }
}
