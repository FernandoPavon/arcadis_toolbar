using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ArcadisMain
{
    [JsonObject(MemberSerialization.OptIn)]
    class DocPreferences
    {
        [JsonProperty("familyPath")]
        public string FamilyPath { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

    }
}
