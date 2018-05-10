using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AsrsModel;
using ASRSStorManage.View;
using AsrsStorDBAcc.Model;
using AsrsStorDBAcc.BLL;

namespace ASRSStorManage
{
    public partial class TestForm1 : Form
    {
         
        public TestForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reStr = "";
            StorageManager sm = new StorageManager();
            sm.Initialize(ref reStr);
            CellCoordModel cell = new CellCoordModel(1, 1,5);
            //EnumGSEnabledStatus gsSta = EnumGSEnabledStatus.禁用;
            //sm.GetCellEnabledStatus("A库房", cell, ref gsSta);
            //sm.UpdateCellStatus("A库房", cell, EnumCellStatus.满位, EnumGSTaskStatus.完成, ref reStr);
           // sm.UpdateGSOper("A库房", cell, EnumGSOperate.入库, ref reStr);
           // sm.CellRequire("A库房", ref cell, ref reStr);
           // EnumCellStatus cellSta = EnumCellStatus.满位;
           // EnumGSTaskStatus taskStas = EnumGSTaskStatus.锁定;
           // sm.GetCellStatus("A库房", cell, ref cellSta, ref taskStas);
            string[] ssf = new string[2];
            ssf[0] = "tb123";
            ssf[1] = "tb345";
          sm.AddStack("A库房", cell,"1234567", ssf, ref reStr);
            sm.UpdateCellStatus("A库房", cell, EnumCellStatus.满位, EnumGSTaskStatus.锁定, ref reStr);
           // sm.CellRequire("A库房", ref cell, ref reStr);
           // List<CellCoordModel> cellList = new List<CellCoordModel>();
           // sm.GetAllowLeftHouseGs("A库房", ref cellList, ref reStr);

           // sm.AddEmptyMeterialBox("A库房", cell, ref reStr);
           //// sm.AddGSOperRecord("A库房", cell, EnumGSOperateType.手动出库, ref reStr);

           // DateTime dt = new DateTime();
           // sm.GetCellInputTime("A库房", cell, ref dt);
           // sm.RemoveStack("A库房", cell, ref reStr);
           // sm.UpdateGSOper("A库房", cell, EnumGSOperate.出库, ref reStr);
           // sm.UpdateGsStatus("A库房", cell, EnumCellStatus.空料框, ref reStr);
           // sm.UpdateGsTaskStatus("A库房", cell, EnumGSTaskStatus.出库允许, ref reStr);

           //List<string> stockList = new List<string>();
           //sm.GetStockDetail("A库房", new CellCoordModel(1, 1, 5), ref stockList);
            StorageView storageView = new StorageView("库存管理");
            storageView.ShowDialog();
            //StorageView sv = new StorageView("wer");
            //sv.ShowDialog();
           
        }
    }
}
