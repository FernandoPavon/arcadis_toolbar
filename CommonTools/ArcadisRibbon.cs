using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


using Autodesk.Revit.UI;

namespace CommonTools
{
    public class ArcadisRibbon
    {
        public IList<ToolbarTab> Tabs { get; } = new List<ToolbarTab>();
    }

    public class ToolbarTab
    {
        public string TabName { get; set; }
        public Autodesk.Windows.RibbonTab RibbonTab { set; get; }

        public ToolbarTab(string name, Autodesk.Windows.RibbonTab tab)
        {
            TabName = name;
            RibbonTab = tab;
        }

        public IList<ToolbarPanel> Panels { get; } = new List<ToolbarPanel>();
    }

    public class ToolbarPanel
    {
        public string PanelName { get; set; }
        public RibbonPanel Panel { get; set; }

        public ToolbarPanel(string name, RibbonPanel panel)
        {
            PanelName = name;
            Panel = panel;
        }

        public IList<ToolbarCommand> Commands { get; } = new List<ToolbarCommand>();
    }

    public class ToolbarCommand
    {
        public string CommandName { get; set; }
        public PushButton Command { get; set; }

        public ToolbarCommand(string name, PushButton command)
        {
            CommandName = name;
            Command = command;
        }
    }
}
