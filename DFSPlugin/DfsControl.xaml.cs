using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web.UI.Design;
using System.Windows.Forms.Integration;
using DFSPlugin.Annotations;
using Microsoft.Msagl.GraphViewerGdi;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace DFSPlugin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DfsControl.
    /// </summary>
    public partial class DfsControl : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DfsControl"/> class.
        /// </summary>
        public DfsControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        //public static MyWFH myWfh;

        static DfsControl()
        {
            viewer = new GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
        }

        public static GViewer viewer { get; set; } = new GViewer();

        public event PropertyChangedEventHandler PropertyChanged;

        /*static DfsControl()
        {
            viewer = new GViewer();
        }*/

        private static WindowsFormsHost windows = new WindowsFormsHost() {Child = viewer};

        public WindowsFormsHost MyWindowsFormsHost
        {
            get
            {
                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " Getting value");
                /*System.Windows.Forms.Form form = new System.Windows.Forms.Form();
                //form.SuspendLayout();
                form.Controls.Add(new GViewer { Graph = (windows.Child as GViewer).Graph, Dock = System.Windows.Forms.DockStyle.Fill });
                //form.ResumeLayout();
                form.Show();*/
                return windows;
            }

            set
            { 
                windows = value;
                Debug.WriteLine("Changing value");
          
                NotifyPropertyChanged("MyWindowsFormsHost");
                
                /*System.Windows.Forms.Form form = new System.Windows.Forms.Form();
                form.Controls.Add((windows.Child as GViewer));
                form.Show();*/
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                Debug.WriteLine("Notify property changed");
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
           
        }
    }

    public class DebugDataBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.Controls.Add(((WindowsFormsHost) value).Child as GViewer);
            form.Show();
            //Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //Debugger.Break();
            return value;
        }
    }
}
/*
public class MyWFH : INotifyPropertyChanged
{
    private static GViewer viewer = new GViewer();
    private WindowsFormsHost wfHost = new WindowsFormsHost() {Child = viewer };

    public event PropertyChangedEventHandler PropertyChanged;

    public WindowsFormsHost MyWindowsFormsHost
    {
        get { return this.wfHost; }
        set
        {
            wfHost = value;
            this.NotifyPropertyChanged("MyWindowsFormsHost");
        }
    }

    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
}*/