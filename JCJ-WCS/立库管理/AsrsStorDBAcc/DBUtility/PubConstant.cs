using System;
using System.Configuration;

namespace AsrsStorDBAcc
{
    
    public class PubConstant
    {        
        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString = @"Data Source = .\;Initial Catalog=AcWMSDB;User ID=sa;Password=123456;";
      // public static string ConnectionString = "Data Source =P-PC\\MSSQLSERVER2008;Initial Catalog=WMSDB;User ID=sa;Password=123456;";
      //  public static string ConnectionString = "Data Source =.;Initial Catalog=WMSDB;User ID=sa;Password=123456;";
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
