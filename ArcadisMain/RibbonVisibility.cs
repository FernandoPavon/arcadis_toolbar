using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArcadisMain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RibbonVisibility
    {
        [JsonProperty("tabs")]
        public IList<TabVis> Tabs { get; } = new List<TabVis>();

    }

    public class TabVis
    {
        [JsonProperty("tabname")]
        public string TabName { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        public TabVis(string tab, bool vis)
        {
            TabName = tab;
            Visible = vis;
        }

        [JsonProperty("panels")]
        public IList<PanelVis> Panels { get; } = new List<PanelVis>();
    }

    public class PanelVis
    {
        [JsonProperty("panelname")]
        public string PanelName { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        public PanelVis(string name, bool vis)
        {
            PanelName = name;
            Visible = vis;
        }

        [JsonProperty("commands")]
        public IList<CommandVis> Commands { get; } = new List<CommandVis>();
    }

    public class CommandVis
    {
        [JsonProperty("commandname")]
        public string CommandName { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        public CommandVis(string name, bool vis)
        {
            CommandName = name;
            Visible = vis;
        }
    }
}
