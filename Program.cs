using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int argc;
            char argv;
            //ifstream inputs;
            string[] lines = System.IO.File.ReadAllLines(@"data\input1.txt");
            Graph gptr = null;
            int num;
            string v1, v2;

            int w;
            Queue<string> visitedq;
            Queue<string> adjq;


            foreach (string line in lines)
            {
                List<string> inputs = new List<string>(line.Split(" "));

                for (int i = 0; i < inputs.Count; i++)
                {
                    if (inputs[i] == "")
                    {
                        inputs.RemoveAt(i);
                        i--;
                    }
                }
                switch (inputs[0])
                {
                    case "#": //comment
                        try
                        {
                            Console.WriteLine(line);
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception");
                        }
                        break;

                    case "c": //construct empty graph object

                        try
                        {
                            Console.WriteLine("Constructor()");
                            gptr = new Graph();

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception");
                        }
                        break;

                    case "d": //Add directed edge to graph object
                        try
                        {
                            inputs + v1 + v2 + w;
                            Console.WriteLine("AddEdge(" + v1 + ", " + v2 + ", " + w + ")");
                            gptr->AddEdge(v1, v2, w);

                        }

                        catch (std::bad_alloc)
                        {
                            Console.WriteLine("Error - full: unable to add directed");

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in AddEdge");
                        }
                        break;

                    case "u": // Add undirected edge to graph object

                        try
                        {
                            inputs + v1 + v2 + w;
                            Console.WriteLine("AddEdge(" + v1 + ", " + v2 + ", " + w + ")");
                            gptr->AddEdge(v1, v2, w);
                            Console.WriteLine("AddEdge(" + v2 + ", " + v1 + ", " + w + ")");
                            gptr->AddEdge(v2, v1, w);

                        }
                        catch (std::bad_alloc)
                        {
                            Console.WriteLine("Error - full: unable to add directed");

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in AddEdge");
                        }
                        break;

                    case "?":
                        try
                        {
                            inputs >> v1;
                            if (gptr->VertexExist(v1) != null)
                            {
                                Console.WriteLine("VertexExist (" << v1 << ") -- true");
                            }
                            else
                            {
                                Console.WriteLine("VertexExist (" << v1 << ") -- false");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in VertexExist");
                        }
                        break;
                    case "!": //edge exist
                        try
                        {
                            inputs >> v1 >> v2;
                            if (gPtr->EdgeExist(v1, v2) != null)
                            {
                                Console.WriteLine("EdgeExist (" << v1 << ") -- true");
                            }
                            else
                            {
                                Console.WriteLine("EdgeExist (" << v1 << ") -- false");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in EdgeExist");
                        }
                        break;

                    case "w":   // WeightIs()
                        try
                        {
                            inputs >> v1 >> v2;
                            Console.WriteLine("WeightIs(" << v1 << ", " << v2 << ") -- ");
                            w = gPtr->WeightIs(v1, v2);
                            Console.WriteLine(w);
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch (GraphEdgeNotFound)
                        {
                            Console.WriteLine("Error: edge not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in WeightIs");
                        }
                        break;

                    case "m":   // MarkVertex()
                        try
                        {
                            inputs >> v1;
                            Console.WriteLine("MarkVertex(" << v1 << ") ");
                            gPtr->MarkVertex(v1);
                            Console.WriteLine();
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in MarkVertex");
                        }
                        break;

                    case "e":   // ClearMarks()
                        try
                        {
                            Console.WriteLine("ClearMarks() ");
                            gPtr->ClearMarks();
                            Console.WriteLine();
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in ClearMarks");
                        }
                        break;

                    case "i":   // IsMarked()
                        try
                        {
                            inputs >> v1;
                            Console.WriteLine("IsMarked(" << v1 << ") -- ");
                            if (gPtr->IsMarked(v1))
                                Console.WriteLine("true");
                            else
                                Console.WriteLine("false");
                            Console.WriteLine();
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in IsMarked");
                        }
                        break;

                    case "s":   // Perform Depth-First Search
                        try
                        {
                            inputs >> v1 >> v2;     // Input v1-start and v2-end vertices

                            Console.WriteLine("DFS( " << v1 << ", " << v2 << " ) -- ");
                            gPtr->DepthFirstSearch(v1, v2, visitedq);

                            if (visitedq.empty())
                                Console.WriteLine("No path found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (!visitedq.empty())
                                {
                                    Console.WriteLine(visitedq.front() << " ");
                                    visitedq.pop();
                                }
                                Console.WriteLine("}");
                            }
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in DFS");
                        }
                        while (!visitedq.empty())
                            visitedq.pop();
                        break;

                    case "g":   // GetToVertices
                        try
                        {
                            inputs >> v1;

                            Console.WriteLine("GetToVertices( " << v1 << " ) -- ");
                            gPtr->GetToVertices(v1, adjq);

                            if (adjq.empty())
                                Console.WriteLine("No adjacent vertices found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (!adjq.empty())
                                {
                                    Console.WriteLine(adjq.front() << " ");
                                    adjq.pop();
                                }
                                Console.WriteLine("}");
                            }
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in GetToVertices");
                        }
                        while (adjq.Count  != 0)
                            adjq.Dequeue();
                        break;

                    case "b":   // Perform Breadth-First Search
                        try
                        {
                            inputs >> v1 >> v2;     // Input v1-start and v2-end vertices

                            Console.WriteLine("BFS( " << v1 << ", " << v2 << " ) -- ");
                            gPtr->BreadthFirstSearch(v1, v2, visitedq);

                            if (visitedq.empty())
                                Console.WriteLine("No path found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (!visitedq.empty())
                                {
                                    Console.WriteLine(visitedq.front() << " ");
                                    visitedq.pop();
                                }
                                Console.WriteLine("}");
                            }
                        }
                        catch (GraphVertexNotFound)
                        {
                            Console.WriteLine("Error: vertex not found");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in BFS");
                        }
                        while (!visitedq.empty())
                            visitedq.pop();
                        break;

                    case 'p':   // Print Graph
                        gPtr->Print();
                        break;

                    case '~':   // Destructor
                        try
                        {
                            delete gPtr;
                            gPtr = NULL;
                            Console.WriteLine("Destructor()");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception");
                        }
                        break;

                    default:
                        Console.WriteLine("Error - unrecognized operation '" + op + "'");
                        Console.WriteLine("Terminating now...");
                        return 1;
                        break;
                }
                inputs >> op;   // Attempt to input next command

            }

        }
    }
}

