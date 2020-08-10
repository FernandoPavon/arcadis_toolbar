using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommonTools;

namespace Import_Panel
{
    [Transaction(TransactionMode.Manual)]
    public class ImportExcel_Command : IExternalCommand
    {
        DateTime m_startTime;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_startTime = DateTime.Now;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Metrics.StartCommand(doc, "ImportExcel_Command", m_startTime);

            try
            {
                Metrics.AppendLog("\r\nCapture command metrics----->\r\n");
                TaskDialog.Show("ImportExcel_Command", "Import from Excel");
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
