using System;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// 控制任务表
    /// </summary>
    [Serializable]
    public partial class ControlTaskModel
    {
        public ControlTaskModel()
        { }
        #region Model
        private string _taskid;
        private string _deviceid;
        private string _devicecata;
        private string _stdevice;
        private string _stdevicecata;
        private string _stdeviceparam;
        private string _enddevice;
        private string _enddevicecata;
        private string _enddeviceparam;
        private string _maintaskid;
        private string _palletcode;
        private int _controlid;
        private int _taskindex;
        private int _tasktype;
        private string _taskparam;
        private string _taskstatus;
        private int _taskphase;
        private DateTime _createtime;
        private DateTime? _finishtime;
        private string _createmode;
        private string _remark;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4 = "0";
        private string _tag5;

        /// <summary>
        /// 
        /// </summary>
        public string TaskID
        {
            set { _taskid = value; }
            get { return _taskid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 执行任务的设备类别，堆垛机、RGV、输送机
        /// </summary>
        public string DeviceCata
        {
            set { _devicecata = value; }
            get { return _devicecata; }
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
        /// 主任务ID,由WCS生成，对应管理任务
        /// </summary>
        public string MainTaskID
        {
            set { _maintaskid = value; }
            get { return _maintaskid; }
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
        /// 需要发送给PLC系统的任务ID，循环利用
        /// </summary>
        public int ControlID
        {
            set { _controlid = value; }
            get { return _controlid; }
        }
        /// <summary>
        /// 子任务在主任务中的序号
        /// </summary>
        public int TaskIndex
        {
            set { _taskindex = value; }
            get { return _taskindex; }
        }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int TaskType
        {
            set { _tasktype = value; }
            get { return _tasktype; }
        }
        /// <summary>
        /// 任务参数
        /// </summary>
        public string TaskParam
        {
            set { _taskparam = value; }
            get { return _taskparam; }
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
        /// 任务阶段
        /// </summary>
        public int TaskPhase
        {
            set { _taskphase = value; }
            get { return _taskphase; }
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
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
     
        #endregion Model

    }
}

