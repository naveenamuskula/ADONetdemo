﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONetdemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            txtresult.Text = (int.Parse(txtnumber1.Text)+ int.Parse(txtnumber2.Text)).ToString();
        }
    }
}
