using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CtlDBAccess.BLL;
using CtlDBAccess.Model;
using AsrsInterface;
using AsrsModel;
using System.Data;

namespace AsrsControl
{
    public class GsStatisticsPresenter
    {
        IGsStatisticsView View { get; set; }
        IAsrsManageToCtl asrsResManage;
        ControlTaskBll bllContorl = new ControlTaskBll();
        public static string WAITOUTPRODUCT = "待出库产品";
        public GsStatisticsPresenter(IGsStatisticsView view)
        {
            this.View = view;
        }
        public void SetAsrsResManage(IAsrsManageToCtl asrsResManage)
        {
            this.asrsResManage = asrsResManage;
        }
        public void QueryStatistics(DateTime startTime,DateTime endTime, string houseName,string houseArea,string gsName,string gsOperateType )
        {
            
            List<ControlTaskModel> gsOperList = GetGsList(startTime, endTime, houseName, houseArea, gsName, gsOperateType);

            if (gsOperList == null || gsOperList.Count ==0)
            {

                return ;
            }
            else
            {
                if (houseArea != "所有")
                {
                     for(int i=0;i<gsOperList.Count;i++)
                     {
                         ControlTaskModel ctm = gsOperList[i];
                         string [] rcl = ctm.tag2.Split('-');
                         
                         CellCoordModel cell = new CellCoordModel(int.Parse(rcl[0]),int.Parse(rcl[1]),int.Parse(rcl[2]));
                         string logicArea =  "OCV常温区";
                         if(this.asrsResManage.GetLogicAreaName(houseName,cell,ref logicArea)==false)
                         {
                             gsOperList.RemoveAt(i);
                             i--;
                             continue;
                         }
                         if(logicArea.ToString()!= houseArea)
                         {
                             gsOperList.RemoveAt(i);
                             i--;
                             continue;
                         }
                     }
                }
                else
                {

                }

                DataTable gsData = new DataTable();
                gsData.Columns.Add("库房名称");
                gsData.Columns.Add("库区");
                gsData.Columns.Add("货位名称");
                gsData.Columns.Add("托盘条码");
                gsData.Columns.Add("操作类型");
                gsData.Columns.Add("操作时间");
                for (int i = 0; i < gsOperList.Count;i++ )
                {
                    string[] palletIDArr = gsOperList[i].TaskParam.Split(';');
                    if(palletIDArr.Length <4)
                    {
                        continue;
                    }
                    string palletID = palletIDArr[3];
                    DataRow dr= gsData.NewRow();
                    dr["库房名称"] = gsOperList[i].tag1;
                    dr["库区"] = houseArea;
                    dr["货位名称"] = gsOperList[i].tag2;
                    dr["托盘条码"] = palletID;
                    dr["操作类型"] = gsOperateType;
                    if (gsOperateType == WAITOUTPRODUCT)
                    {
                        dr["操作时间"] = gsOperList[i].CreateTime;
                    }
                    else
                    {
                        dr["操作时间"] = gsOperList[i].FinishTime;
                    }

                  
                    gsData.Rows.Add(dr);
                }
               
                this.View.RefreshGs(gsData);
                this.View.ShowStatistics(gsOperList.Count.ToString());
            }
         
        }

        private List<ControlTaskModel> GetGsList(DateTime startTime, DateTime endTime, string houseName, string houseArea, string gsName, string gsOperateType)
        {
            string strSt = startTime.ToString("yyyy-MM-dd HH:00:00");
           // startTime = DateTime.Parse(strSt);
            string strEnd = endTime.ToString("yyyy-MM-dd HH:23:59");
          //  endTime = DateTime.Parse(strEnd);
            string sqlWhere = "";

            if (gsOperateType ==WAITOUTPRODUCT)
            {
                sqlWhere = "TaskStatus = '待执行' and CreateTime >= '" + strSt + "' and CreateTime <='" + strEnd + "' and  Remark ='产品出库' ";
            }
            else
            {
                sqlWhere = "TaskStatus = '已完成' and FinishTime >= '" + strSt + "' and FinishTime <='" + strEnd + "'";
            }
           
            if (houseName != "所有")
            {
                sqlWhere += "and tag1 = '" + houseName + "'";
            }
            if(!string.IsNullOrWhiteSpace(gsName.Trim()))
           // if (gsName != "所有")
            {
                sqlWhere += "and tag2 = '" + gsName + "'";
            }

            if (gsOperateType != "所有" && gsOperateType !=  WAITOUTPRODUCT)
            {
                sqlWhere += "and Remark = '" + gsOperateType + "'";
            }


            List<ControlTaskModel> gsOperList = bllContorl.GetModelList(sqlWhere);
            return gsOperList;
        }
    }
}
