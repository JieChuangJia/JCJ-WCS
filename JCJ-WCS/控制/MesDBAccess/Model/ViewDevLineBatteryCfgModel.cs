using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// ViewDevLineBatteryCfgModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ViewDevLineBatteryCfgModel
    {
        public ViewDevLineBatteryCfgModel()
        { }
        #region Model
        private string _devbatterycfgid;
        private string _shopsection;
       
        private string _lineid;
        private string _mark;
        private string _batterycatacode;
        private string _palletcataid;
        private int _plcdefval;
        /// <summary>
        /// 
        /// </summary>
        public string DevBatteryCfgID
        {
            set { _devbatterycfgid = value; }
            get { return _devbatterycfgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopSection
        {
            set { _shopsection = value; }
            get { return _shopsection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineID
        {
            set { _lineid = value; }
            get { return _lineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batteryCataCode
        {
            set { _batterycatacode = value; }
            get { return _batterycatacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string palletCataID
        {
            set { _palletcataid = value; }
            get { return _palletcataid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int plcDefVal
        {
            set { _plcdefval = value; }
            get { return _plcdefval; }
        }
        #endregion Model

    }
}

