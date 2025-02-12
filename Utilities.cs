using Rhino.UI;
using System;
using Rhino;

namespace SamplePanel
{
    public static class Utilities
    {
        public static void ShowPanel(Guid panelId)
        {
            RhinoApp.WriteLine("Opening panel + ", panelId);
            Panels.OpenPanel(panelId);
        }
    }
}
