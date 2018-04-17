using System;
using System.Configuration;

namespace MesDBAccess.DBUtility
{
    
    public class PubConstant
    {        
        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString = "Data Source = .\\SQLEXPRESS;Initial Catalog=ACMes;User ID=sa;Password=123456;";
     //   public static string ConnectionString2 = "Data Source = .\\SQLEXPRESS;Initial Catalog=HL_LWN;User ID=sa;Password=123456;";
        //{
        //    //get;
            
        //    get
        //    {
        //        //string connectStr = "Data Source = .\\SQLEXPRESS;Initial Catalog=FangTAIZaojuA;User ID=sa;Password=123456;";
        //        ////string connectStr = "Data Source = .;Initial Catalog=FangTAIZaojuA;User ID=sa;Password=123456;";
        //        ////string dbFileName = AppDomain.CurrentDomain.BaseDirectory + @"ECAMSDataBase.mdf;";
        //        ////string connectStr = @"Data Source =.\SQLEXPRESS;attachDbFileName=" + dbFileName + "Integrated Security=true;User Instance=True";
        //        ////string _connectionString = ConfigurationSettings.AppSettings["connectString"];
             
        //        //return _connectionString;
        //    }
        //    set { }
        //}
       
        
    }
}
