using System;

namespace LAB02
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\INPUT.txt";
            string outPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\OUTPUT.txt";


            //EdgeListGraph edgeListGraph = new EdgeListGraph();
            //edgeListGraph.ReadData_EdgeList(inpPath);
            //edgeListGraph.Convert_From_EdgeList_To_AdjacencyList(outPath);

            EdgeListGraph edgeListGraph = new EdgeListGraph();
            edgeListGraph.ReadData_AdjList(inpPath);
            edgeListGraph.Convert_From_AdjacencyList_To_EdgeList(edgeListGraph.AdjList, outPath);
        }
    }
}
