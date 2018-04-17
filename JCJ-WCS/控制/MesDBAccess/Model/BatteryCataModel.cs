using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// BatteryCataModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatteryCataModel
    {
        public BatteryCataModel()
        { }
        #region Model
        private string _batterycatacode;
        private string _palletcataid;
        private string _fenrongzone;
        private string _mark;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 电芯型号码
        /// </summary>
        public string batteryCataCode
        {
            set { _batterycatacode = value; }
            get { return _batterycatacode; }
        }
        /// <summary>
        /// 料筐类型
        /// </summary>
        public string palletCataID
        {
            set { _palletcataid = value; }
            get { return _palletcataid; }
        }
        /// <summary>
        /// 分容分区
        /// </summary>
        public string fenrongZone
        {
            set { _fenrongzone = value; }
            get { return _fenrongzone; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 预留字段3
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 预留字段4
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 预留字段5
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}

