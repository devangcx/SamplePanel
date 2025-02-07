using Rhino;
using System;
using Rhino.PlugIns;

namespace SamplePanel
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class SamplePanelPlugin : Rhino.PlugIns.PlugIn
    {
        private uint _docSerialNumber;

        public override PlugInLoadTime LoadTime => PlugInLoadTime.AtStartup;

        public SamplePanelPlugin()
        {
            Instance = this;
        }

        ///<summary>Gets the only instance of the SamplePanelPlugin plug-in.</summary>
        public static SamplePanelPlugin Instance { get; private set; }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            RhinoApp.WriteLine("SamplePanel plug-in loaded.");

            RhinoDoc.EndOpenDocument += OnEndOpenDocument;
            RhinoDoc.BeginOpenDocument += OnBeginOpenDocument;
            RhinoDoc.NewDocument += OnNewDocument;

            return LoadReturnCode.Success;
        }

        private void OnEndOpenDocument(object sender, DocumentOpenEventArgs e)
        {
            RhinoApp.WriteLine(" --- End of opening document fired...");
            _docSerialNumber = e.DocumentSerialNumber;
            RhinoApp.Idle += OnIdle;
        }

        private void OnIdle(object sender, EventArgs e)
        {
            // We don't want this to re-run so immediately remove the event handler
            RhinoApp.Idle -= OnIdle;

            RhinoDoc doc = RhinoDoc.FromRuntimeSerialNumber(_docSerialNumber);
            if (doc == null)
            {
                RhinoApp.WriteLine("Doc is null.");
                return;
            }
            RhinoApp.WriteLine("File path is " + doc.Path);
        }

        private void RunShowPanelCommand()
        {
            RhinoApp.RunScript("!ShowSamplePanel", true);
        }

        private void OnBeginOpenDocument(object sender, DocumentOpenEventArgs e)
        {
            RhinoApp.WriteLine(" --- Begin document open fired...");
        }

        private void OnNewDocument(object sender, DocumentEventArgs e)
        {
            RhinoApp.WriteLine(" --- New document open fired...");
        }

        protected override void OnShutdown()
        {
            // Unsubscribe from events to avoid memory leaks
            RhinoDoc.BeginOpenDocument -= OnBeginOpenDocument;
            RhinoDoc.NewDocument -= OnNewDocument;
            RhinoDoc.EndOpenDocument -= OnEndOpenDocument;
            base.OnShutdown();
        }
    }

    
}