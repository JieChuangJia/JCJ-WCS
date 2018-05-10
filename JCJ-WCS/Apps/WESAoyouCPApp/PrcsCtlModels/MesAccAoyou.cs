using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FlowCtlBaseModel;
namespace PrcsCtlModelsAoyouCp
{
    public class MesAccAoyou:MesAccWrapper
    {
        public MesAccAoyou()
        {

        }
        public override string ParsePalletID(string palletID)
        {
            //throw new NotImplementedException();
            if(string.IsNullOrWhiteSpace(palletID))
            {
                return string.Empty;
            }
            if(palletID.Length<12)
            {
                return string.Empty;
            }
            string re = "";
            JObject jsonObj = new JObject(new JProperty("电芯型号", ""), new JProperty("料筐内衬类型", ""),new JProperty("料筐内衬PLC值", ""),new JProperty("分容库区",""));
            string batteryCata=palletID.Substring(0, 4);
            jsonObj["电芯型号"] = batteryCata;
            MesDBAccess.BLL.BatteryCataBll batCataBll = new MesDBAccess.BLL.BatteryCataBll();
            MesDBAccess.Model.BatteryCataModel batCataModel=batCataBll.GetModel(batteryCata);
            if(batCataModel==null)
            {
                return string.Empty;
            }
            MesDBAccess.BLL.PalletCataBll palletCataBll = new MesDBAccess.BLL.PalletCataBll();
            MesDBAccess.Model.PalletCataModel palletCataModel = palletCataBll.GetModel(batCataModel.palletCataID);
            if(palletCataModel == null)
            {
                return string.Empty;
            }
            jsonObj["料筐内衬类型"] = batCataModel.palletCataID;
            jsonObj["料筐内衬PLC值"] = palletCataModel.plcDefVal;
            jsonObj["分容库区"] = batCataModel.fenrongZone;
            re = jsonObj.ToString();
            return re;
        }
    }
}
