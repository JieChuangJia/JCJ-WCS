using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// PalletCataModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PalletCataModel
    {
        public PalletCataModel()
        { }
        #region Model
        private string _palletcataid;
        private int _plcdefval;
        private string _mark;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public string PalletCataID
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

