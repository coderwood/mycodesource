using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyWellEntity;
using EasyWellBusiness;
using EasyUtility;

namespace EasyWellTool
{
    public partial class PersonList : Form
    {
        public PersonList()
        {
            InitializeComponent();
        }

        private void btnInitPerson_Click(object sender, EventArgs e)
        {
            List<Person> personList = new List<Person>();
            PersonBussiness pb = new PersonBussiness();
            for (int i = 0; i < 1000; i++)
            {
                log4net.ILog log = EasyLog.GetInstance();
                log.Info("start " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                Person person = pb.InitPerson();
                personList.Add(person);
                log.Info("end   " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }

            foreach (Person p in personList)
            {
                pb.AddPerson(p);
            }
        }
    }
}
