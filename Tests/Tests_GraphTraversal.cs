using Core.DataStructures;
using NUnit.Framework;

namespace Tests
{
    public class Tests_GraphTraversal
    {
        public Graph graph;

        [SetUp]
        public void Setup()
        {
            graph = new Graph(8);
        }

        [Test]
        public void BFS()
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 3);
            graph.AddEdge(0, 6);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 7);
            graph.AddEdge(3, 0);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 1);
            graph.AddEdge(4, 6);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 3);
            graph.AddEdge(6, 0);
            graph.AddEdge(6, 4);
            graph.AddEdge(7, 2);
            
            graph.BFS(0);
        }
        
        [Test]
        public void DFS()
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 1);
            graph.AddEdge(4, 6);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 0);
            graph.AddEdge(0, 6);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 3);
            graph.AddEdge(3, 5);
            graph.AddEdge(3, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(5, 2);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 7);
            graph.AddEdge(7, 2);

            
            graph.DFS(0);
        }

        [Test]
        public void DFS_Directed()
        {
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 6);
            graph.AddEdge(6, 0);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(5, 2);
            graph.AddEdge(2, 7);
            
            graph.DFS(0);
        }
    }
}
