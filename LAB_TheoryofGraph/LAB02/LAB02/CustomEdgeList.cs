using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LAB02
{
    class CustomEdgeList
    {
        private int nVertex;
        private int nEdge;
        private List<Tuple<int, int, int>> edgeList;

        public List<Tuple<int, int, int>> EdgeList { get => edgeList; set => edgeList = value; }
        public int NVertex { get => nVertex; set => nVertex = value; }
        public int NEdge { get => nEdge; set => nEdge = value; }

        public void ReadData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] tokens = sr.ReadLine().Split(' ');
                NVertex = int.Parse(tokens[0]);
                NEdge= int.Parse(tokens[1]);
                EdgeList = new List<Tuple<int, int, int>>(NEdge);
                for(int i = 0; i < NEdge; i++)
                {
                    tokens = sr.ReadLine().Split(' ');
                    Tuple<int, int, int> temp = 
                        new Tuple<int, int, int>(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
                    EdgeList.Add(temp);
                  
                }
            }
        }

        public void PrintGraph(string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(ProcessAverageEdge());
                sw.WriteLine(GetListMaxCost().Count);
                foreach (Tuple<int, int, int> it in GetListMaxCost())
                    sw.WriteLine(it.Item1 + " " + it.Item2 + " " + it.Item3);
            }
           
        }

        public double ProcessAverageEdge()
        {
            int sum = 0;
            foreach(Tuple<int,int,int> it in EdgeList)
            {
                sum += it.Item3;
            }
            return sum * 1.0 / NEdge;
        }

        public List<Tuple<int,int,int>> GetListMaxCost()
        {
            List<Tuple<int, int, int>> res = new List<Tuple<int, int, int>>();
            Tuple<int, int, int> maxTuple = EdgeList[0];

            foreach(Tuple<int,int,int>it in EdgeList)           
                if (it.Item3 > maxTuple.Item3) 
                    maxTuple = it;                
            foreach (Tuple<int, int, int> it in EdgeList)           
                if (it.Item3 == maxTuple.Item3)                
                    res.Add(it);         
            return res;
        }
        
    }
}
