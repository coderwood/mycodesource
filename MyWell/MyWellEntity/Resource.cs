using System;


namespace MyWellEntity
{
    /// <summary>
    /// 资源实体类
    /// </summary>
    public class Resource
    {
        /// <summary>
        ///  唯一标识
        /// </summary>
        public int ResourceID { get; set; }

        /// <summary>
        ///  标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Classfication { get; set; }
    }
}
