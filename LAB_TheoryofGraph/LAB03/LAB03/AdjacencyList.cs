using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace LAB03
{
    class AdjacencyList
    {
        private LinkedList<int>[] adjList;
        private int nVertex;
        public Queue<int> res = new Queue<int>(100);

        private int x;
        private int y;
        public string s;


        public AdjacencyList()
        {

        }

        public LinkedList<int>[] AdjList { get => adjList; set => adjList = value; }
        public int NVertex { get => nVertex; set => nVertex = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void ReadGraph(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] input = sr.ReadLine().Split(' ');
                NVertex = int.Parse(input[0]);
                X = int.Parse(input[1]);
                AdjList = new LinkedList<int>[NVertex + 10];
                for (int i = 0; i < NVertex; i++)
                {
                    AdjList[i] = new LinkedList<int>();
                    string tmp = sr.ReadLine();
                    if (tmp.Trim().Length == 0)
                    {
                        AdjList[i].AddLast(9999);
                        continue;
                    }
                    string[] tokens = tmp.Split(' ');
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (tokens[j] == "")
                            continue;
                        AdjList[i].AddLast(int.Parse(tokens[j]));
                    }
                }
            }
        }



        public void BFS_Source(int s)
        {
            bool[] visited = new bool[NVertex + 10];
            int[] pre = new int[NVertex + 10];
            int[] distances = new int[NVertex + 10];
            LinkedList<int> vertices = new LinkedList<int>();

            for (int i = 0; i < NVertex; i++)
            {
                visited[i] = false;
                pre[i] = -1;
                distances[i] = 0;
            }

            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            vertices.AddLast(s);

            while (q.Count != 0)
            {
                int u = q.Dequeue();
                res.Enqueue(u);
                //Console.WriteLine(u);
                LinkedList<int> list = AdjList[u - 1];
                foreach (int v in list)
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        q.Enqueue(v);
                        pre[v] = u;
                        distances[v] = distances[u] + 1;
                        vertices.AddLast(v);
                    }
                }
            }
        }

        public void CountInterconnectionVertex(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                res.Dequeue();
                sw.WriteLine(res.Count);
                foreach (int x in res)
                {
                    sw.Write(x + " ");
                }
            }
        }

        public void BFS()
        {
            bool[] visited = new bool[NVertex];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            for (int i = 0; i < NVertex; i++)
            {
                if (visited[i] == false)
                    BFS_Source(i);
            }
        }

        public void CustomReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] input = sr.ReadLine().Split(' ');
                NVertex = int.Parse(input[0]);
                X = int.Parse(input[1]);
                Y = int.Parse(input[2]);
                AdjList = new LinkedList<int>[NVertex + 10];
                for (int i = 0; i < NVertex; i++)
                {
                    AdjList[i] = new LinkedList<int>();
                    string tmp = sr.ReadLine();
                    if (tmp.Trim().Length == 0)
                    {
                        AdjList[i].AddLast(9999);
                        continue;
                    }
                    string[] tokens = tmp.Split(' ');
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        if (tokens[j] == "")
                            continue;
                        AdjList[i].AddLast(int.Parse(tokens[j]));
                    }
                }
            }
        }


        

        public void PrintAllPathFromXToYUtils(int u,int d, bool[] isVisited, List<int> localPathList)
        {
            if (u.Equals(d))
            {
                Console.WriteLine(string.Join(" ",localPathList));
                s = string.Join(" ", localPathList);
                return;
            }
            isVisited[u] = true;
            foreach(int i in AdjList[u - 1])
            {
                if (!isVisited[i])
                {
                    localPathList.Add(i);
                    PrintAllPathFromXToYUtils(i, d, isVisited, localPathList);
                    localPathList.Remove(i);
                }
            }
            isVisited[u] = false;
        }

        public void PrintAllPaths(int s, int d)
        {
            bool[] isVisted = new bool[NVertex + 10];
            List<int> pathList = new List<int>();
            pathList.Add(s);
            PrintAllPathFromXToYUtils(s, d, isVisted, pathList);

        }

        public void writeFileAllPaths(string path)
        {
            string[] listRes = s.Split(' ');
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(listRes.Length);
                foreach(string x in listRes)
                {
                    sw.Write(x + " ");
                }
            }
        }

    }
}
