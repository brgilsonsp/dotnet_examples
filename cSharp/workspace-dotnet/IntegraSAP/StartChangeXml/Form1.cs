﻿using ApenasTeste;
using BL;
using System;
using System.Windows.Forms;

namespace StartChangeXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new RunMessenger().StartChangeXML();
        }
    }
}
