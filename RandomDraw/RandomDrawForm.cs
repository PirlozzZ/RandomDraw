using System;
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
    public partial class RandomDrawForm : Form
    {
        DataSet ds;
        List<Person> allNames;
        int total;
        int num;
        bool sign;

        public RandomDrawForm()
        {
            InitializeComponent();
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
                this.labelState.Text = string.Format("选择路径失败！");
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBoxFile.Text))
                {
                    MessageBox.Show("请先选择文件所在路径！");
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                    FileInfo fileInfo = new FileInfo(this.textBoxFile.Text);
                    //dataGridView1.DataSource = ProcessExcel.EcxelToDataGridView(fileInfo.FullName).Tables[0].DefaultView;
                    ds = ProcessExcel.EcxelToDataGridView(fileInfo.FullName);
                }
                
                allNames = toList(ds.Tables[0]);
                total = allNames.Count;
                this.labelState.Text = string.Format("已成功导入名单，共{0}人", total);
                this.label2.Text = string.Format("剩余人数：{0}人", total);
                this.timer1.Enabled = true;
            }
            catch (Exception err)
            {
                this.labelState.Text = string.Format("导入失败！");
            }
        }

        private List<Person> toList(DataTable dt)
        {
            List<Person> list = new List<Person>();
            foreach (DataRow dr in dt.Rows)
            {
                int code = 0;
                if (Int32.TryParse(dr[0].ToString(),out code))
                {
                    Person person = new Person()
                    {
                        code = code,
                        name = dr[1].ToString()
                    };
                    list.Add(person);
                }
            }
            return list;
        }

        class Person
        {
            internal int code;
            internal string name;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            sign = true;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            sign = false;
            this.timer1.Enabled = false;
            allNames.RemoveAt(num);
            total = allNames.Count; 
            this.label2.Text = string.Format("剩余人数：{0}人", total);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //   int str = int.TryParse(textBox1.Text.Trim();
            Random ran = new Random();
            num = ran.Next(0, total); //随机数的上下限
            Person temp = allNames[num];
            textBox2.Text = temp.code + "：" + temp.name;
            //设置刷新时间
            timer1.Interval = 2;
        }
    }
}
