using System;
using Rhino;
using Rhino.Commands;
using Rhino.UI;

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
            RhinoApp.WriteLine("*** Show Panel command called...");
            RhinoApp.WriteLine("File path from command is " + doc.Path);

            Utilities.ShowDockedPanel();

            return Result.Success;
        }
    }
}