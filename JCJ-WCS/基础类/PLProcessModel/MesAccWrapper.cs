using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MesDBAccess.BLL;
using MesDBAccess.Model;
namespace FlowCtlBaseModel
{
    public class MesAccWrapper
    {
        private palletBll palletDbBll = new palletBll();
        public MesAccWrapper()
        {

        }
        /// <summary>
        /// 查询步号
        /// </summary>
        /// <param name="TrayNO"></param>
        /// <param name="step"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public bool GetStep(string TrayNO, out int step, ref string reStr)
        {
            step = 0;
            try
            {
                if(SysCfg.SysCfgModel.MesOnlineMode)
                {
                    //从MES查询
                    throw new NotImplementedException();
                }
                else
                {
                    //本地查询
                    palletModel pallet = palletDbBll.GetModel(TrayNO);
                    if (pallet == null)
                    {
                        pallet = new palletModel();
                        pallet.stepNO = 0; 
                        pallet.palletID = TrayNO;
                        pallet.bind = true;
                        pallet.batchName = "空";
                        palletDbBll.Add(pallet);
                       
                    }
                    step = pallet.stepNO;
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
              
            }
        }
        /// <summary>
        /// 更新步号
        /// </summary>
        /// <param name="StepNow"></param>
        /// <param name="TrayNO"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public bool UpdateStep(int StepNow, string TrayNO, ref string reStr)
        {
            try
            {
                //先更新本地步号
                palletModel pallet = palletDbBll.GetModel(TrayNO);
                if(pallet == null)
                {
                    pallet = new palletModel();
                    pallet.stepNO = StepNow ;
                    pallet.palletID = TrayNO;
                    pallet.bind = true;
                    pallet.batchName = "空";
                    palletDbBll.Add(pallet);
                }
                else
                {
                    pallet.stepNO = StepNow;
                    palletDbBll.Update(pallet);
                }
                //再更新MES步号
                if(SysCfg.SysCfgModel.MesOnlineMode)
                {
                    throw new NotImplementedException();
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        /// <summary>
        /// 解绑托盘
        /// </summary>
        /// <param name="TrayNo"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public bool UnbindTrayCell(string TrayNO,ref string reStr)
        {
            try
            {
                //先本地解绑
                palletModel pallet = palletDbBll.GetModel(TrayNO);
                if(pallet != null)
                {
                    pallet.bind = false;
                    pallet.stepNO = 0;
                    palletDbBll.Update(pallet);
                }
                //再解绑MES托盘
                if (SysCfg.SysCfgModel.MesOnlineMode)
                {
                    throw new NotImplementedException();
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        /// <summary>
        /// 获取分拣数据
        /// </summary>
        /// <param name="step"></param>
        /// <param name="trayNO"></param>
        /// <param name="cellJsonStr"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public bool GetCellSeparation(int step, string trayNO,ref string cellJsonStr,ref string reStr)
        {
            try
            {

                if(SysCfg.SysCfgModel.MesOnlineMode)
                {
                    throw new NotImplementedException();
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool GetTrayBindingCell(string TrayNo,out string jsonBind,ref string reStr)
        {
            jsonBind = "";
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool GetTrayCellLotNO(string trayNo,out string batchName,ref string reStr)
        {
            batchName = "空";
            try
            {
                if(SysCfg.SysCfgModel.MesOnlineMode)
                {
                    throw new NotFiniteNumberException();
                }
                else
                {
                     palletModel pallet = palletDbBll.GetModel(trayNo);
                     if (pallet != null)
                     {
                         batchName = pallet.batchName;
                     }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false ;
            }
        }
        public virtual string ParsePalletID(string palletID)
        {
            return string.Empty;
        }
    }
}
