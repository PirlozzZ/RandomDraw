using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RandomDraw
{
    public partial class AutoAssignForm : Form
    {
        DataSet ds;
        List<string> allNames;
        int total;
        double count = Int32.Parse(MyConfiguration.getSetting("groupNumber"));
        public AutoAssignForm()
        {
            InitializeComponent();
        }

      

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBoxFile.Text))
                {
                    MessageBox.Show("请先选择文件所在路径！");
                }
                else { 
                        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                        FileInfo fileInfo = new FileInfo(this.textBoxFile.Text );
                        //dataGridView1.DataSource = ProcessExcel.EcxelToDataGridView(fileInfo.FullName).Tables[0].DefaultView;
                        ds = ProcessExcel.EcxelToDataGridView(fileInfo.FullName);
                }
                total = ds.Tables[0].Rows.Count;
                
                this.textBoxStatus.Text = string.Format("已成功导入名单，共{0}人", total);
                this.comboBoxGroupNo.Items.Clear();
                for (int i=1;i<= Math.Ceiling(total / (count <= 0 ? 1 : count)); i++)
                {
                    this.comboBoxGroupNo.Items.Add(string.Format("第{0}分组",i)); 
                }
                this.comboBoxGroupNo.SelectedIndex = 0;
                allNames = toList(ds.Tables[0]);
            }
            catch (Exception err)
            {
                this.textBoxStatus.Text = string.Format("导入失败！");
            }
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            bool sign = true;
            DataTable tempDT=new DataTable();
            if ("未导入".Equals(this.textBoxStatus.Text)|| "导入失败！".Equals(this.textBoxStatus.Text))
            {
                MessageBox.Show("请先导入名单！");
            }
            else
            {
                string cbIndex = this.comboBoxGroupNo.SelectedItem.ToString();
                foreach(DataTable dt in ds.Tables)
                {
                    if (cbIndex.Equals(dt.TableName))
                    {
                        tempDT = dt;
                        sign = false;
                        MessageBox.Show("该组已分配！");
                    }  
                }
                if (allNames.Count == 0)
                {
                    sign = false;
                    MessageBox.Show("已经全部分配完成！");
                }
                if (sign)
                {
                    tempDT = new DataTable(cbIndex);
                    DataColumn dc1 = new DataColumn("编号", Type.GetType("System.Int32"));
                    DataColumn dc2 = new DataColumn("姓名", Type.GetType("System.String"));
                    tempDT.Columns.Add(dc1);
                    tempDT.Columns.Add(dc2);
                    for (int i = 0; i < count; i++)
                    {
                        Random ran = new Random();
                        int n = ran.Next(0,allNames.Count-1);
                        string tempName = allNames[n];
                        allNames.RemoveAt(n);
                        DataRow dr = tempDT.NewRow();
                        dr["编号"] = i + 1;
                        dr["姓名"] = tempName;
                        tempDT.Rows.Add(dr);
                        if (allNames.Count == 0)
                        {
                            break;
                        }
                    }
                    ds.Tables.Add(tempDT);
                }
                this.dataGridView1.DataSource = tempDT.DefaultView;
                
            }
        }

        

        private void buttonFile_Click(object sender, EventArgs e)
        {
            try
            {
                //初始化一个OpenFileDialog类
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "(*.xls;*.xlsx)|*.xls;*.xlsx";
                //判断用户是否正确的选择了文件
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获取用户选择文件的后缀名
                    string extension = Path.GetExtension(fileDialog.FileName);
                    //声明允许的后缀名
                    string[] str = new string[] { ".xls", ".xlsx" };
                    if (!((IList)str).Contains(extension))
                    {
                        MessageBox.Show("仅能导入xls,xlsx格式的文件！");
                    }
                    else
                    {
                        this.textBoxFile.Text = fileDialog.FileName;
                    }
                }
            }
            catch (Exception err)
            {
                this.textBoxStatus.Text = string.Format("选择路径失败！");
            }
        }

        private void comboBoxGroupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cbIndex = this.comboBoxGroupNo.SelectedItem.ToString();
            foreach (DataTable dt in ds.Tables)
            {
                if (cbIndex.Equals(dt.TableName))
                {
                    this.dataGridView1.DataSource = dt.DefaultView;
                    break;
                }
                else
                {
                    this.dataGridView1.DataSource = null;
                }
                
            }
        }


        private List<string> toList(DataTable dt)
        {
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr[0].ToString());
            }
            return list;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            ProcessExcel.OutToExcelFromDataGridView(MyConfiguration.getSetting("title"), dataGridView1, false);
        }
    }
}
