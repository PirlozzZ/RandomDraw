using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace RandomDraw
{
    class ProcessExcel
    {
        public static DataSet EcxelToDataGridView(string filePath)
        {
            //根据路径打开一个Excel文件并将数据填充到DataSet中
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=YES;IMEX=1'";//HDR=YES 有两个值:YES/NO,表示第一行是否字段名,默认是YES,第一行是字段名
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select  * from   [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

        #region
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// /// <param name="dataSet"></param>
        /// <param name="dataTable">数据集</param>
        /// <param name="isShowExcle">导出后是否打开文件</param>
        /// <returns></returns>
        //public static bool DataTableToExcel(string filePath, System.Data.DataTable dataTable, bool isShowExcle)
        //{
        //    //System.Data.DataTable dataTable = dataSet.Tables[0];
        //    int rowNumber = dataTable.Rows.Count;
        //    int columnNumber = dataTable.Columns.Count;
        //    int colIndex = 0;

        //    if (rowNumber == 0)
        //    {
        //        return false;
        //    }

        
        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
        //    excel.Visible = isShowExcle;
        //    Microsoft.Office.Interop.Excel.Range range;


        //    foreach (DataColumn col in dataTable.Columns)
        //    {
        //        colIndex++;
        //        excel.Cells[1, colIndex] = col.ColumnName;
        //    }

        //    object[,] objData = new object[rowNumber, columnNumber];

        //    for (int r = 0; r < rowNumber; r++)
        //    {
        //        for (int c = 0; c < columnNumber; c++)
        //        {
        //            objData[r, c] = dataTable.Rows[r][c];
        //        }
        //    }

        //    range = worksheet.get_Range(excel.Cells[2, 1], excel.Cells[rowNumber + 1, columnNumber]);

        //    range.Value2 = objData;

        //    range.NumberFormatLocal = "@";

        //    worksheet.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //    //excel.Quit();
        //    return true;
        //}
        #endregion

        public static bool OutToExcelFromDataGridView(string title, DataGridView dgv, bool isShowExcel)
        {
            int titleColumnSpan = 0;//标题的跨列数
            string fileName = "";//保存的excel文件名
            int columnIndex = 1;//列索引


            if (dgv.Rows.Count == 0)
                return false;
            /*保存对话框*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = title + DateTime.Now.ToString("yyyyMMddhhmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                /*建立Excel对象*/
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的计算机未安装Excel!");
                    return false;
                }
                try
                {
                    excel.Application.Workbooks.Add(true);
                    excel.Visible = isShowExcel;
                    excel.DisplayAlerts = false;
                    excel.AlertBeforeOverwriting = false;
                    /*分析标题的跨列数*/
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible == true)
                            titleColumnSpan++;
                    }
                    /*合并标题单元格*/
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                    //worksheet.get_Range("A1", "C10").Merge();            
                    worksheet.get_Range(worksheet.Cells[1, 1] as Range, worksheet.Cells[1, titleColumnSpan] as Range).Merge();
                    /*生成标题*/
                    excel.Cells[1, 1] = title;
                    (excel.Cells[1, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                                                                                               //生成字段名称
                    columnIndex = 1;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (dgv.Columns[i].Visible == true)
                        {
                            excel.Cells[2, columnIndex] = dgv.Columns[i].HeaderText;
                            (excel.Cells[2, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                            columnIndex++;
                        }
                    }
   
                    //填充数据              
                    for (int i = 0; i < dgv.Rows.Count-1; i++)
                    {
                        columnIndex = 1;
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            if (dgv.Columns[j].Visible == true)
                            {
                                if (dgv[j, i].ValueType == typeof(string))
                                {
                                    excel.Cells[i + 3, columnIndex] = "'" + dgv[j, i].Value.ToString();
                                }
                                else
                                {
                                    excel.Cells[i + 3, columnIndex] = dgv[j, i].Value.ToString();
                                }
                                (excel.Cells[i + 3, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignLeft;//字段居中
                                columnIndex++;
                            }
                        }
                    }
                    worksheet.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch(Exception e) {
                    string TEMP = e.Message;
                }
                finally
                {
                    excel.Quit();
                    excel = null;
                    GC.Collect();
                }
                //KillProcess("Excel");
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void KillProcess(string processName)//杀死与Excel相关的进程
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();//得到所有打开的进程
            try
            {
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }
    }
}
