using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FcNet.FormStyle.Demo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();

            JsonStyle.ApplyTheme(this, @".\Themes\orange.json");
        }

        private void FormDemo_Load(object sender, EventArgs e)
        {

        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            JsonStyle.ApplyTheme(this, @".\Themes\orange.json");
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            JsonStyle.ApplyTheme(this, @".\Themes\blue.json");
        }
    }
}
