using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowCtlBaseModel
{
    public class FlowPathModel
    {
        private List<CtlNodeBaseModel> nodePath = new List<CtlNodeBaseModel>();
        public int PathSeq {get;set;}
        public bool PathEnabled { get; set; }
        public List<CtlNodeBaseModel> NodeList { get { return nodePath; } }
        public FlowPathModel()
        {
            PathSeq = 0;
            PathEnabled = true;
        }
        public void AddNode(CtlNodeBaseModel node)
        {
            nodePath.Add(node);
        }
        public bool DelNode(CtlNodeBaseModel node)
        {
            return nodePath.Remove(node);
        }
        public bool InsertNode(int insertIndex,CtlNodeBaseModel node)
        {
            if(nodePath.Count()<insertIndex)
            {
                return false;
            }
            nodePath.Insert(insertIndex, node);
            return true;
        }
        public bool IsPathConnected(string palletID, ref string reStr)
        {
            if(!PathEnabled)
            {
                reStr="路径已经被禁用";
                return PathEnabled;
            }
            foreach(CtlNodeBaseModel node in nodePath)
            {
                if(!node.IsPathOpened(palletID,ref reStr))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
