using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB04
{
    class CustomComponent
    {
        private int nVertex;
        private int x;
        private int y;
        private int z;
        LinkedList<int>[] adjList;

        public int NVertex { get => nVertex; set => nVertex = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public LinkedList<int>[] AdjList { get => adjList; set => adjList = value; }
        public int Z { get => z; set => z = value; }

        public CustomComponent() { }

        public void ReadDataGraph(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] input = sr.ReadLine().Split(' ');
                NVertex = int.Parse(input[0]);
                X = int.Parse(input[1]);
                Y = int.Parse(input[2]);
                AdjList = new LinkedList<int>[NVertex + 10];

                for(int i = 1; i <= NVertex; i++)
                {
                    AdjList[i] = new LinkedList<int>();
                    string line = sr.ReadLine();
                    if (line == null) continue;
                    if (line.Trim().Length == 0 )
                        continue;
                    string[] tokens = line.Split(' ');
                    for(int j = 0; j < tokens.Length; j++)
                    {
                        if (tokens[j] == " " || tokens[j] == "")
                            continue;
                        AdjList[i].AddLast(int.Parse(tokens[j]));

                    }
                }
            }
        }

        public void CustomReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] input = sr.ReadLine().Split(' ');
                NVertex = int.Parse(input[0]);
                Z = int.Parse(input[1]);
                AdjList = new LinkedList<int>[NVertex + 10];

                for (int i = 1; i <= NVertex; i++)
                {
                    AdjList[i] = new LinkedList<int>();
                    string line = sr.ReadLine();
                    if (line == null) continue;
                    if (line.Trim().Length == 0)
                        continue;
                    string[] tokens = line.Split(' ');
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (tokens[j] == " " || tokens[j] == "")
                            continue;
                        AdjList[i].AddLast(int.Parse(tokens[j]));

                    }
                }
            }
        }


        public void BFS_Vertex(int s,bool[]visited)
        {
            
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            while (queue.Count != 0)
            {
                int u = queue.Dequeue();
                if (AdjList[u] == null) continue; 
                foreach(int v in AdjList[u])
                {
                    if (visited[v]) continue;
                    visited[v] = true;
                    queue.Enqueue(v);
                }
            }
        }

        public int CountConnectedComponent()
        {
            bool[] visited = new bool[NVertex + 1];
            int count = 0;
            for (int i = 0; i < NVertex + 1; i++)
                visited[i] = false;
            for (int i = 1; i < NVertex+1 ; i++)
            {
                if(visited[i]== false)
                {
                    BFS_Vertex(i, visited);
                    count++;
                }
            }
            return count;
        }

        public void RemoveEdge()
        {
            Console.WriteLine(AdjList);
            for (int i = 0; i < AdjList.Length; i++)
            {
                AdjList[x].Remove(y);
                AdjList[y].Remove(x);
            }
            Console.WriteLine(AdjList);
        }

        public void IsBridge(string path)
        {
            int beforeCount = CountConnectedComponent();
            RemoveEdge();
            int afterCount = CountConnectedComponent();
            using(StreamWriter sw = new StreamWriter(path))
            {
                if (afterCount > beforeCount)
                    sw.Write("YES");
                else
                    sw.Write("NO");       
            }
        }

        public void IsCutVertex(string path)
        {
            int beforeCount = CountConnectedComponent();
            AdjList[Z] = null;
            int afterCount = CountConnectedComponent();
            using (StreamWriter sw = new StreamWriter(path))
            {
                if (afterCount - beforeCount >= 2)
                    sw.Write("YES");
                else
                    sw.Write("NO");
            }
        }



    }
}
