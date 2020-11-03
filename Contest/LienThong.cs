using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Buoi_03
{
    class Bai03
    {
        //Input
        static int n;
        static LinkedList<int>[] adj;
        //Output
        static LinkedList<int> vertex;
        static bool[] visited;
        static Queue<int> q;

        static void Main(string[] args)
        {
            ReadFile();
            if (IsConnected() == true)
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");
        }

        static void ReadFile()
        {
            n = int.Parse(Console.ReadLine());
            adj = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new LinkedList<int>();
            }
            for (int i = 0; i < n; i++)
            {
                string d = Console.ReadLine();
                if (d == "") continue;
                string[] tmp = d.Split();
                foreach (string so in tmp)
                {
                    adj[i].AddLast(int.Parse(so) - 1);
                }
            }
        }

        static void BFS(int x)
        {
            //B1: Khởi tạo
            visited = new bool[n];
            q = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
            }
            vertex = new LinkedList<int>();
            //B2: BFS
            visited[x] = true;
            q.Enqueue(x);
            while (q.Count > 0)
            {
                int j = q.Dequeue();
                foreach (int so in adj[j])
                {
                    if (visited[so] == false)
                    {
                        visited[so] = true;
                        q.Enqueue(so);
                        vertex.AddLast(so);
                    }
                }
            }
        }

        static bool IsConnected()
        {
            BFS(0);
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == false)
                {
                    return false;
                }
            }
            return true;
            
        }
    }
}
