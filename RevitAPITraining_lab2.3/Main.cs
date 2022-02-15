using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_lab2._3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilyInstance> fInstColumns = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Columns)
                .Cast<FamilyInstance>()
                .ToList();

            TaskDialog.Show("Количество колонн", fInstColumns.Count.ToString());
            return Result.Succeeded;
        }
    }
}
