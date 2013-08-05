using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EasyWellEntity;

namespace EasyWellData
{
    public class PersonData
    {
        public void AddPerson(Person person)
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=EducationManagementDB;uid=sa;pwd=123456;");
            try
            {
                sqlConn.Open();
                string commText="insert into person(name,sex,birthday,age,idcardno,persontype) values('"+person.Name+"','"+person.Sex+"','"+person.BirthDay+"',"+person.Age+",'"+person.IDCardNO+"','"+person.PersonType+"')";
                SqlCommand sqlComm = new SqlCommand(commText, sqlConn);
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

        }
    }
}
