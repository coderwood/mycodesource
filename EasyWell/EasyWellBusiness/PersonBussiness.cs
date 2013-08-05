using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWellEntity;
using EasyWellData;
using EasyCommon;

namespace EasyWellBusiness
{
    /// <summary>
    /// 人员业务类
    /// </summary>
    public class PersonBussiness
    {
        public PersonBussiness()
        {
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            PersonData pd = new PersonData();
            pd.AddPerson(person);
        }

        /// <summary>
        /// 初始化人员信息
        /// </summary>
        /// <param name="person"></param>
        public Person InitPerson()
        {
            Person person = new Person();
            person.Name = "皮兴甜";
            person.Sex = GetRandomSex();
            person.PersonType = "student";
            person.IDCardNO = "";
            person.Age = 27;
            person.BirthDay = DateTime.Parse("1986-06-22");
            return person;
        }

        /// <summary>
        /// 随机获取性别
        /// </summary>
        /// <returns></returns>
        private string GetRandomString(Enum enumInfo)
        {
            Random random = new Random();
            int i = random.Next(1, Enum.GetNames(typeof(enumInfo)).Length);
            return ((GenderEnum)i).ToString();
        }
    }
}
