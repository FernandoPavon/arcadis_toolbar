using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadisToolbar_I
{
    [Serializable]
    public class BinaryVersions
    {
        public String ArcadisToolbar_I_Version { get; set; }
        public String ArcadisToolbar_II_Version { get; set; }
        public String ExportPanel_Version { get; set; }
        public String ImportPanel_Version { get; set; }
        public String MetricsTracker_Version { get; set; }
        //public string DynamicTools_Version { get; set; }
    }

    public sealed class JtLinkBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override System.Type BindToType(
          string assemblyName,
          string typeName)
        {
            return Type.GetType(string.Format("{0}, {1}",
              typeName, assemblyName));
        }
    }
}
