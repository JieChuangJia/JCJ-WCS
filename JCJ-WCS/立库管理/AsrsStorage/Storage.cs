using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using AsrsModel;

namespace Storage
{
  
    public partial class Storage
    {
        #region 全局变量
        /// <summary>
        /// 记录或设置表格值
        /// </summary>
        private DataTable gridValueDatatable = new DataTable();

        
        /// <summary>
        /// 线程
        /// </summary>
        private static object threadObj = new object();
       
        #endregion

        #region 初始化
        public Storage()
        {
          
        }
        #endregion

        #region 表格属性
        /// <summary>
        /// 数据源data[排][列][层]
        /// </summary>
        private Dictionary<int ,Dictionary<int ,Dictionary<int ,Positions>>> data
            = new Dictionary<int,Dictionary<int,Dictionary<int,Positions>>>();

        public string StorageID { get; set; }
        public string StorageName { get; set; }

        private int currRowth=1;
        public int CurrRowth
        {
            get { return this.currRowth; }
            set { this.currRowth = value; }
        }

        /// <summary>
        /// 排数
        /// </summary>
        private int rows;
        public int Rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }

        /// <summary>
        /// 列数
        /// </summary>
        private int columns;
        public int Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }

        /// <summary>
        /// 层数
        /// </summary>
        private int layers;
        public int Layers
        {
            get { return this.layers; }
            set { this.layers = value; }
        }

        /// <summary>
        /// 仓库宽度
        /// </summary>
        private int width;
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// 仓库高度
        /// </summary>
        private int height;
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// 列间距
        /// </summary>
        private int columnInterval = 6;
        public int ColumnInterval
        {
            get { return this.columnInterval; }
            set { this.columnInterval = value; }
        }
        
        /// <summary>
        /// 层间距
        /// </summary>
        private int layerInterval = 6;
        public int LayerInterval
        {
            get { return this.layerInterval; }
            set { this.layerInterval = value; }
        }

        /// <summary>
        /// 仓库起点
        /// </summary>
        private Point startPoint = new Point(70,50);
        public Point StartPoint
        {
            get { return this.startPoint; }
            set { this.startPoint = value; }
        }

        /// <summary>
        /// 画笔
        /// </summary>
        private Pen pen = new Pen(Brushes.Orange, 2);
        public Pen Pen
        {
            get { return this.pen; }
            set { this.pen = value; }
        }

        /// <summary>
        /// 字体
        /// </summary>
        private Font storageFont = new Font("宋体",12,FontStyle.Bold);
        public Font StorageFont
        {
            get { return this.storageFont; }
            set { this.storageFont = value; }
        }

        private List<Positions> dataSour;
        public List<Positions> DataSour
        {
            get { return this.dataSour; }
            set
            {
                this.dataSour = value;
                if (this.dataSour != null&&this.dataSour.Count>0)
                {
                    Positions pos = new Positions();
                   
                    this.columns = GetMaxCol(dataSour);
                    this.layers = GetMaxLayer(dataSour);
                    this.rows=GetMaxRowth(dataSour);
                    this.currRowth = dataSour[0].Rowth-1;
                    IniGrid(this.currRowth);
                    for (int i = 0; i < this.dataSour.Count; i++)
                    {
                        Positions posTemp = GetPos(this.dataSour[i].Rowth, this.dataSour[i].Columnth, this.dataSour[i].Layer);
                     
                        if (posTemp == null)
                        {
                            continue;
                        }
                        posTemp.GoodsSiteID = this.dataSour[i].GoodsSiteID;
                        posTemp.RunStatus = this.dataSour[i].RunStatus;
                        posTemp.StoreStatus = this.dataSour[i].StoreStatus;
                        posTemp.TaskType = this.dataSour[i].TaskType;
                        posTemp.PosText = this.dataSour[i].PosText;
                        posTemp.Visible = true;
                        posTemp.Color = this.dataSour[i].Color;
                        posTemp.BorderColor = this.dataSour[i].BorderColor;
                        posTemp.Style = this.dataSour[i].Style;
                    }
                    int controlWidth = this.columns * (pos.Width + this.columnInterval) + startPoint.X + 30;
                    int controlHeigt = this.layers * (pos.Height + this.layerInterval) + startPoint.Y + 55;

                    this.StorageSize = new Size(controlWidth, controlHeigt);
                }
            }
        }
        /// <summary>
        /// 表格数据源
        /// </summary>
        private DataTable dataSource;
        public DataTable DataSource
        {
            get { return this.dataSource; }
            set
            {
                this.dataSource = value;
                if (this.dataSource != null)
                {
                    Positions pos = new Positions();
                    int controlWidth = this.columns * (pos.Width + this.columnInterval) + startPoint.X + 30;
                    int controlHeigt = this.layers * (pos.Height + this.layerInterval) + startPoint.Y + 55;

                    this.StorageSize = new Size(controlWidth, controlHeigt);

                  //  SetValue(this.queryRowth, this.dataSource);
               
                }
            }
        }

        /// <summary>
        /// 根据货位的数量自动算出空间的大小
        /// </summary>
        public Size StorageSize
        {
            get;
            set;
        }

        #endregion

        #region 货仓方法
        /// <summary>
        /// 任务锁定时绘制
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pos"></param>
        public void DrawSelect(Graphics graphics, Positions pos)
        {
            Pen linePen = new System.Drawing.Pen(Brushes.SkyBlue, 4);

            if (pos.Visible == true)
            {
                this.DrawRect(graphics, linePen, pos);
            }
            else
            {
                this.ClearRect(graphics, pos);
            }

        }
        /// <summary>
        ///  通过坐标获取货位
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Positions GetPostionsByPt(Point pt)
        {
            Positions pos = null;
            //foreach (int rowth in this.data.Keys)
            //{
            if (this.data.Count == 0)
            {
                return null;
            }
            foreach (int col in this.data[this.currRowth].Keys)
            {
                foreach (int ly in this.data[this.currRowth][col].Keys)
                {

                    if (this.data[this.currRowth][col][ly].PosRect.Contains(pt))
                    {
                        pos = this.data[this.currRowth][col][ly];
                        break;
                    }
                }
                //}
            }
            return pos;
        }
        /// <summary>
        ///  通过列、层获取货位（默认只显示一排，数据里也只有一排）
        /// </summary>
        /// <param name="columnth"></param>
        /// <param name="layerth"></param>
        /// <returns></returns>
        public Positions GetPositionsByCL(int columnth, int layerth)
        {
            Positions pos = this.data[this.currRowth][columnth][layerth];
            return pos;
        }
        /// <summary>
        /// 绘制每一个货位
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawStorage(Graphics graphics)
        {
            foreach (int row in this.data.Keys)//排
            {
                foreach (int col in this.data[row].Keys)//列
                {
                    foreach (int ly in this.data[row][col].Keys)//层
                    {
                        Positions pos = this.data[row][col][ly];
                        if (pos.Visible == true)
                        {
                            this.DrawRect(graphics, this.Pen, pos);
                           
                            this.FillRect(graphics, pos.PosRect, pos.Color);
                            this.FillBorder(graphics,  pos);
                            this.DrawStrRect(graphics, pos);
                            this.DrawRectInRect(graphics, pos);
                        }
                        else
                        {
                            this.ClearRect(graphics,pos);
                        }
                    }
                }
            }
            DrawCoordinate(graphics);
        }
        /// <summary>
        /// 根据排列层获取货位（默认只显示一排，数据里也只有一排）
        /// </summary>
        /// <param name="rowth"></param>
        /// <param name="colth"></param>
        /// <param name="layerth"></param>
        /// <returns></returns>
        public Positions GetPos(int rowth, int colth, int layerth)
        {
            try
            {
                Positions pos = this.data[rowth - 1][colth - 1][layerth - 1];
                return pos;
            }
            catch
            {
                return null;
            }
        }
     
        #endregion

        #region 私有方法
        private int GetMaxCol(List<Positions> sourList)
        {
            int max = sourList.Max(pos => pos.Columnth);
          //Positions maxCol = sourList[index];
          //return maxCol.Columnth;
            return max;
        }
        private int GetMaxLayer(List<Positions> sourList)
        {
            int max = sourList.Max(pos => pos.Layer);
           // Positions maxLayer = sourList[index];
            //return maxLayer.Layer;
            return max;
        }

        private int GetMaxRowth(List<Positions> sourList)
        {
            int max = sourList.Max(pos => pos.Rowth);
            //Positions maxRow = sourList[index];
            //return maxRow.Rowth;
            return max;
        }
        /// <summary>
        /// 写字符串
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rect"></param>
        /// <param name="posPoint"></param>
        /// <param name="drawStr"></param>
        private void DrawStrRect(Graphics graphics,Positions pos)
        {
            Font drawFont = new Font("宋体", 10,FontStyle.Bold);
            SizeF strzSize = graphics.MeasureString(pos.PosText, drawFont);
            int pointX = (pos.Width -(int)strzSize.Width)/2 + pos.Location.X;
            int pointY = (pos.Height - (int)strzSize.Height) / 2 + pos.Location.Y+2;
            
            graphics.DrawString(pos.PosText, drawFont, Brushes.Silver, new Point(pointX,pointY));
        }

        /// <summary>
        /// 填充矩形
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rect"></param>
        /// <param name="brush"></param>
        private void FillRect(Graphics graphics, Rectangle rect,Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            graphics.FillRectangle(brush, rect);
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="rect"></param>
        private void DrawRect(Graphics graphics,Pen pen,Positions pos)
        {
            graphics.DrawRectangle(pen, pos.PosRect);

            Pen linePen = new System.Drawing.Pen(Brushes.Silver, 1);
            Point endPoint1 = new Point(pos.PosRect.Location.X + pos.Width, pos.PosRect.Location.Y + pos.Height);
            Point startPoint2 = new Point(pos.PosRect.Location.X + pos.Width, pos.PosRect.Location.Y);
            Point endPoint2 = new Point(pos.PosRect.Location.X, pos.PosRect.Location.Y + pos.Height);

            graphics.DrawLine(linePen, pos.PosRect.Location, endPoint1);
            graphics.DrawLine(linePen, startPoint2, endPoint2);

            linePen.Dispose();

        }

        private void DrawRectInRect(Graphics graphics, Positions pos)
        {
            if (pos.Style == 2)
            {
                Rectangle temp = new Rectangle(pos.PosRect.X + 8, pos.PosRect.Y + 5, pos.PosRect.Width - 16, pos.PosRect.Height - 10);
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(brush, temp);
            }
          

        }
        /// <summary>
        /// 填充边界颜色
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="pos"></param>
        private void FillBorder(Graphics graphics,Positions pos)
        {
            SolidBrush brush = new SolidBrush(pos.BorderColor);
            Rectangle upBorder = new Rectangle();
            upBorder.Location =  new Point(pos.Location.X-columnInterval,pos.Location.Y-layerInterval);
            upBorder.Width = pos.Width+2*columnInterval;
            upBorder.Height = layerInterval;

            Rectangle downBorder = new Rectangle();
            downBorder.Location  = new Point(pos.Location.X-columnInterval,pos.Location.Y+pos.Height);
            downBorder.Width = pos.Width + 2 * columnInterval;
            downBorder.Height = layerInterval;
            
            Rectangle leftBorder = new Rectangle();
            leftBorder.Location = new Point(pos.Location.X - columnInterval, pos.Location.Y - layerInterval);
            leftBorder.Width = columnInterval;
            leftBorder.Height = pos.Height +2*layerInterval;

            Rectangle rightBorder = new Rectangle();
            rightBorder.Location = new Point(pos.Location.X + pos.Width, pos.Location.Y-layerInterval);
            rightBorder.Width =columnInterval;
            rightBorder.Height =pos.Height+ 2*layerInterval;

            graphics.FillRectangle(brush, upBorder);
            graphics.FillRectangle(brush, downBorder);
            graphics.FillRectangle(brush, leftBorder);
            graphics.FillRectangle(brush, rightBorder);
        }
        private void ClearRect(Graphics graphics, Positions pos)
        {
            Pen pen = new System.Drawing.Pen(Brushes.Transparent, 4);
            graphics.DrawRectangle(pen, pos.PosRect);

            Pen linePen = new System.Drawing.Pen(Brushes.Transparent, 1);
            Point endPoint1 = new Point(pos.PosRect.Location.X + pos.Width, pos.PosRect.Location.Y + pos.Height);
            Point startPoint2 = new Point(pos.PosRect.Location.X + pos.Width, pos.PosRect.Location.Y);
            Point endPoint2 = new Point(pos.PosRect.Location.X, pos.PosRect.Location.Y + pos.Height);

            graphics.DrawLine(linePen, pos.PosRect.Location, endPoint1);
            graphics.DrawLine(linePen, startPoint2, endPoint2);

            linePen.Dispose();

        }
        /// <summary>
        /// 绘制列数、层数的标尺
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawCoordinate(Graphics graphics)
        {
            if (this.data.Count > 0)
            {
                int firCol = this.data[this.currRowth].ElementAt(0).Key;
                //写层数
                foreach (int ly in this.data[this.currRowth][firCol].Keys)
                {
                    Positions pos = this.data[this.currRowth][firCol][ly];
                    Point pt = new Point(pos.Location.X - 45, pos.Location.Y);
                    graphics.DrawString((ly + 1).ToString(), this.storageFont, Brushes.Silver, pt);
                }

                //画纵坐标系箭头
                Positions posFirstY = this.data[this.currRowth][firCol][0];
                Positions posEndY = this.data[this.currRowth][firCol][data[this.currRowth][firCol].Count - 1];
                Point startPtY = new Point(posFirstY.Location.X - 10, posFirstY.Location.Y + posFirstY.Height + 10);
                Point endPtY = new Point(posEndY.Location.X - 10, posEndY.Location.Y - 20);
                Point arrowsEndPtY1 = new Point(posEndY.Location.X - 15, posEndY.Location.Y - 10);
                Point arrowsEndPtY2 = new Point(posEndY.Location.X - 5, posEndY.Location.Y - 10);

                graphics.DrawLine(new Pen(Brushes.Silver, 2), startPtY, endPtY);
                graphics.DrawLine(new Pen(Brushes.Silver, 2), endPtY, arrowsEndPtY1);
                graphics.DrawLine(new Pen(Brushes.Silver, 2), endPtY, arrowsEndPtY2);

                //写字 层数 固定位置
                Point stringPtY1 = new Point(posFirstY.Location.X - 65, posFirstY.Location.Y -60);
                Point stringPtY2 = new Point(stringPtY1.X, stringPtY1.Y + 30);
                graphics.DrawString("层", this.storageFont, Brushes.Silver, stringPtY1);
                graphics.DrawString("数", this.storageFont, Brushes.Silver, stringPtY2);

                //写列数
                foreach (int col in this.data[this.currRowth].Keys)
                {
                    Positions pos = this.data[this.currRowth][col][0];//计算第一层就可以
                    Point pt = new Point(pos.Location.X, pos.Location.Y + 40);
                    graphics.DrawString((col + 1).ToString(), this.storageFont, Brushes.Silver, pt);
                }

                //画横坐标系箭头
                Positions posFirstX = this.data[this.currRowth][firCol][0];
                Positions posEndX = this.data[this.currRowth][this.data[this.currRowth].Count - 1][0];
                Point startPtX = new Point(posFirstX.Location.X - 10, posFirstX.Location.Y + posFirstX.Height + 10);
                Point endPtX = new Point(posEndX.Location.X + posEndX.Width + 20, posEndX.Location.Y + posFirstX.Height + 10);
                Point arrowsEndPtX1 = new Point(endPtX.X - 10, endPtX.Y - 5);
                Point arrowsEndPtX2 = new Point(endPtX.X - 10, endPtX.Y + 5);

                graphics.DrawLine(new Pen(Brushes.Silver, 2), startPtX, endPtX);
                graphics.DrawLine(new Pen(Brushes.Silver, 2), endPtX, arrowsEndPtX1);
                graphics.DrawLine(new Pen(Brushes.Silver, 2), endPtX, arrowsEndPtX2);

                //写 列汉字固定位置
                Point stringPtX1 = new Point(posFirstX.Location.X + 60,posEndX.Location.Y + posEndX.Height + 40);
                Point stringPtX2 = new Point(stringPtX1.X + 30, stringPtX1.Y);
                graphics.DrawString("列", this.storageFont, Brushes.Silver, stringPtX1);
                graphics.DrawString("数", this.storageFont, Brushes.Silver, stringPtX2);
            }
        }

        /// <summary>
        /// 赋值，这里只可以查看某一排的数据
        /// 并且按排列顺序存储
        /// </summary>
        /// <param name="rowth"></param>
        /// <param name="dt"></param>
        private void IniGrid(int rowth)
        {
            this.data.Clear();
            Dictionary<int, Dictionary<int, Positions>> dicColumn = new Dictionary<int, Dictionary<int, Positions>>();

            for (int i = 0; i < this.columns; i++)//列
            {
                Dictionary<int, Positions> dicLayer = new Dictionary<int, Positions>();
                for (int j = this.layers - 1; j >= 0; j--)//层
                {
                    Positions pos = new Positions();
                    pos.Rowth = rowth; //排、列、层 都加1目的是从1开始计数
                    //pos.Rowth = 0; //排、列、层 都加1目的是从1开始计数
                    pos.Columnth = i + 1;
                    pos.Layer = this.layers - j;

                    Point location = new Point();
                    location.X = i * pos.Width + i * this.columnInterval + this.startPoint.X;
                    location.Y = j * pos.Height + j * this.layerInterval + this.startPoint.Y;

                    Rectangle posRect = new Rectangle(location, new Size(pos.Width, pos.Height));
                    pos.PosRect = posRect;
                    pos.Location = location;
                    pos.Visible = false;
                    dicLayer.Add(this.layers - j - 1, pos);
                }
                dicColumn.Add(i, dicLayer);
            }
            this.data.Add(rowth, dicColumn);
           // this.data.Add(0, dicColumn);


        }
       
        /// <summary>
        /// 设置货位显隐
        /// </summary>
        /// <param name="rowth"></param>
        /// <param name="colth"></param>
        /// <param name="layerth"></param>
        /// <param name="status"></param>
        public void SetPositionVisible(int rowth, int colth, int layerth,bool status)
        {
            this.data[rowth][colth][layerth].Visible = status;
        }
      
         
        #endregion
    }
}
