using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB03
{
    class GraphChecker
    {
        /*
            -> Một đồ thị được gọi là liên thông ( connected ) nếu có đường đi giữa mọi cặp đỉnh phân biệt của đồ thị
            -> Nói cách khác là từ một đỉnh có thể có đường đi tới tất cả các đỉnh khác
            -> Directed or undirected same as meaning
         */
        /*
            -> Nếu xét về có hướng ( directed ) : sẽ có 2 khái niệm
            -> Liên thông mạnh ( strongly connected ) : Nếu có đường đi từ A -> B và từ B -> A với mọi cặp đỉnh A,B của G
            -> Liên thông yếu ( weakly connected ): Nếu có đường đi giữa 2 đỉnh bất kỳ của đồ thị vô hướng tương ứng với đồ thị đã cho. 
                Tức là hủy bỏ các hướng của các cạnh trong đồ thị
            -> Liên thông một phần (unilaterally connected): Nếu với mọi cặp đỉnh a, b bất kỳ, có ít nhất một đỉnh đến được đỉnh còn lại.
         */

        /* Vậy check G có liên thông không chỉ cần check value của mảng visited có đủ giá trị không ? Có đủ tức là có đường đi giữa tất cả các đỉnh thì liên thông*/

        private LinkedList<int>[] adjList;
        private int nVertex;

        public LinkedList<int>[] AdjList { get => adjList; set => adjList = value; }
        public int NVertex { get => nVertex; set => nVertex = value; }

        public GraphChecker()
        {

        }

        public void ReadGraph(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                NVertex = int.Parse(sr.ReadLine());
                AdjList = new LinkedList<int>[NVertex];
                for(int i = 0;i< NVertex; i++)
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
                        if (tokens[j] == " ")
                        {
                            continue;
                        }
                        AdjList[i].AddLast(int.Parse(tokens[j]));
                    }
                }
            }
        }

        public bool IsConnected()
        {
            bool[] visited = new bool[NVertex];
            int i = 1;
            for (int j = 0; j < NVertex; j++)
                visited[j] = false;
            Queue<int> q = new Queue<int>();
            q.Enqueue(i);
            visited[i] = true;

            while (q.Count != 0)
            {
                int u = q.Dequeue();

                foreach(int v in AdjList[u - 1])
                {
                    if (visited[v]) continue;
                    visited[v] = true;
                }
            }
            for(int x = 1;x<=visited.Length - 1;x++)
            {
                if (visited[x] == false)
                    return false;
            }
            return true;
        }

        public void WriteResult(string path,bool flag)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                if (flag)
                    sw.Write("YES");
                else
                    sw.Write("NO");
            }
        }

        public void DFS_Util(int v,bool[] visited)
        {
            visited[v] = true;
            foreach(int x in AdjList[v-1])
            {
                if (visited[x] == false)
                    DFS_Util(x, visited);
            }
        }

        // DFS version
        public int CountConnectedComponents()
        {
            bool[] visited = new bool[NVertex+1];
            int count = 0;
            for (int i = 1; i < NVertex + 1; i++)
                visited[i] = false;
            for(int i = 1; i < NVertex + 1; i++)
            {
                if (visited[i] == false)
                {
                    DFS_Util(i,visited);
                    count++;
                }
            }
            return count;
        }

        public void WriteNumberOfConnectedComponent(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(CountConnectedComponents());
            }
        }
    }
}
