﻿//using System;
//using System.Collections.Generic;


//namespace ConsoleApp03
//{
//    class Bai03
//    {
//        //Input
//        static long n;
//        static LinkedList<long>[] adj;
//        //Output
//        static LinkedList<long> vertex;
//        static bool[] visited;
//        static Queue<long> q;
//        // DFS
//        static long s, d;
//        static LinkedList<long> vertices;

//        static void Main(string[] args)
//        {
//            ReadFile();
//            //if (IsConnected() == true)
//            //{
//            //    Console.WriteLine("YES");
//            //}
//            //else Console.WriteLine("NO");
//            DFS();
//        }
//        static void ReadFile()
//        {
//            string[] tokens = Console.ReadLine().Split(' ');
//            n = long.Parse(tokens[0]);
//            s = long.Parse(tokens[1]);
//            d = long.Parse(tokens[2]);


//            adj = new LinkedList<long>[n];
//            for (long i = 0; i < n; i++)
//            {
//                adj[i] = new LinkedList<long>();
//            }
//            for (long i = 0; i < n; i++)
//            {
//                string e = Console.ReadLine();
//                if (e == "") continue;
//                string[] tmp = e.Split();
//                foreach (string so in tmp)
//                {
//                    adj[i].AddLast(long.Parse(so) - 1);
//                }
//            }
//        }

//        static void BFS(long x)
//        {
//            //B1: Khởi tạo
//            visited = new bool[n];
//            q = new Queue<long>();
//            for (long i = 0; i < n; i++)
//            {
//                visited[i] = false;
//            }
//            vertex = new LinkedList<long>();
//            //B2: BFS
//            visited[x] = true;
//            q.Enqueue(x);
//            while (q.Count > 0)
//            {
//                long j = q.Dequeue();
//                foreach (long so in adj[j])
//                {
//                    if (visited[so] == false)
//                    {
//                        visited[so] = true;
//                        q.Enqueue(so);
//                        vertex.AddLast(so);
//                    }
//                }
//            }
//        }

//        static bool IsConnected()
//        {
//            BFS(0);
//            for (long i = 0; i < n; i++)
//            {
//                if (visited[i] == false)
//                {
//                    return false;
//                }
//            }
//            return true;

//        }


//        static bool flag = false;
//        static void DFS_Visit(long s)
//        {
//            if(s == d - 1)
//            {
//                flag = true;
//                Console.WriteLine(vertices.Count);
//                foreach(long v in vertices)
//                {
//                    Console.Write(v + 1 + " ");
//                }

//                return ;
//            }
//            visited[s] = true;

//            foreach(long v in adj[s])
//            {
//                if(visited[v] == false)
//                {
//                    vertices.AddLast(v);
//                    DFS_Visit(v);
//                    vertices.Remove(v);
//                }
//            }
//           // visited[s] = false;
//        }

//        static void DFS()
//        {
//            //B1: Khởi tạo
//            visited = new bool[n];           
//            for (long i = 0; i < n; i++)
//            {
//                visited[i] = false;
//            }
//            vertices = new LinkedList<long>();
//            vertices.AddLast(s - 1);

//            DFS_Visit(s - 1);
//            if (!flag)
//            {
//                Console.WriteLine(0);
//            }
//        }      
//    }
//}



using System;
using System.Collections.Generic;


namespace ConsoleApp03
{
    class Bai03
    {
        //Input
        static long n;
        static LinkedList<long>[] adj;
        //Output
        static LinkedList<long> vertex;
        static bool[] visited;
        static Queue<long> q;
        // DFS
        static long x,y;
        static LinkedList<long> vertices;

        static void Main(string[] args)
        {
            ReadFile();
            //if (IsConnected() == true)
            //{
            //    Console.WriteLine("YES");
            //}
            //else Console.WriteLine("NO");
            //CountConnectComponent();
            Process();
        }
        static void ReadFile()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            n = long.Parse(tokens[0]);
            x = long.Parse(tokens[1]);
            y = long.Parse(tokens[2]);




            adj = new LinkedList<long>[n];
            for (long i = 0; i < n; i++)
            {
                adj[i] = new LinkedList<long>();
            }
            for (long i = 0; i < n; i++)
            {
                string e = Console.ReadLine();
                if (e == "") continue;
                string[] tmp = e.Split();
                foreach (string so in tmp)
                {
                    if (so == "") break;
                    adj[i].AddLast(long.Parse(so) - 1);
                }
            }
        }

        static void DFS_Visit(long s)
        {
          
            visited[s] = true;

            foreach (long v in adj[s])
            {
                if (visited[v] == false)
                {
                    DFS_Visit(v);
                    
                }
            }
            // visited[s] = false;
        }

        static void DFS()
        {
            //B1: Khởi tạo
            visited = new bool[n];
            for (long i = 0; i < n; i++)
            {
                visited[i] = false;
            }
            //vertices.AddLast(s - 1);

            //DFS_Visit(s - 1);


        }

        static int count = 0;
        static int CountConnectComponent()
        {
            visited = new bool[n];
            for (long i = 0; i < n; i++)
            {
                visited[i] = false;
            }

            for (long i = 0;i<n;i++)
            {
                if(visited[i] == false)
                {
                    DFS_Visit(i);
                    count++;
                }
            }

            return count;
        }

        static void RemoveEdge()
        {
            long t = x - 1;
            long g = y - 1;
            foreach (long i  in adj[t])
            {
                if (i == g)
                {
                    adj[t].Remove(i);
                    break;
                }
                    
            }

            foreach (long i in adj[g])
            {
                if (i == t)
                {
                    adj[g].Remove(i);
                    break;
                }

            }

        }

        static void Process()
        {
            int preCount = CountConnectComponent();
            RemoveEdge();
            //Console.WriteLine(adj);
            count = 0;
            int lastCount = CountConnectComponent();
            if(preCount == lastCount)
            {
                Console.WriteLine("NO");
            }else
            {
                Console.WriteLine("YES");
            }
        }
    }
}

