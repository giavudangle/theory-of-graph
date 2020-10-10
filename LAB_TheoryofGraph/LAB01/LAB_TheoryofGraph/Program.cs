using System;

namespace LAB_TheoryofGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = @"D:\HUFLIT Semester III\Graph\theory-graph\LAB_TheoryofGraph\LAB01\LAB_TheoryofGraph\DATA.txt";
            string pathOutput = @"D:\HUFLIT Semester III\Graph\theory-graph\LAB_TheoryofGraph\LAB01\LAB_TheoryofGraph\OUTPUT_DATA.txt";
            //MatrixAdjacencyGraph matrixGraph = new MatrixAdjacencyGraph();
            //matrixGraph.ReadDataGraph(pathInput);
            ////matrixGraph.PrintGraph(pathOutput);
            //matrixGraph.FindInAndOutDegree(pathOutput);


            //ListAdjacencyGraph listAdjacencyGraph = new ListAdjacencyGraph();
            //listAdjacencyGraph.ReadDataGraph(pathInput);
            //listAdjacencyGraph.FindAllDegree(pathOutput);

            ListEdgeGraph listEdgeGraph = new ListEdgeGraph();
            listEdgeGraph.ReadDataGraph2(pathInput);
            //listEdgeGraph.FindAllDegree(pathOutput);
        }
    }
}
