﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ArcadisMain;

namespace Electrical_Panel
{
    [Transaction(TransactionMode.Manual)]
    class Lights_Command : IExternalCommand
    {
        DateTime m_startTime;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_startTime = DateTime.Now;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Metrics.StartCommand(doc, "Lights_Command", m_startTime);
            
            try
            {
                Metrics.AppendLog("\r\nCapture command metrics ---->\r\n");
                TaskDialog.Show("Command", "Lights_Command executed");

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
