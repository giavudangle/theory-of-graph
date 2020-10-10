using System;

namespace LAB02
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\INPUT.txt";
            string outPath = @"D:\HUFLIT Semester III\Graph\theory-of-graph\LAB_TheoryofGraph\LAB02\LAB02\OUTPUT.txt";


            /* Bài 1. Chuyển danh sách cạnh sang danh sách kề */
            //EdgeListGraph edgeListGraph = new EdgeListGraph();
            //edgeListGraph.ReadData_EdgeList(inpPath);
            //edgeListGraph.Convert_From_EdgeList_To_AdjacencyList(outPath);

            /* Bài 2. Chuyển danh sách kề sang danh sách cạnh*/
            //EdgeListGraph edgeListGraph = new EdgeListGraph();
            //edgeListGraph.ReadData_AdjList(inpPath);
            //edgeListGraph.Convert_From_AdjacencyList_To_EdgeList(edgeListGraph.AdjList, outPath);

            /* Bài 3.  Bồn chứa */
            //MatrixAdjacency matrixAdjacency = new MatrixAdjacency();
            //matrixAdjacency.ReadDataGraph(inpPath);
            //matrixAdjacency.FindListVertex_NotHaveOutDegree(matrixAdjacency.AdjMatrix, outPath);

            /* Bài 4. Đồ thị chuyển vị */
            //EdgeListGraph edgeListGraph = new EdgeListGraph();         
            //edgeListGraph.ReadData_AdjList_Contain_BlankLine(inpPath);
            //edgeListGraph.Custom_Convert_AdjList_To_EdgeList(edgeListGraph.AdjList);
            //edgeListGraph.TransposeGraph();
            //edgeListGraph.printGraph(outPath);

            /* Bài 5. Độ dài trung bình của cạnh*/
            //CustomEdgeList customEdgeList = new CustomEdgeList();
            //customEdgeList.ReadData(inpPath);
            //customEdgeList.PrintGraph(outPath);

            /* BÀI TẬP LÀM THÊM*/

            /*Bài 1. Chuyển ma trận kề sang danh sách kề*/

            //GraphConverter graphConverter = new GraphConverter();
            //graphConverter.ReadDataGraph(inpPath);
            //graphConverter.ConvertFrom_AdjMatrix_To_AdjList(graphConverter.AdjMatrix);
            //graphConverter.PrintAdjListGraph(outPath);

            /*Bài 2. Chuyển ma trận kề sang danh sách cạnh*/
            GraphConverter graphConverter = new GraphConverter();
            graphConverter.ReadDataGraph(inpPath);
            graphConverter.ConvertFrom_AdjMatrix_To_EdgeList(graphConverter.AdjMatrix);
            graphConverter.PrintEdgeListGraph(outPath);


        }
    }
}
