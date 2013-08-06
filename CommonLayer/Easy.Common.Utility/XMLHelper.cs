using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace HtlInv.Common.Utility
{
    public class XMLHelper
    {
        /// <summary>
        /// xml文件路径
        /// </summary>
        string xmlPath = null;

        /// <summary>
        /// xml文档对象
        /// </summary>
        XmlDocument doc=null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public XMLHelper(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("xml路径不能为空");
            this.xmlPath = path;
            this.doc = new XmlDocument();
            doc.Load(path);
        }

        /// <summary>
        /// 获取制定的node节点
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <returns>xml节点对象</returns>
        public XmlNode GetXmlNodeByName(string nodeName)
        {
            if (string.IsNullOrEmpty(nodeName))
                return null;
            return EachXmlSerachNode(GetFirstNode(), nodeName);
        }

        /// <summary>
        /// 递归循环整个xml查询所需的节点名称
        /// </summary>
        /// <param name="node">xml节点</param>
        /// <param name="nodeName">要查找的节点名称</param>
        /// <returns></returns>
        private XmlNode EachXmlSerachNode(XmlNode node,string nodeName)
        {
            if (node == null)
                return null ;
            if (string.IsNullOrEmpty(nodeName))
                return null;
            if (node.Name.Equals(nodeName))
            {
                return node;
            }
            if (node.HasChildNodes)
            {
                foreach (XmlNode tmpNode in node.ChildNodes)
                {
                    XmlNode tNode=EachXmlSerachNode(tmpNode, nodeName);
                    if (tNode != null)
                        return tNode;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取第一级节点
        /// </summary>
        /// <returns></returns>
        public XmlNode GetFirstNode()
        {
            if (doc == null)
                return null;
            if (doc.HasChildNodes)
                return doc.FirstChild;
            else
                return null;
        }

        /// <summary>
        /// 获取xml节点的属性值
        /// </summary>
        /// <param name="node">xml节点</param>
        /// <param name="attrName">属性名称</param>
        /// <returns>属性值</returns>
        public string GetAttributeValue(XmlNode node,string attrName)
        {
            if (node == null)
                return null;
            if (string.IsNullOrEmpty(attrName))
                return null;
            try
            {
                if (node.Attributes.Count > 0)
                    return node.Attributes[attrName].Value;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取某个xml指定名称的子节点列表
        /// </summary>
        /// <param name="node">xml节点</param>
        /// <param name="nodeName">子节点名称</param>
        /// <returns></returns>
        public List<XmlNode> GetXmlNodeList(XmlNode node, string nodeName)
        {
            if (string.IsNullOrEmpty(nodeName))
                return null;
            if (node == null)
                return null;
            if (node.HasChildNodes)
            {
                XmlNodeList listNode = node.ChildNodes;

                List<XmlNode> selectNodeList = new List<XmlNode>();
                foreach (XmlNode tmpNode in listNode)
                {
                    if (tmpNode.Name.Equals(nodeName))
                        selectNodeList.Add(tmpNode);
                }
                return selectNodeList;
            }
            return null;
        }
    }
}
