using System.Diagnostics;
using System.Windows.Forms.Integration;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace DFSPlugin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StaticGraphControl.
    /// </summary>
    public partial class StaticGraphControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaticGraphControl"/> class.
        /// </summary>
        public StaticGraphControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private static GViewer viewer;

        static StaticGraphControl()
        {
            viewer = new GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.Directed = false;
            //graph.AddEdge(, )
            //edge.Attr.ArrowHeadAtTarget=ArrowStyle.None
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            viewer.Graph = graph;
            Debug.WriteLine("Initialized graph");
            Debug.WriteLine(graph.GeometryGraph);
        }

        public WindowsFormsHost Graph
        {
            get
            {
                Debug.WriteLine(viewer.Graph);
                return new WindowsFormsHost() { Child = viewer };
            }
        }
    }
}