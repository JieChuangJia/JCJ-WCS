using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// AsrsPortBufferModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AsrsPortBufferModel
    {
        public AsrsPortBufferModel()
        { }
        #region Model
        private string _nodeid;
        private string _housename;
        private string _palletbuffers;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 控制节点ID
        /// </summary>
        public string nodeID
        {
            set { _nodeid = value; }
            get { return _nodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string houseName
        {
            set { _housename = value; }
            get { return _housename; }
        }
        /// <summary>
        /// 托盘缓存，用","隔开
        /// </summary>
        public string palletBuffers
        {
            set { _palletbuffers = value; }
            get { return _palletbuffers; }
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

