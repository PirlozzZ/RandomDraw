using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomDraw
{
    public partial class MainForm : Form
    {
        BasicForm basicFrom;
        AutoAssignForm autoAssignForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (basicFrom == null)
            {
                basicFrom = new BasicForm();
                basicFrom.TopLevel = false;
            }
            if (autoAssignForm == null)
            {
                autoAssignForm = new AutoAssignForm();
                autoAssignForm.TopLevel = false;
            }
            autoAssignForm.Show();
            this.panelMain.Controls.Clear();
            autoAssignForm.Parent = this.panelMain;

        }

     

        private void 基础设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();
            basicFrom.Show();
            this.panelMain.Controls.Clear();
            basicFrom.Parent = this.panelMain;
        }

        private void 自动分配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoAssignForm.Show();
            this.panelMain.Controls.Clear();
            autoAssignForm.Parent = this.panelMain;
        }
    }
}
