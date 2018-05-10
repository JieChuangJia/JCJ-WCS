using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Xml.Linq;


namespace ASRSStorManage
{
    public class XMLOperater
    {
        private string strXmlFile;
        private static XmlDocument objXmlDoc = new XmlDocument();
        public XMLOperater(string XmlFile)
        {
            try
            {
                objXmlDoc.Load(XmlFile);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            strXmlFile = XmlFile;
        }

        #region 动态方法

        public XmlAttribute GetProperCollection(XmlNode node, string xmlArrtiName)
        {
            XmlAttribute xmlArrtiTemp = null;
            foreach (XmlAttribute xmlAttri in node.Attributes)
            {
                if (xmlAttri.Name == xmlArrtiName)
                {
                    xmlArrtiTemp = xmlAttri;
                    break;
                }
            }
            return xmlArrtiTemp;
        }
        public XmlNode GetNodeByName(string nodeName,string properName)
        {
            XmlNodeList nodeList =  objXmlDoc.GetElementsByTagName(nodeName);
            foreach(XmlNode node in nodeList)
            {
                foreach(XmlAttribute attri in node.Attributes)
                {
                    if ( attri.Value == properName)
                    {
                        return node;
                    }
                }
            }
            return null;
        }
        public DataView GetData(string XmlPathNode)
        {
            //查找数据。返回一个DataView
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }
        public XmlNode GetNodeByName(string nodeName)
        {
            XmlNodeList nodeList = GetNodesByName(nodeName);
            if(nodeList != null && nodeList.Count>0)
            {
                return nodeList[0];
            }
            else
            {
                return null;
            }
        }

        public void Replace(string XmlPathNode, string Content)
        {
            //更新节点内容。
            objXmlDoc.SelectSingleNode(XmlPathNode).InnerText = Content;
        }

        public void Delete(string Node)
        {
            //删除一个节点。
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.SelectSingleNode(Node));
        }

        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            //插入一节点和此节点的一子节点。
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            //插入一个节点，带一属性。
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Content)
        {
            //插入一个节点，不带属性。
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        /// <summary>
        /// 作者：np
        /// 时间：2013.6.4
        /// 内容：创建xml文件
        /// </summary>
        public void CreateXmlFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlDeclaration xmldec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldec);
            xmldoc.Save(strXmlFile);
        }

        /// <summary>
        /// 作者：np
        /// 时间：2013.6.4
        /// 内容：读取xml文件
        /// </summary>
        /// <returns></returns>
        public DataSet ReadFile()
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(this.strXmlFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
       
        public  XmlNodeList GetNodesByName(string nodeName)
        {
            return objXmlDoc.GetElementsByTagName(nodeName);
        }
        public void Save()
        {
            try
            {
                objXmlDoc.Save(strXmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

      
        /// <summary>
        /// ytj
        /// 2015.4.1
        /// 删除指令节点
        /// </summary>
        /// <param name="Element">删除条件</param>
        /// <param name="Content">条件值</param>
        /// <returns>是否删除成功</returns>
        public bool RemoveNodeByElement(string Element, string Content)
        {
            bool success = false;
            XmlElement rootnode = objXmlDoc.DocumentElement;

            foreach (XmlNode typeNode in rootnode.ChildNodes)
            {
                for (int loop = 0; loop < typeNode.ChildNodes.Count; loop++)
                {
                    if (Content == typeNode.ChildNodes[loop].SelectSingleNode(Element).InnerText)
                    {
                        XmlNode objNode = typeNode.ChildNodes[loop];
                        typeNode.RemoveChild(objNode);
                        objXmlDoc.Save(strXmlFile);
                        success = true;
                        break;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// ytj
        /// 2014.12.5
        /// 通过节点值找到指定节点
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="Content"></param>
        /// <returns></returns>
        public DataSet GetDataByElement(string Element, string Content)
        {
            DataSet ds = new DataSet();

            XmlElement rootnode = objXmlDoc.DocumentElement;
            XElement xelement = XElement.Parse(objXmlDoc.InnerXml);

            var finder = xelement.Elements("Inst").First((t) => t.Element(Element).Value == Content);
            XmlReader xmlReader = finder.CreateReader();

            ds.ReadXml(xmlReader);

            return ds;
        }

        #endregion
        #region 静态方法
        /// <summary>
        /// 作者：np
        /// 时间：2015年3月19日
        /// 内容：创建带有属性的节点默认属性名称为type
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        public  XmlNode CreateNodeWithAttribute(string nodeName, string nodeValue, string attributeValue)
        {
            if (nodeValue == null)
            {
                nodeValue = "";
            }
            if (nodeName == null)
            {
                nodeName = "";
            }
            XmlElement objElement = objXmlDoc.CreateElement(nodeName);
            objElement.InnerText = nodeValue;
            if (false == string.IsNullOrEmpty(attributeValue))
            {
                objElement.SetAttribute("type", attributeValue);
            }
            return objElement;
        }
      

        #endregion
    }

    
    
}
