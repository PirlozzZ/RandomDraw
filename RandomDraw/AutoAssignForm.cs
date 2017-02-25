﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomDraw
{
    public partial class AutoAssignForm : Form
    {
        DataSet ds;
        List<string> allNames;
        int total;
        public AutoAssignForm()
        {
            InitializeComponent();
        }

      

        private void buttonImport_Click(object sender, EventArgs e)
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
                        //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                        FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                        //dataGridView1.DataSource = ProcessExcel.EcxelToDataGridView(fileInfo.FullName).Tables[0].DefaultView;
                        ds = ProcessExcel.EcxelToDataGridView(fileInfo.FullName);
                    }
                }
                total = ds.Tables[0].Rows.Count;
                double count = Int32.Parse(MyConfiguration.getSetting("groupNumber")) ;
                this.textBoxStatus.Text = string.Format("已成功导入名单，共{0}人", total);
                this.comboBoxGroupNo.Items.Clear();
                for (int i=1;i<= Math.Ceiling(total / (count <= 0 ? 1 : count)); i++)
                {
                    this.comboBoxGroupNo.Items.Add(string.Format("第{0}分组",i));
                }
                
            }
            catch (Exception err)
            {
                this.textBoxStatus.Text = string.Format("导入失败！");
            }
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            if ("未导入".Equals(this.textBoxStatus.Text)){
                MessageBox.Show("请先导入名单！");
            }
            else
            {

            }
        }

        private List<string> toList(DataTable dt)
        {
            List<string> list = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(dr[0].ToString());
            }
            return list;
        }
    }
}
