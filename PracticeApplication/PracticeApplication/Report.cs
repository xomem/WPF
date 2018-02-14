using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace PracticeApplication
{
    public static class Report
    {
        public static void ToExel(System.Data.DataTable dataTable, string FilePath = null)
        {

            try
            {
                if (dataTable == null || dataTable.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < dataTable.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < dataTable.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(FilePath))
                {
                    try
                    {
                        workSheet.SaveAs(FilePath);
                        excelApp.Quit();
                        //MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
