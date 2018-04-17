using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// ProcessStepModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProcessStepModel
    {
        public ProcessStepModel()
        { }
        #region Model
        private int _stepno;
        private string _processstepname;
        private string _stepcata;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public int stepNO
        {
            set { _stepno = value; }
            get { return _stepno; }
        }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string processStepName
        {
            set { _processstepname = value; }
            get { return _processstepname; }
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
        /// 预留参数1
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 预留参数2
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 预留参数3
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 预留参数4
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 预留参数5
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}

