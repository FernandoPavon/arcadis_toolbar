#region Copyright

/*
 *  Copyright 2020 Autodesk, Inc. All rights reserved.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:

 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.

 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.

 *  Autodesk Consulting Services
 *  fernando.pavon@autodesk.com
 *  Version 0.0.0.1
 *  Proof of concept
 *  1 July 2020
 *  
 */
#endregion

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
    public class Fixtures_Command : IExternalCommand
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

                string strHello = "Hello World";

                Transaction tx = new Transaction(doc);
                tx.Start("Set Param");
                    par.Set(Utils.SerializeBinaryString(strHello));
                tx.Commit();

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
