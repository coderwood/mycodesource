using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace HtlInv.Common.Utility
{
    public class XMLHelper
    {
        /// <summary>
        /// xml�ļ�·��
        /// </summary>
        string xmlPath = null;

        /// <summary>
        /// xml�ĵ�����
        /// </summary>
        XmlDocument doc=null;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="path"></param>
        public XMLHelper(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception("xml·������Ϊ��");
            this.xmlPath = path;
            this.doc = new XmlDocument();
            doc.Load(path);
        }

        /// <summary>
        /// ��ȡ�ƶ���node�ڵ�
        /// </summary>
        /// <param name="nodeName">�ڵ�����</param>
        /// <returns>xml�ڵ����</returns>
        public XmlNode GetXmlNodeByName(string nodeName)
        {
            if (string.IsNullOrEmpty(nodeName))
                return null;
            return EachXmlSerachNode(GetFirstNode(), nodeName);
        }

        /// <summary>
        /// �ݹ�ѭ������xml��ѯ����Ľڵ�����
        /// </summary>
        /// <param name="node">xml�ڵ�</param>
        /// <param name="nodeName">Ҫ���ҵĽڵ�����</param>
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
        /// ��ȡ��һ���ڵ�
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
        /// ��ȡxml�ڵ������ֵ
        /// </summary>
        /// <param name="node">xml�ڵ�</param>
        /// <param name="attrName">��������</param>
        /// <returns>����ֵ</returns>
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
        /// ��ȡĳ��xmlָ�����Ƶ��ӽڵ��б�
        /// </summary>
        /// <param name="node">xml�ڵ�</param>
        /// <param name="nodeName">�ӽڵ�����</param>
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
