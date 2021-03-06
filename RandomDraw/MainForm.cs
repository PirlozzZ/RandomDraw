﻿using System;
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
        RandomDrawForm randomDrawForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (basicFrom == null)
            {
                basicFrom = new BasicForm();
                basicFrom.TopLevel = false;
            }
            basicFrom.Show();
            this.panelMain.Controls.Clear();
            basicFrom.Parent = this.panelMain;

            autoAssignForm.Close(); 
            autoAssignForm = new AutoAssignForm();
            autoAssignForm.TopLevel = false;
             


        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (autoAssignForm == null)
            {
                autoAssignForm = new AutoAssignForm();
                autoAssignForm.TopLevel = false;
            }
            autoAssignForm.Show();
            this.panelMain.Controls.Clear();
            autoAssignForm.Parent = this.panelMain;
        }

        private void 抽签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();
            if (randomDrawForm == null)
            {
                randomDrawForm = new RandomDrawForm();
                randomDrawForm.TopLevel = false;
            }
            randomDrawForm.Show();
            this.panelMain.Controls.Clear();
            randomDrawForm.Parent = this.panelMain; 
        }
    }
}
