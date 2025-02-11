using Rhino.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;

namespace SamplePanel
{
    public static class Utilities
    {
        public static void ShowDockedPanel()
        {
            Guid panelId = Views.Panel.Guid;
            RhinoApp.WriteLine("Opening panel + ", panelId);

            // If the panel is not open yet, open it
            if (!Panels.IsPanelVisible(panelId))
            {
                // We want to dock the panel on the right hand side container
                // To achieve this, we are piggybacking on the Layers panel that should 
                // already be there on the right hand side container. We are making our panel
                // a sibling of the Layers panel so that it docks on the right hand side container
                // on load.
                Panels.OpenPanel(panelId);
            }
        }
    }
}
