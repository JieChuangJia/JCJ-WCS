using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// palletModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class palletModel
    {
        public palletModel()
        { }
        #region Model
        private string _palletid;
        private string _palletcata;
        private bool _bind;
        private int _stepno;
        private string _batchname;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public string palletID
        {
            set { _palletid = value; }
            get { return _palletid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string palletCata
        {
            set { _palletcata = value; }
            get { return _palletcata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bind
        {
            set { _bind = value; }
            get { return _bind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int stepNO
        {
            set { _stepno = value; }
            get { return _stepno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batchName
        {
            set { _batchname = value; }
            get { return _batchname; }
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

