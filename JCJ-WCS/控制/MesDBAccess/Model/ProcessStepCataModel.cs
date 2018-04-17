using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// ProcessStepCata:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProcessStepCataModel
    {
        public ProcessStepCataModel()
        { }
        #region Model
        private string _stepcata;
        private string _catadesc;
        private string _tag1;
        private string _tag2;
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
        public string cataDesc
        {
            set { _catadesc = value; }
            get { return _catadesc; }
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
        #endregion Model

    }
}


