using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataServiceGenerator
{
    public partial class frmOutput : Form
    {
        public frmOutput()
        {
            InitializeComponent();
        }
        public void setText(string s){
            this.txtContents.Text = s;
        }

        private void frmOutput_Resize(object sender, EventArgs e)
        {
            txtContents.Width = this.Width;
            txtContents.Height = this.Height;
        }
    }
}
