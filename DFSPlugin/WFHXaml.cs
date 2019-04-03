namespace DFSPlugin
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("7fc1476f-6998-49a1-98e9-3a0b80c29d14")]
    public class WFHXaml : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WFHXaml"/> class.
        /// </summary>
        public WFHXaml() : base(null)
        {
            this.Caption = "WFHXaml";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new WFHXamlControl();
        }
    }
}
