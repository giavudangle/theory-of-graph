
using System;
using System.Collections.Generic;


namespace ConsoleApp03
{
    class Bai03
    {
        //Input
        static long n;
        static LinkedList<long>[] adj;
        static bool[] visited;
        static int[] color;

        static void Main(string[] args)
        {
            ReadFileNew();
            Process();
        }

        static void ReadFileNew()
        {       
            n = long.Parse(Console.ReadLine());
            adj = new LinkedList<long>[n];
            color = new int[n];
            visited = new bool[n];
            for(int i = 0; i < n; i++)
            {
                adj[i] = new LinkedList<long>();
            }

            for (long i = 0; i < n; i++)
            {
                color[i] = -1;
              
                string e = Console.ReadLine();
                if (e == "") continue;
                string[] tmp = e.Split(' ');
                foreach(string num in tmp)
                {
                    if (num == "") break;
                    adj[i].AddLast(int.Parse(num) - 1);
                }
            }
        }

        static void Process()
        {
            int s = 0;
            visited[s] = true;
            color[s] = 0;
            bool z = false;
            for(int i = 0; i < n; i++)
            {
                z = isBipartite(i);
            }
            if (z)
            {
                Console.WriteLine("YES");
            }else
            {
                Console.WriteLine("NO");
            }
        }

        static bool isBipartite(int v)
        {
            foreach (int u in adj[v])
            {
                if (visited[u] == false)
                {             
                    visited[u] = true;
                    color[u] = 1 - color[v];
                    if (!isBipartite( u))
                        return false;
                }        
                else if (color[u] == color[v])
                    return false;
            }
            return true;
        }

    }
}