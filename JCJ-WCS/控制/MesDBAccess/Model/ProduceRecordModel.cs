using System;
namespace MesDBAccess.Model
{
	/// <summary>
	/// ProduceRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProduceRecordModel
	{
		public ProduceRecordModel()
		{}
		#region Model
		private string _recordid;
		private string _productid;
		private string _productcata;
		private string _stationid;
		private string _recordcata;
		private DateTime _recordtime;
		private string _checkresult;
		private string _tag1;
		private string _tag2;
		private string _tag3;
		private string _tag4;
		private string _tag5;
		/// <summary>
		/// 记录id，guid字符串
		/// </summary>
		public string recordID
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 产品（物料）ID
		/// </summary>
		public string productID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 产品类别
		/// </summary>
		public string productCata
		{
			set{ _productcata=value;}
			get{return _productcata;}
		}
		/// <summary>
		/// 工位号
		/// </summary>
		public string stationID
		{
			set{ _stationid=value;}
			get{return _stationid;}
		}
		/// <summary>
		/// 记录分类：流入/流出
		/// </summary>
		public string recordCata
		{
			set{ _recordcata=value;}
			get{return _recordcata;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime recordTime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 检验结果。
		/// </summary>
		public string checkResult
		{
			set{ _checkresult=value;}
			get{return _checkresult;}
		}
		/// <summary>
		/// 预留1
		/// </summary>
		public string tag1
		{
			set{ _tag1=value;}
			get{return _tag1;}
		}
		/// <summary>
		/// 预留2
		/// </summary>
		public string tag2
		{
			set{ _tag2=value;}
			get{return _tag2;}
		}
		/// <summary>
		/// 预留3
		/// </summary>
		public string tag3
		{
			set{ _tag3=value;}
			get{return _tag3;}
		}
		/// <summary>
		/// 预留4
		/// </summary>
		public string tag4
		{
			set{ _tag4=value;}
			get{return _tag4;}
		}
		/// <summary>
		/// 预留5
		/// </summary>
		public string tag5
		{
			set{ _tag5=value;}
			get{return _tag5;}
		}
		#endregion Model

	}
}

