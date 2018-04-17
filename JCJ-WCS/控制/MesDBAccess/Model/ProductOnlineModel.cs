using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// ProductOnlineModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductOnlineModel
    {
        public ProductOnlineModel()
        { }
        #region Model
        private string _productid;
        private string _productcata;
        private string _batchname;
        private int _stepno;
        private string _palletid;
        private bool _palletbinded;
        private string _stationid;
        private string _checkresult;
        private DateTime _onlinetime;
        private DateTime _modifytime;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public string productID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productCata
        {
            set { _productcata = value; }
            get { return _productcata; }
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
        public int stepNO
        {
            set { _stepno = value; }
            get { return _stepno; }
        }
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
        public bool palletBinded
        {
            set { _palletbinded = value; }
            get { return _palletbinded; }
        }
        /// <summary>
        /// 当前所在工位
        /// </summary>
        public string stationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 检验结果
        /// </summary>
        public string checkResult
        {
            set { _checkresult = value; }
            get { return _checkresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime onlineTime
        {
            set { _onlinetime = value; }
            get { return _onlinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
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

