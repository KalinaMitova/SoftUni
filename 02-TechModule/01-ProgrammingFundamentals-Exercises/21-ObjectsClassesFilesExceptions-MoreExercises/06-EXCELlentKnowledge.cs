using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace _06_EXCELlentKnowledge
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\rusko\Documents\visual studio 2017\Projects\22-ObjectsClassesFilesExceptions-MoreExer\06-EXCELlentKnowledge\bin\Debug\sample_table.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            File.WriteAllText("output.txt", string.Empty);

            for (int i = 1; i <= 5; i++)
            {
                var line = string.Empty;
                for (int j = 1; j <= 5; j++)
                {                    
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        line += xlRange.Cells[i, j].Value2.ToString() + "|";
                    }
                }
                line += Environment.NewLine;
                File.AppendAllText("output.txt", line);
            }
            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);            
        }
    }
}
