using System;
using System.Collections.Generic;

namespace LAB06
{
    class Program
    {
        static int n;
        static LinkedList<int>[] adjList;
        static bool[] visited;
        static Stack<int> result;

        public static void ReadData()
        {
            n = int.Parse(Console.ReadLine());
            adjList = new LinkedList<int>[n];
            visited = new bool[n];
            for(int i = 0; i < n; i++)
            {
                adjList[i] = new LinkedList<int>();
                string d = Console.ReadLine();
                if (d == "") continue;
                string[] tokens = d.Split(' ');
                foreach(string number in tokens)
                {
                    if (number == "") break;
                    adjList[i].AddLast(int.Parse(number) - 1);
                }
            }
        }

        public static void TopologicalSort_Util(int s)
        {
            visited[s] = true;
            foreach(int v in adjList[s])
            {
                if(visited[v] == false)
                {
                    TopologicalSort_Util(v);
                }
            }
            result.Push(s);
        }

        public static void TopologicalSort()
        {
            result = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                if(visited[i] == false)
                {
                    TopologicalSort_Util(i);
                }
            }
            foreach(int x in result)
            {
                Console.Write(x + 1 + " ");
            }
        }

        static void Main(string[] args)
        {
            ReadData();
            TopologicalSort();
        }
    }
}
