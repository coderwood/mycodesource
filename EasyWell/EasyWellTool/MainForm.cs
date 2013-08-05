using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyWellTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void PersonManageMenu_Click(object sender, EventArgs e)
        {
            PersonList pl = new PersonList();
            pl.Show();
        }
    }
}
