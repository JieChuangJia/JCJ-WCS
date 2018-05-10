using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace FlowCtlBaseModel
{
    public class WCSPathNodeModel
    {
        private string devCata = ""; //设备类别，站台，RGV,库房
        private string nodeFlag = ""; //节点标识,起点，中间路径点,终点
        private string nodeID = "";
        private string lastNodeID = "";
        private string nextNodeID = "";
        private int seqIndex = 0;
       // public string NodeName { get; set; }
        public string NodeID { get { return nodeID; } }
        public string LastNodeID { get { return lastNodeID; } set { lastNodeID = value; } }
        public string NextNodeID { get { return nextNodeID; } set { nextNodeID = value; } }
        public string NodeFlag { get { return nodeFlag; } }
        public int SeqIndex { get { return seqIndex; } }
        public string DevCata { get { return devCata; } set { devCata = value; } }
        
        public WCSPathNodeModel()
        {
           
        }
        public bool BuildPath(XElement nodeRoot,ref string reStr)
        {
            try
            {
                nodeID = nodeRoot.Attribute("nodeID").Value.ToString();
                nodeFlag = nodeRoot.Attribute("nodeFlag").Value.ToString();
                seqIndex = int.Parse(nodeRoot.Attribute("seq").Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
               return false;
            }
        }
       
    }
}
