using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyWellEntity;
using MyWellBussiness;
using MyWellAppEntity;

namespace MyWellApp
{
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            BindResourceList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindResourceList();
            }
            catch (Exception)
            {
                MessageBox.Show("出现错误");
            }

        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            AddReource ar = new AddReource();
            ar.Show();
        }

        private void BindResourceList()
        {
            List<Resource> rl = ResourceBussiness.GetReourceList();
            dgvResourceList.DataSource = rl;
        }
    }
}
