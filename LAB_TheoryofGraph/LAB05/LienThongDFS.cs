

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
        static long s;
        static LinkedList<long> vertices;

        static void Main(string[] args)
        {
            ReadFile();
            //if (IsConnected() == true)
            //{
            //    Console.WriteLine("YES");
            //}
            //else Console.WriteLine("NO");
            DFS();
        }
        static void ReadFile()
        {
            string[] tokens = Console.ReadLine().Split(' ');
            n = long.Parse(tokens[0]);
            s = long.Parse(tokens[1]);
         


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
                    adj[i].AddLast(long.Parse(so) - 1);
                }
            }
        }

        static HashSet<long> myHash;
        static void DFS_Visit(long s)
        {
          
            visited[s] = true;

            foreach (long v in adj[s])
            {
                if (visited[v] == false)
                {
                    myHash.Add(v + 1);
                    vertices.AddLast(v);
                    DFS_Visit(v);
                    
                    vertices.Remove(v);
                }
            }
            // visited[s] = false;
        }

        static void DFS()
        {
            //B1: Khởi tạo
            visited = new bool[n];
            myHash = new HashSet<long>();
            for (long i = 0; i < n; i++)
            {
                visited[i] = false;
            }
            vertices = new LinkedList<long>();
            vertices.AddLast(s - 1);

            DFS_Visit(s - 1);


            if(myHash.Count == 0)
            {
                Console.WriteLine(0);
            } else
            {
                Console.WriteLine(myHash.Count);
                foreach (long i in myHash)
                {
                    Console.Write(i + " ");
                }
            }

            
           
            
        }
    }
}
