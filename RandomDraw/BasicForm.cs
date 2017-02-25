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
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(this.textBoxTitle.Text)){
                this.textBoxTitle.Text=MyConfiguration.getSetting("title");
            }
            if (string.IsNullOrEmpty(this.textBoxGroupNumber.Text))
            {
                this.textBoxGroupNumber.Text=MyConfiguration.getSetting("groupNumber");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            if (!Int32.TryParse(this.textBoxGroupNumber.Text,out count))
            {
                count = 1;
            }
            if (count <= 0)
            {
                count = 1;
            }
            MyConfiguration.updateSeeting("title", this.textBoxTitle.Text);
            MyConfiguration.updateSeeting("groupNumber", this.textBoxGroupNumber.Text);
        }

        private void textBoxGroupNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8){
                e.Handled = true;
            }
        }
    }
}
