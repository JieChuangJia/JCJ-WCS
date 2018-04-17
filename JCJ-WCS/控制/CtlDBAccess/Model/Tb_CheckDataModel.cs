using System;
namespace DBAccess.Model
{
    /// <summary>
    /// Tb_CheckDataModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Tb_CheckDataModel
    {
        public Tb_CheckDataModel()
        { }
        #region Model
        private string _barcode;
        private string _tf_trayid;
        private string _ctray;
        private string _filename;
        private decimal? _fltcapacity;
        private decimal? _fltvol;
        private decimal? _fltresistance;
        private string _tf_checkgrade;
        private string _tf_group;
        private int? _tf_groupnum;
        private string _tf_location;
        private decimal? _cstate;
        private string _cdate;
        private string _cstatecode;
        /// <summary>
        /// 电池条码
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 托盘号
        /// </summary>
        public string Tf_TrayId
        {
            set { _tf_trayid = value; }
            get { return _tf_trayid; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string cTray
        {
            set { _ctray = value; }
            get { return _ctray; }
        }
        /// <summary>
        /// 批次
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fltCapacity
        {
            set { _fltcapacity = value; }
            get { return _fltcapacity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fltVol
        {
            set { _fltvol = value; }
            get { return _fltvol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fltResistance
        {
            set { _fltresistance = value; }
            get { return _fltresistance; }
        }
        /// <summary>
        /// 检测等级
        /// </summary>
        public string tf_CheckGrade
        {
            set { _tf_checkgrade = value; }
            get { return _tf_checkgrade; }
        }
        /// <summary>
        /// 第几组
        /// </summary>
        public string tf_Group
        {
            set { _tf_group = value; }
            get { return _tf_group; }
        }
        /// <summary>
        /// 第几组中的第几个
        /// </summary>
        public int? tf_GroupNum
        {
            set { _tf_groupnum = value; }
            get { return _tf_groupnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tf_Location
        {
            set { _tf_location = value; }
            get { return _tf_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cState
        {
            set { _cstate = value; }
            get { return _cstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cStateCode
        {
            set { _cstatecode = value; }
            get { return _cstatecode; }
        }
        #endregion Model

    }
}

