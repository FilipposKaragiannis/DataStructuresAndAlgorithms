using System;
using System.Collections;
using System.Collections.Generic;
using Queue = System.Collections.Queue;

namespace Core.DataStructures
{
    public class Graph
    {
        // numnber of vertices
        private int             nodes;
        private LinkedList<int>[] adjacencyList;

        public Graph(int nodes)
        {
            this.nodes    = nodes;
            adjacencyList = new LinkedList<int>[nodes];
            for(var i = 0; i < nodes; i++)
                adjacencyList[i] = new LinkedList<int>();
        }

        public void AddEdge(int from, int to)
        {
            adjacencyList[from].AddLast(to);
        }

        public void BFS(int node)
        {
            var queue       = new Queue();
            var visitedList = new bool[nodes];
            
            queue.Enqueue(node);
            visitedList[node] = true;

            while(queue.Count > 0)
            {
                var elem = (int)queue.Dequeue();

                foreach(var n in adjacencyList[elem])
                {
                    if(visitedList[n])
                        continue;

                    visitedList[n] = true;
                    queue.Enqueue(n);
                }
                
                // do action 
                Console.WriteLine($"[{elem}]");
            }
        }

        public void DFS(int node)
        {
            var stack       = new Stack();
            var visitedList = new bool[nodes];
            
            stack.Push(node);
            visitedList[node] = true;

            while(stack.Count > 0)
            {
                var elem = (int)stack.Pop();

                foreach(var n  in adjacencyList[elem])
                {
                    if(visitedList[n])
                        continue;

                    visitedList[n] = true;
                    stack.Push(n);
                }

                Console.WriteLine($"{elem}");
            }
        }
    }
}
