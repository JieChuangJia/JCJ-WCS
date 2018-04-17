using System;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// MainControlTaskModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MainControlTaskModel
    {
        public MainControlTaskModel()
        { }
        #region Model
        private string _maintaskid;
        private string _wmstaskid;
        private string _flowpathkey;
        private string _palletcode;
        private string _taskstatus;
        private string _tasktype;
        private string _stdevice;
        private string _stdevicecata;
        private string _stdeviceparam;
        private string _enddevice;
        private string _enddevicecata;
        private string _enddeviceparam;
        private DateTime _createtime;
        private DateTime? _finishtime;
        private string _createmode;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 主控制任务ID
        /// </summary>
        public string MainTaskID
        {
            set { _maintaskid = value; }
            get { return _maintaskid; }
        }
        /// <summary>
        /// WMS管理任务ID
        /// </summary>
        public string WMSTaskID
        {
            set { _wmstaskid = value; }
            get { return _wmstaskid; }
        }
        /// <summary>
        /// 物流路径标识
        /// </summary>
        public string FlowPathKey
        {
            set { _flowpathkey = value; }
            get { return _flowpathkey; }
        }
        /// <summary>
        /// 输送任务携带的托盘码，如果是多个，用","隔开
        /// </summary>
        public string PalletCode
        {
            set { _palletcode = value; }
            get { return _palletcode; }
        }
        /// <summary>
        /// 任务状态
        /// </summary>
        public string TaskStatus
        {
            set { _taskstatus = value; }
            get { return _taskstatus; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string TaskType
        {
            set { _tasktype = value; }
            get { return _tasktype; }
        }
        /// <summary>
        /// 起始设备号
        /// </summary>
        public string StDevice
        {
            set { _stdevice = value; }
            get { return _stdevice; }
        }
        /// <summary>
        /// 起始设备类别
        /// </summary>
        public string StDeviceCata
        {
            set { _stdevicecata = value; }
            get { return _stdevicecata; }
        }
        /// <summary>
        /// 起始设备的任务参数
        /// </summary>
        public string StDeviceParam
        {
            set { _stdeviceparam = value; }
            get { return _stdeviceparam; }
        }
        /// <summary>
        /// 终点设备
        /// </summary>
        public string EndDevice
        {
            set { _enddevice = value; }
            get { return _enddevice; }
        }
        /// <summary>
        /// 终点设备分类
        /// </summary>
        public string EndDeviceCata
        {
            set { _enddevicecata = value; }
            get { return _enddevicecata; }
        }
        /// <summary>
        /// 终点设备的任务参数
        /// </summary>
        public string EndDeviceParam
        {
            set { _enddeviceparam = value; }
            get { return _enddeviceparam; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? FinishTime
        {
            set { _finishtime = value; }
            get { return _finishtime; }
        }
        /// <summary>
        /// 创建模式
        /// </summary>
        public string CreateMode
        {
            set { _createmode = value; }
            get { return _createmode; }
        }
        /// <summary>
        /// 预留1
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 预留2
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 预留3
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 预留4
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 预留5
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}

