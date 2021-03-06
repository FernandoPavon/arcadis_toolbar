﻿using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ArcadisMain;

namespace ArcadisToolbar_II
{
    [Transaction(TransactionMode.Manual)]
    class Parallel_Command : IExternalCommand
    {
        DateTime m_startTime;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            m_startTime = DateTime.Now;

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Metrics.StartCommand(doc, "Parallel_Command", m_startTime);

            try
            {
                Metrics.AppendLog("\r\nCapture command metrics ------>\r\n");
                TaskDialog.Show("Parallel_Command", "Automatically place parallel cables with cleat supports.");
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
