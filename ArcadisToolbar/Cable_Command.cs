using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using MetricsTracker;

namespace ArcadisToolbar_I
{
    [Transaction(TransactionMode.Manual)]
    class Cable_Command : IExternalCommand
    {
        DateTime m_startTime;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_startTime = DateTime.Now;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Metrics.StartCommand(doc, "Fixtures_Command", m_startTime);

            try
            {
                TaskDialog.Show("Select Element", "Select Element");

                Reference selPick = uidoc.Selection.PickObject(ObjectType.Element, "Select Element");

                Element ele = doc.GetElement(selPick);

                Parameter par = ele.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);

                string strHello = Utils.DeserializeBinaryString(par.AsString());

                TaskDialog.Show("Deserialize Binary String", strHello);



            }
            catch (Exception ex)
            {
                Metrics.AppendLog("Exception: " + ex.Message);
                Metrics.AppendLog("Result: Failed");
                return Result.Failed;
            }

            Metrics.EndCommand(m_startTime);

            return Result.Succeeded;

        }
    }
}
