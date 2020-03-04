using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {

            //ifstream inputs;
            string[] lines = System.IO.File.ReadAllLines(@"data\input1.txt");
            Graph gptr = null;

            int w;
            Queue<string> visitedq =  new Queue<string>();
            Queue<string> adjq = new Queue<string>();


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
                            Console.WriteLine("AddEdge(" + inputs[1] + ", " + inputs[2] + ", " + inputs[3] + ")");
                            gptr.AddEdge(inputs[1], inputs[2], Convert.ToInt32(inputs[3]));
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in AddEdge");
                        }
                        break;

                    case "u": // Add undirected edge to graph object

                        try
                        {
                            Console.WriteLine("AddEdge(" + inputs[1] + ", " + inputs[2] + ", " + inputs[3] + ")");
                            gptr.AddEdge(inputs[1], inputs[2], Convert.ToInt32(inputs[3]));
                            Console.WriteLine("AddEdge(" + inputs[1] + ", " + inputs[2] + ", " + inputs[3] + ")");
                            gptr.AddEdge(inputs[2], inputs[1], Convert.ToInt32(inputs[3]));

                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception in AddEdge");
                        }
                        break;

                    case "?":
                        try
                        {
                            if (gptr.VertexExists(inputs[1]))
                            {
                                Console.WriteLine("VertexExist (" + inputs[1] + ") -- true");
                            }
                            else
                            {
                                Console.WriteLine("VertexExist (" + inputs[1] + ") -- false");
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
                            if (gptr.EdgeExists(inputs[1], inputs[2]))
                            {
                                Console.WriteLine("EdgeExist (" + inputs[1] + "," + inputs[2] + ") -- true");
                            }
                            else
                            {
                                Console.WriteLine("EdgeExist (" + inputs[1] + "," + inputs[2] + ") -- false");
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
                            Console.WriteLine("WeightIs(" + inputs[1] + ", " + inputs[2] + ") -- ");
                            w = gptr.WeightIs(inputs[1], inputs[2]);
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
                            Console.WriteLine("MarkVertex(" + inputs[1] + ") ");
                            gptr.MarkVertex(inputs[1]);
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
                            gptr.ClearMarks();
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
                            Console.WriteLine("IsMarked(" + inputs[1] + ") -- ");
                            if (gptr.IsMarked(inputs[1]))
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

                            Console.WriteLine("DFS( " + inputs[1] + ", " + inputs[2] + " ) -- ");
                            gptr.DepthFirstSearch(inputs[1], inputs[2], visitedq);

                            if (visitedq.Count == 0)
                                Console.WriteLine("No path found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (visitedq.Count != 0)
                                {
                                    Console.WriteLine(visitedq.Peek() + " ");
                                    visitedq.Dequeue();
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
                        visitedq = new Queue<string>();
                        break;

                    case "g":   // GetToVertices
                        try
                        {

                            Console.WriteLine("GetToVertices( " + inputs[1] + " ) -- ");
                            gptr.GetToVertices(inputs[1], adjq);

                            if (adjq.Count == 0)
                                Console.WriteLine("No adjacent vertices found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (adjq.Count != 0)
                                {
                                    Console.WriteLine(adjq.Peek() + " ");
                                    adjq.Dequeue();
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
                        while (adjq.Count != 0)
                            adjq.Dequeue();
                        break;

                    case "b":   // Perform Breadth-First Search
                        try
                        {

                            Console.WriteLine("BFS( " + inputs[1] + ", " + inputs[2] + " ) -- ");
                            gptr.BreadthFirstSearch(inputs[1], inputs[2], visitedq);

                            if (adjq.Count == 0)
                                Console.WriteLine("No path found");
                            else
                            {
                                Console.WriteLine(" { ");
                                while (adjq.Count != 0)
                                {
                                    Console.WriteLine(visitedq.Peek() + " ");
                                    visitedq.Dequeue();
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

                        visitedq = new Queue<string>();
                        break;

                    case "p":   // Print Graph
                        gptr.Print();
                        break;

                    case "~":   // Destructor
                        try
                        {

                            gptr = null;
                            Console.WriteLine("Destructor()");
                        }
                        catch
                        {
                            Console.WriteLine("Error: unanticipated exception");
                        }
                        break;


                }

            }

        }
    }
}

