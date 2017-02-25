namespace RandomDraw
{
    partial class AutoAssignForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.comboBoxGroupNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(476, 43);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(66, 25);
            this.buttonImport.TabIndex = 0;
            this.buttonImport.Text = "人员导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(641, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "导入状态：";
            // 
            // buttonAssign
            // 
            this.buttonAssign.Location = new System.Drawing.Point(476, 87);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(66, 25);
            this.buttonAssign.TabIndex = 2;
            this.buttonAssign.Text = "分配";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // comboBoxGroupNo
            // 
            this.comboBoxGroupNo.FormattingEnabled = true;
            this.comboBoxGroupNo.Location = new System.Drawing.Point(144, 90);
            this.comboBoxGroupNo.Name = "comboBoxGroupNo";
            this.comboBoxGroupNo.Size = new System.Drawing.Size(317, 20);
            this.comboBoxGroupNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前分组：";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(643, 85);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(205, 21);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.Text = "未导入";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(62, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(786, 319);
            this.dataGridView1.TabIndex = 6;
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(144, 46);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(317, 21);
            this.textBoxFile.TabIndex = 7;
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(62, 44);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(76, 25);
            this.buttonFile.TabIndex = 9;
            this.buttonFile.Text = "选择文件：";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // AutoAssignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 476);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxGroupNo);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoAssignForm";
            this.Text = "AutoAssignForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.ComboBox comboBoxGroupNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonFile;
    }
}