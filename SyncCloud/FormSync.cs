﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncCloud
{
    public partial class FormSync : Form
    {
        public FormSync()
        {
            InitializeComponent();
        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            
            Form form = new FormEditPass();
            form.ShowDialog();
        }

    }
}
