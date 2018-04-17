using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace FlowCtlBaseModel
{
    public enum EnumNodeStatus
    {
        设备故障,
        设备空闲,
        设备使用中,
        无法识别
    }
    public class CtlNodeStatus : System.ComponentModel.INotifyPropertyChanged
    {

        private string nodeName = "";
        private EnumNodeStatus status;//节点状态
        private bool productExist;//是否有产品存在 
        private string productBarcode;//产品条码
        private string statDescribe;//状态描述
        public EnumNodeStatus Status { get { return status; } set { status = value; } }
        public bool ProductExist { get { return productExist; } set { productExist = value; } }
        public string StatDescribe { get { return statDescribe; } set { statDescribe = value; } }
        public string ProductBarcode { get { return productBarcode; } 
            set 
            { 
                productBarcode = value;
                OnPropertyChanged("ProductBarcode");
            } 
        }
        public string NodeName { get { return nodeName; } set { nodeName = value; } }
        public event PropertyChangedEventHandler PropertyChanged;
        public CtlNodeStatus(string nodeName)
        {
            this.nodeName = nodeName;
            status = EnumNodeStatus.设备空闲;
            productExist = false;
            statDescribe = "";
        }
        public void Copy(ref CtlNodeStatus targetNode)
        {
           // targetNode =new CtlNodeStatus(this.NodeName);
            targetNode.NodeName = nodeName;
            targetNode.ProductBarcode = this.productBarcode;
            targetNode.Status = this.status;
            targetNode.ProductExist = this.productExist;
            targetNode.StatDescribe = this.statDescribe;
        }
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
