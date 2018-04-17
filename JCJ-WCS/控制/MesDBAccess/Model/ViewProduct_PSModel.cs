using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// ViewProduct_PSModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ViewProduct_PSModel
    {
        public ViewProduct_PSModel()
        { }
        #region Model
        private string _productid;
        private string _productcata;
        private string _processstepid;
        private int? _processseq;
        private string _stepcata;
        private string _processstepname;
        private string _stationname;
        private string _cellname;
        private string _processparam1;
        private string _processparam2;
        private string _batchname;
        private string _palletid;
        private bool _palletbinded;
        private string _positionseq;
        private string _positionrow;
        private string _positioncol;
        private string _checkresult;
        private DateTime _onlinetime;
        private DateTime _modifytime;
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
        public string processStepID
        {
            set { _processstepid = value; }
            get { return _processstepid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? processSeq
        {
            set { _processseq = value; }
            get { return _processseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stepCata
        {
            set { _stepcata = value; }
            get { return _stepcata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string processStepName
        {
            set { _processstepname = value; }
            get { return _processstepname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stationName
        {
            set { _stationname = value; }
            get { return _stationname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cellName
        {
            set { _cellname = value; }
            get { return _cellname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessParam1
        {
            set { _processparam1 = value; }
            get { return _processparam1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessParam2
        {
            set { _processparam2 = value; }
            get { return _processparam2; }
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
        /// 
        /// </summary>
        public string positionSeq
        {
            set { _positionseq = value; }
            get { return _positionseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string positionRow
        {
            set { _positionrow = value; }
            get { return _positionrow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string positionCol
        {
            set { _positioncol = value; }
            get { return _positioncol; }
        }
        /// <summary>
        /// 
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
        #endregion Model

    }
}

