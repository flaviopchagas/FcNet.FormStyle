﻿using FcNet.FormStyleJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FcNet.FormStyle.Samples
{
    public partial class FormSample : Form
    {
        public FormSample()
        {
            InitializeComponent();
            ThemeEngine.ApplyTheme(this, @".\Themes\default.json");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormSample_Load(object sender, EventArgs e)
        {
        
        }

        private void btnCrud_Click(object sender, EventArgs e)
        {

        }
    }
}
