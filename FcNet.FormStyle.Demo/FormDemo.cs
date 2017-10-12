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

            JsonStyle.ApplyTheme(this, @".\JsonStyle\default.json");
        }

        private void FormDemo_Load(object sender, EventArgs e)
        {

        }
    }
}
