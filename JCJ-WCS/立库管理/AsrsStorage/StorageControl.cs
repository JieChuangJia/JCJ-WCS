using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Storage
{
    public partial class StorageControl : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 表示是否任务锁定货仓
        /// </summary>
        public Positions selectPositions = null;
        public Storage storage = new Storage();
        #endregion

        #region 初始化
        public StorageControl()
        {
            InitializeComponent();
        }

        private void GoodsSiteControl_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region UI事件
        /// <summary>
        /// 自绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsSiteControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; //SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            storage.DrawStorage(e.Graphics);//可以考虑只刷新当前可见区域
            if (this.selectPositions != null)
            {
                storage.DrawSelect(e.Graphics, this.selectPositions);
            }
            e.Dispose();
        }

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsSiteControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.Invalidate();//重绘一次
            Point pt = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
            Positions pos = GetPostionsByPt(pt);

            if (pos != null)
            {
                if (this.PositionsClick != null)
                {
                    this.selectPositions = pos;
                    ClickPositionsEventArgs positionsArgs = new ClickPositionsEventArgs();
                    positionsArgs.Positions = pos;
                    PositionsClick.Invoke(this, positionsArgs);
                }
            }
        }
        #endregion

        #region 自定义事件
        [Description("货架单元格的鼠标事件:单击鼠标事件"), Category("Mouse")]
        public event ClickPositionsEventHandler PositionsClick;
        #endregion

        #region 事件委托
        public delegate void ClickPositionsEventHandler(object sender, ClickPositionsEventArgs e);
        public class ClickPositionsEventArgs : EventArgs
        {
            public Positions Positions { get; set; }
        }
        #endregion

        #region 属性

        private int currRowth;
        public int CurrRowth
        {
            get { return this.currRowth; }
            set
            {
                this.currRowth = value;
                this.storage.CurrRowth = this.currRowth;
            }
        }

        private int columns = 0;
        public int Columns
        {
            get { return this.columns; }
            set
            {
                this.columns = value;
                this.storage.Columns = this.columns;
            }
        }

        private int layers = 0;
        public int Layers
        {
            get { return this.layers; }
            set
            {
                this.layers = value;
                this.storage.Layers = this.layers;
            }
        }
        private List<Positions> dataSour;
        public List<Positions> DataSour
        {
            get { return this.dataSour; }
            set
            {
                this.dataSour = value;
                this.storage.DataSour = this.dataSour;
                SetScrollSize();
                this.Invalidate();
            }
        }

        #endregion

        #region 方法
        public Positions GetPositionsByCL(int columnth, int layerth)
        {
            try
            {
                return this.storage.GetPositionsByCL(columnth, layerth);
                //if (this.storage.Data != null)
                //{
                //    Positions pos = this.storage.Data[0][columnth][layerth];
                //    return pos;
                //}
                //else
                //{
                //    return null;
                //}
                //return null;
            }
            catch
            {
                return null;
            }
        }
        public Positions GetPositionsByRCL(int rowth, int colth, int layerth)
        {
            return this.storage.GetPos(rowth, colth, layers);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取仓位通过坐标点
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        private Positions GetPostionsByPt(Point pt)
        {
            return this.storage.GetPostionsByPt(pt);
        }

        /// <summary>
        /// 设置滚动范围根据列数和层数
        /// </summary>
        private void SetScrollSize()
        {
            int widthTemp = this.Size.Width;
            int heightTemp = this.Size.Height;
            if (widthTemp < this.storage.StorageSize.Width)
            {
                widthTemp = this.storage.StorageSize.Width;
            }

            if (heightTemp < this.storage.StorageSize.Height)
            {
                heightTemp = this.storage.StorageSize.Height;
            }
            this.AutoScrollMinSize = new Size(widthTemp, heightTemp);
        }
        #endregion

    }
}
