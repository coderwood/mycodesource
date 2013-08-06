using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyWellEntity;
using EasyWellData;
using EasyUtility;

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
            Random random = new Random();

            Person person = new Person();
            person.Name = "张克";//todo junkezhang 姓名随机生成
            person.Sex = random.NextEnum<EnumCommon.GenderEnum>();
            person.PersonType = random.NextEnum<EnumCommon.PersonTypeEnum>();
            person.IDCardNO = random.Next(111111,999999).ToString(); //todo junkezhang 身份证号码随机生成
            person.Age = random.Next(13,99);
            person.BirthDay = random.NextDateTime(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(-10));
            return person;
        }
    }
}
