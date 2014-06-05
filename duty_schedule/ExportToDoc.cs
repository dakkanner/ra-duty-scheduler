using System;
using Excel = Microsoft.Office.Interop.Excel;




namespace Duty_Schedule
{
    class ExportToDoc
    {
        public void ExportToExcel()
        {
            var excelApp = new Excel.Application();

            // Make the object visible.
            excelApp.Visible = true;

            // Create a new, empty workbook and add it to the collection returned  
            // by property Workbooks. The new workbook becomes the active workbook. 
            // Add has an optional parameter for specifying a praticular template.  
            // Because no argument is sent in this example, Add creates a new workbook. 
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. The explicit type casting is 
            // removed in a later procedure.
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Establish column headings in cells A1 and B1.
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";

            var row = 1;
            for (int i = 0; i < 20; i++ )
            {
                row++;
                workSheet.Cells[row, "A"] = i;
                workSheet.Cells[row, "B"] = i*2;
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
        }


    }
}
