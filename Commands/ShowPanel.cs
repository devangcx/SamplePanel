using System;
using Rhino;
using Rhino.Commands;

namespace SamplePanel.Commands
{
    public class ShowPanel : Command
    {
        private uint _docSerialNumber;

        public ShowPanel()
        {
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static ShowPanel Instance { get; private set; }

        public override string EnglishName => "ShowSamplePanel";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("\nShow Panel command called...");
            
            return Result.Success;
        }

        private void OnEndOpenDocument(object sender, DocumentOpenEventArgs e)
        {
            // We don't want this to re-run so immediately remove the event handler
            RhinoDoc.EndOpenDocument -= OnEndOpenDocument;

            _docSerialNumber = e.DocumentSerialNumber;
            RhinoApp.Idle += OnIdle;
        }

        private void OnIdle(object sender, EventArgs e)
        {
            // We don't want this to re-run so immediately remove the event handler
            RhinoApp.Idle -= OnIdle;

            RhinoDoc doc = RhinoDoc.FromRuntimeSerialNumber(_docSerialNumber);
            if (doc == null) return;
            RhinoApp.WriteLine("File path is " + doc.Path);
        }
    }
}