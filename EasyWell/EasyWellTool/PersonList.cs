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
            Person person = pb.InitPerson();

            personList.Add(person);

            foreach (Person p in personList)
            {
                
                pb.AddPerson(p);
            }
        }
    }
}
