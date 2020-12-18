using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{
    class Program
    {
        static int n, m;
        static LinkedList<int>[] adj;
        static List<Tuple<int,int>> spanningTree;
        static bool[] visited;



        public static void ReadSpanningTree()
        {
            string[] tokens = Console.ReadLine().Split();
            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            adj = new LinkedList<int>[n + 1];
            spanningTree = new List<Tuple<int, int>>();
            visited = new bool[n + 1];
            for (int i = 1; i <= n; i++)
                adj[i] = new LinkedList<int>();
            for(int i = 1; i <= m; i++)
            {
                tokens = Console.ReadLine().Split();
                adj[int.Parse(tokens[0])].AddLast(int.Parse(tokens[1]));
                adj[int.Parse(tokens[1])].AddLast(int.Parse(tokens[0]));
            }
        }

        public static void SpanningTreeDFS(int s)
        {
         
            visited[s] = true;

            foreach(var edge in adj[s])
            {
               if(visited[edge] == false)
                {
                    spanningTree.Add(new Tuple<int, int>(s, edge));
                    SpanningTreeDFS(edge);
                }
            }
        }
        /*====================================================================================*/
        static int w;
        static List<Tuple<int, int, int>> edgeKruskal;
        static LinkedList<Tuple<int, int, int>> spanningTreeKruskal;

        public static int[] parent;
        public static int[] rank;

        public static int count, cost;

        public static void ReadKruskal()
        {
            string[] tokens = Console.ReadLine().Split();
            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            edgeKruskal = new List<Tuple<int, int,int>>();
         
            for (int i = 1; i <= m; i++)
            {
                tokens = Console.ReadLine().Split();
                int u = int.Parse(tokens[0]);
                int v = int.Parse(tokens[1]);
                int w = int.Parse(tokens[2]);
                edgeKruskal.Add(new Tuple<int, int, int>(u, v, w));
            
            }
        }

        public static void MakeSet(int v)
        {
            parent[v] = v;
            rank[v] = 0;
        }

        public static int Find(int v)
        {
            if (v == parent[v])
                return v;
            return parent[v] = Find(parent[v]);
        }

        public static void Union(int a,int b)
        {
            a = Find(a);
            b = Find(b);
            if (a != b)
            {
                if(rank[a] < rank[b])
                {
                    var t = a;
                    a = b;
                    b = t;
                }
                parent[b] = a;
                if (rank[a] == rank[b])
                    rank[a]++;
            }
        }

        public static void KruskalOptimizer()
        {
            parent = new int[n + 1];
            rank = new int[n + 1];
            for (int i = 1; i <= n; i++) {
                MakeSet(i);
            }

            spanningTreeKruskal = new LinkedList<Tuple<int, int, int>>();
           
            edgeKruskal = edgeKruskal.OrderBy(x => x.Item3).ToList();

             cost = 0;
             count = 0;

            foreach(var e in edgeKruskal)
            {
                int u = e.Item1;
                int v = e.Item2;
                int w = e.Item3;
                if (Find(u) == Find(v)) continue;

                spanningTreeKruskal.AddLast(e);
                cost += w;
                count++;
                if (count == n - 1) break;

                Union(u, v);
            }
        } 

        public static void PrintResultKruskal()
        {
            Console.WriteLine(count + " " + cost);
            foreach(var x in spanningTreeKruskal) {
                Console.Write(x.Item1 + " " + x.Item2 + " " + x.Item3);
                Console.WriteLine();
            }
                
        }

        /*====================================================================================*/

        static List<Tuple<int, int, int>> edgePrim;
        static LinkedList<Tuple<int, int, int>> spanningTreePrim;
        static bool[] selected;

        public static void ReadPrim()
        {
            string[] tokens = Console.ReadLine().Split();
            n = int.Parse(tokens[0]);
            m = int.Parse(tokens[1]);
            edgePrim = new List<Tuple<int, int, int>>();

            for (int i = 1; i <= m; i++)
            {
                tokens = Console.ReadLine().Split();
                int u = int.Parse(tokens[0]);
                int v = int.Parse(tokens[1]);
                int w = int.Parse(tokens[2]);
                edgePrim.Add(new Tuple<int, int, int>(u, v, w));

            }
        }

        public static void Prim()
        {
            selected = new bool[n + 1];
            for (int i = 0; i <= n; i++)
                selected[i] = false;
            selected[1] = true;

            spanningTreePrim = new LinkedList<Tuple<int, int, int>>();
            for(int i = 1; i <= n - 1; i++)
            {
                Tuple<int, int, int> edge = new Tuple<int, int, int>(0, 0, 0);

                foreach (var e in edgePrim)
                {
                    int u = e.Item1;
                    int v = e.Item2;
                    int w = e.Item3;

                    if ((selected[u] == true && selected[v] == false) &&
                        (edge.Item1 == 0 || edge.Item3 > w))
                        edge = new Tuple<int, int, int>(u, v, w);

                    if ((selected[v] == true && selected[u] == false) &&
                        (edge.Item1 == 0 || edge.Item3 > w))
                        edge = new Tuple<int, int, int>(v, u, w);               
                }
                if (edge.Item1 == 0) return;

                selected[edge.Item2] = true;
                spanningTreePrim.AddLast(edge);
                cost += edge.Item3;

            }

        }


        public static void PrintResultPrim()
        {
            Console.WriteLine(spanningTreePrim.Count + " " + cost);
            foreach (var x in spanningTreePrim)
            {
                Console.Write(x.Item1 + " " + x.Item2 + " " + x.Item3);
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            /*Bài 1. Tìm cây khung*/
            //ReadSpanningTree();
            //SpanningTreeDFS(1);
            //Console.WriteLine();

            /*Bài 2. Kruskal */
            //ReadKruskal();
            //KruskalOptimizer();
            //PrintResultKruskal();

            /*Bài 3. Prim*/

            //ReadPrim();
            //Prim();
            //PrintResultPrim();
        }
    }
}
