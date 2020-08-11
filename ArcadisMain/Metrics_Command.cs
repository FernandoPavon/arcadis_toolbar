using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace ArcadisMain
{
    [Transaction(TransactionMode.Manual)]
    class Metrics_Command : IExternalCommand
    {
        DateTime m_startTime;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_startTime = DateTime.Now;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Metrics.StartCommand(doc, "Metrics_Command", m_startTime);

            try
            {
                var form = new Metrics_Form();
                form.ShowDialog();
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
