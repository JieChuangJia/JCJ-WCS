using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using AsrsControl;
using AsrsInterface;
using AsrsModel;
using AsrsExtctlSvc.Interface;
using LogInterface;
namespace AsrsExtctlSvc
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class HkFenrongSvc : IHangkeFenrong
    {
        private string logSrc = "分容系统服务";
        private IAsrsManageToCtl asrsResManage = null;
        private string houseName = "";
        public ILogRecorder logRecorder = null;
        public HkFenrongSvc(IAsrsManageToCtl asrsResM,string houseName)
        {
            asrsResManage = asrsResM;
            this.houseName = houseName;
        }
        string ver = "1.0.0 2018-1-6";
        public string GetInterfaceVersion()
        {
            return ver;
        }
        public bool IsAsrsCellReady(int row, int col, int layer, ref string[] barCodes, ref bool isReady, ref string reStr)
        {
            try
            {
              //  barCodes = new string[] { "TP12234" };
                barCodes = null;

                //Console.WriteLine("hello:收到货位{0}-{1}-{2}就绪状态查询调用",row,col,layer);
                if(logRecorder != null)
                {
                    logRecorder.AddDebugLog(logSrc, string.Format("hello:收到货位{0}-{1}-{2}就绪状态查询调用", row, col, layer));
                }
                CellCoordModel cell = new CellCoordModel(row, col, layer);
                EnumCellStatus cellStoreStat = EnumCellStatus.空闲;
                EnumGSTaskStatus cellTaskStat = EnumGSTaskStatus.完成;
                if (!this.asrsResManage.GetCellStatus(houseName, cell, ref cellStoreStat, ref cellTaskStat))
                {
                    reStr = string.Format("货位不存在：{0}-{1}-{2}", row, col, layer);
                    logRecorder.AddDebugLog(logSrc, reStr);
                    return false;
                }
                if (cellStoreStat == EnumCellStatus.满位 && cellTaskStat == EnumGSTaskStatus.完成)
                {
                    List<string> storBarcodes = new List<string>();
                    this.asrsResManage.GetStockDetail(houseName, cell, ref storBarcodes);
                    if (storBarcodes.Count() < 1)
                    {
                        isReady = false;
                        reStr = "货位没有产品";

                    }
                    else
                    {
                        barCodes = storBarcodes.ToArray();
                        isReady = true;
                        reStr = "查询OK";
                    }

                }
                else
                {
                    reStr = "货位没有产品";
                    isReady = false;
                }
                logRecorder.AddDebugLog(logSrc, string.Format("{0}-{1}-{2}就绪状态返回结果,{3},{4}", row, col, layer, isReady.ToString(),reStr));
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool CellValidStatNotify(int row, int col, int layer, bool cellValid, string reason, ref string reStr)
        {
            try
            {
                //Console.WriteLine("hello:收到货位{0}-{1}-{2} 启用/禁用 调用", row, col, layer);
                if(logRecorder != null)
                {
                    logRecorder.AddDebugLog(logSrc, string.Format("hello:收到货位{0}-{1}-{2} 启用/禁用:{3} 调用", row, col, layer,cellValid.ToString()));
                }
                CellCoordModel cell = new CellCoordModel(row, col, layer);
                EnumGSEnabledStatus enableStatus = EnumGSEnabledStatus.禁用;
                if (cellValid)
                {
                    enableStatus = EnumGSEnabledStatus.启用;
                }
                //zwx,此处需要修改
                return this.asrsResManage.UpdateGsEnabledStatus(houseName, cell, enableStatus, ref reStr);
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool FenrongOk(int row, int col, int layer, ref string reStr)
        {
            try
            {
                //Console.WriteLine("hello:收到货位{0}-{1}-{2} 分容OK通知调用", row, col, layer);
                if (logRecorder != null)
                {
                    logRecorder.AddDebugLog(logSrc, string.Format("hello:收到货位{0}-{1}-{2} 分容OK通知调用调用", row, col, layer));
                }
                CellCoordModel cell = new CellCoordModel(row, col, layer);
                EnumCellStatus cellStoreStat = EnumCellStatus.空闲;
                EnumGSTaskStatus cellTaskStat = EnumGSTaskStatus.完成;
                if (!this.asrsResManage.GetCellStatus(houseName, cell, ref cellStoreStat, ref cellTaskStat))
                {
                    reStr = string.Format("货位不存在：{0},{1}-{2}-{3}", houseName, row, col, layer);
                    //  logRecorder.AddDebugLog(objectName, "充电完成事件错误,"+reStr);
                    return false;
                }
                EnumGSEnabledStatus cellEnabledStatus = EnumGSEnabledStatus.禁用;
                if (!this.asrsResManage.GetCellEnabledStatus(houseName, cell, ref cellEnabledStatus))
                {

                    reStr = string.Format("货位禁用：{0},{1}-{2}-{3}", houseName, row, col, layer);
                    //logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }
                if (cellEnabledStatus == EnumGSEnabledStatus.禁用)
                {
                    reStr = string.Format("货位禁用：{0},{1}-{2}-{3}", houseName, row, col, layer);
                    //logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }
                if (cellStoreStat != EnumCellStatus.满位)
                {
                    reStr = string.Format("货位为空：{0},{1}-{2}-{3},", houseName, row, col, layer) + reStr;
                    //logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }
                if (cellTaskStat == EnumGSTaskStatus.出库允许)
                {
                    return true;
                }
                if (cellTaskStat == EnumGSTaskStatus.锁定)
                {
                    reStr = string.Format("货位任务锁定：{0},{1}-{2}-{3},", houseName, row, col, layer) + reStr;
                    //logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }

                cellTaskStat = EnumGSTaskStatus.出库允许;
                if (!this.asrsResManage.UpdateCellStatus(houseName, cell, cellStoreStat, cellTaskStat, ref reStr))
                {
                    reStr = string.Format("更新货位状态失败：{0},{1}-{2}-{3},", houseName, row, col, layer) + reStr;
                   // logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool CellStoreStateNotify(int row, int col, int layer, int stat, ref string reStr)
        {
            try
            {
                if (logRecorder != null)
                {
                    logRecorder.AddDebugLog(logSrc, string.Format("hello:收到货位{0}-{1}-{2} 货位状态 {3} 通知调用", row, col, layer,stat));
                }

               // Console.WriteLine("hello:收到货位{0}-{1}-{2} 货位状态通知调用", row, col, layer);
                CellCoordModel cell = new CellCoordModel(row, col, layer);
                EnumCellStatus cellStoreStat = EnumCellStatus.空闲;
                EnumGSTaskStatus cellTaskStat = EnumGSTaskStatus.完成;
                if (!this.asrsResManage.GetCellStatus(houseName, cell, ref cellStoreStat, ref cellTaskStat))
                {
                    reStr = string.Format("货位不存在：{0},{1}-{2}-{3}", houseName, row, col, layer);
                    //  logRecorder.AddDebugLog(objectName, "充电完成事件错误,"+reStr);
                    return false;
                }
                if(stat == 1)
                {
                    //cellStoreStat = EnumCellStatus.空闲;
                    //cellTaskStat = EnumGSTaskStatus.完成;
                }
                else if(stat==2)
                {
                     cellStoreStat = EnumCellStatus.满位;
                }
                else
                {
                    reStr=string.Format("分容系统传递过来的货位状态不识别，要求1~2，实际:{0}",stat);
                    return false;
                }
                if (!this.asrsResManage.UpdateCellStatus(houseName, cell, cellStoreStat, cellTaskStat, ref reStr))
                {
                    reStr = string.Format("更新货位状态失败：{0},{1}-{2}-{3},", houseName, row, col, layer) + reStr;
                   // logRecorder.AddDebugLog(objectName, "充电完成事件错误," + reStr);
                    return false;
                }
                //if(stat==1)
                //{
                //    if(!this.asrsResManage.RemoveStack(houseName, cell, ref reStr))
                //    {
                //        reStr = string.Format("移除库存失败：{0},{1}-{2}-{3},", houseName, row, col, layer) + reStr;
                //        return false;
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }

    }
}
