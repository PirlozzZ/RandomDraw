using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
