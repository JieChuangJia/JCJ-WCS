using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace FlowCtlBaseModel
{
    /// <summary>
    /// WCS路径模型
    /// </summary>
    public class WCSFlowPathModel
    {
        private string pathKey = "";
        private string pathDesc = "";
        private string pathID = "";
       
        private List<WCSPathNodeModel> nodePath = new List<WCSPathNodeModel>();
        public List<WCSPathNodeModel> NodeList { get { return nodePath; } }
        public string PathKey { get { return pathKey; } }
        public string PathDesc { get { return pathDesc; } }
        public string PathID { get { return pathID; } }
        public string PathCata { get; set; }
        public WCSFlowPathModel()
        {

        }
        public bool BuildPath(XElement pathRoot,ref string reStr)
        {
            try
            {
                IEnumerable<XElement> nodes=pathRoot.Elements("Node");
                pathKey=pathRoot.Attribute("pathKey").Value.ToString();
                pathDesc = pathRoot.Attribute("desc").Value.ToString();
                pathID = pathRoot.Attribute("ID").Value.ToString();
                foreach(XElement xeNode in nodes)
                {
                    WCSPathNodeModel wcsNode = new WCSPathNodeModel();
                    if(!wcsNode.BuildPath(xeNode,ref reStr))
                    {
                        return false;
                    }
                   
                    AddNode(wcsNode);
                }
                for (int i = 0; i < nodePath.Count();i++ )
                {
                    WCSPathNodeModel wcsNode = nodePath[i];
                    if(i==0)
                    {
                        wcsNode.LastNodeID = "";
                    }
                    else
                    {
                        wcsNode.LastNodeID = nodePath[i - 1].NodeID;
                    }
                    if(i==nodePath.Count()-1)
                    {
                        wcsNode.NextNodeID = "";
                    }
                    else
                    {
                        wcsNode.NextNodeID = nodePath[i + 1].NodeID;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
               
            }
        }
        public void AddNode(WCSPathNodeModel node)
        {
            nodePath.Add(node);
        }
        public bool DelNode(WCSPathNodeModel node)
        {
            return nodePath.Remove(node);
        }
        public bool InsertNode(int insertIndex, WCSPathNodeModel node)
        {
            if (nodePath.Count() < insertIndex)
            {
                return false;
            }
            nodePath.Insert(insertIndex, node);
            return true;
        }
        public WCSPathNodeModel GetNodeByID(string nodeID)
        {
            foreach(WCSPathNodeModel wcsNode in nodePath)
            {
                if(wcsNode.NodeID== nodeID)
                {
                    return wcsNode;
                }
            }
            return null;
        }
        public bool ContainNode(string nodeID)
        {
            WCSPathNodeModel node=GetNodeByID(nodeID);
            if(node == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
