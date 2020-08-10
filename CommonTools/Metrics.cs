using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace CommonTools
{
    /// <summary>
    /// Class used for gathering metrics
    /// Tracking usage and execution time of automation commands
    /// Logging exceptions and errors
    /// Logging non compliant model checks - missing parameters, values out of range
    /// </summary>
    public class Metrics
    {
        private static readonly IList<string> m_log = new List<string>();

        static public void AppendLog(string entry)
        {
            m_log.Add(entry);
        }

        static public IList<string> GetSessionLogs()
        {
            return m_log;
        }

        static public void StartCommand(Document doc, string command, DateTime startTime)
        {
            AppendLog("\r\nExecution: " + command);
            AppendLog("Start time: " + startTime.ToString());
            AppendLog("Project: " + doc.Title);
            AppendLog("Project path: " + doc.PathName);
            AppendLog("User: " + doc.Application.Username);
        }

        static public void EndCommand(DateTime startTime)
        {
            DateTime endTime = DateTime.Now;
            AppendLog("End time: " + endTime.ToString());
            TimeSpan duration = endTime - startTime;
            AppendLog("Duration: " + duration.ToString());
            AppendLog("Result: Succeeded");
        }
    }
}
