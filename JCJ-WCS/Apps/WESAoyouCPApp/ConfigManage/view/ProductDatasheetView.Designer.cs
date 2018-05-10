namespace ConfigManage
{
    partial class ProductDatasheetView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDatasheetView));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbx_sizeCata = new System.Windows.Forms.ToolStripComboBox();
            this.btnDicitemAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDicitemModify = new System.Windows.Forms.ToolStripButton();
            this.btnDicitemDel = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshDic = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancelCfg = new System.Windows.Forms.Button();
            this.buttonConfirmCfg = new System.Windows.Forms.Button();
            this.cbx_GasList = new System.Windows.Forms.ComboBox();
            this.cbx_Packsize = new System.Windows.Forms.ComboBox();
            this.cbx_Height = new System.Windows.Forms.ComboBox();
            this.richTextBoxProductMark = new System.Windows.Forms.RichTextBox();
            this.textBoxCataseq = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnImportCfgs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExport = new System.Windows.Forms.ToolStripButton();
            this.btnProductCfgAdd = new System.Windows.Forms.ToolStripButton();
            this.btnCfgModify = new System.Windows.Forms.ToolStripButton();
            this.btnDelSizeCfg = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshProductCfg = new System.Windows.Forms.ToolStripButton();
            this.textBox1QueryProduct = new System.Windows.Forms.ToolStripTextBox();
            this.btnQueryProductCfg = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1051, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1043, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "尺寸字典定义";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 288);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 264);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbx_sizeCata,
            this.btnDicitemAdd,
            this.btnDicitemModify,
            this.btnDicitemDel,
            this.btnRefreshDic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1037, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "类别";
            // 
            // cbx_sizeCata
            // 
            this.cbx_sizeCata.Name = "cbx_sizeCata";
            this.cbx_sizeCata.Size = new System.Drawing.Size(121, 25);
            this.cbx_sizeCata.SelectedIndexChanged += new System.EventHandler(this.cbx_sizeCata_SelectedIndexChanged);
            // 
            // btnDicitemAdd
            // 
            this.btnDicitemAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDicitemAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnDicitemAdd.Image")));
            this.btnDicitemAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDicitemAdd.Name = "btnDicitemAdd";
            this.btnDicitemAdd.Size = new System.Drawing.Size(36, 22);
            this.btnDicitemAdd.Text = "添加";
            this.btnDicitemAdd.Click += new System.EventHandler(this.btnDicitemAdd_Click);
            // 
            // btnDicitemModify
            // 
            this.btnDicitemModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDicitemModify.Image = ((System.Drawing.Image)(resources.GetObject("btnDicitemModify.Image")));
            this.btnDicitemModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDicitemModify.Name = "btnDicitemModify";
            this.btnDicitemModify.Size = new System.Drawing.Size(36, 22);
            this.btnDicitemModify.Text = "修改";
            this.btnDicitemModify.Click += new System.EventHandler(this.btnDicitemModify_Click);
            // 
            // btnDicitemDel
            // 
            this.btnDicitemDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDicitemDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDicitemDel.Image")));
            this.btnDicitemDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDicitemDel.Name = "btnDicitemDel";
            this.btnDicitemDel.Size = new System.Drawing.Size(36, 22);
            this.btnDicitemDel.Text = "删除";
            this.btnDicitemDel.Click += new System.EventHandler(this.btnDicitemDel_Click);
            // 
            // btnRefreshDic
            // 
            this.btnRefreshDic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefreshDic.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshDic.Image")));
            this.btnRefreshDic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDic.Name = "btnRefreshDic";
            this.btnRefreshDic.Size = new System.Drawing.Size(36, 22);
            this.btnRefreshDic.Text = "刷新";
            this.btnRefreshDic.Click += new System.EventHandler(this.btnRefreshDic_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.bindingNavigator1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1043, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "产品配置";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 264);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1037, 27);
            this.bindingNavigator1.TabIndex = 4;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 24);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonCancelCfg);
            this.panel2.Controls.Add(this.buttonConfirmCfg);
            this.panel2.Controls.Add(this.cbx_GasList);
            this.panel2.Controls.Add(this.cbx_Packsize);
            this.panel2.Controls.Add(this.cbx_Height);
            this.panel2.Controls.Add(this.richTextBoxProductMark);
            this.panel2.Controls.Add(this.textBoxCataseq);
            this.panel2.Controls.Add(this.textBoxProductName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxBarcode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 69);
            this.panel2.TabIndex = 3;
            // 
            // buttonCancelCfg
            // 
            this.buttonCancelCfg.Location = new System.Drawing.Point(915, 30);
            this.buttonCancelCfg.Name = "buttonCancelCfg";
            this.buttonCancelCfg.Size = new System.Drawing.Size(93, 31);
            this.buttonCancelCfg.TabIndex = 4;
            this.buttonCancelCfg.Text = "取消";
            this.buttonCancelCfg.UseVisualStyleBackColor = true;
            this.buttonCancelCfg.Click += new System.EventHandler(this.buttonCancelCfg_Click);
            // 
            // buttonConfirmCfg
            // 
            this.buttonConfirmCfg.Location = new System.Drawing.Point(803, 30);
            this.buttonConfirmCfg.Name = "buttonConfirmCfg";
            this.buttonConfirmCfg.Size = new System.Drawing.Size(106, 31);
            this.buttonConfirmCfg.TabIndex = 4;
            this.buttonConfirmCfg.Text = "确定";
            this.buttonConfirmCfg.UseVisualStyleBackColor = true;
            this.buttonConfirmCfg.Click += new System.EventHandler(this.buttonConfirmCfg_Click);
            // 
            // cbx_GasList
            // 
            this.cbx_GasList.FormattingEnabled = true;
            this.cbx_GasList.Location = new System.Drawing.Point(740, 3);
            this.cbx_GasList.Name = "cbx_GasList";
            this.cbx_GasList.Size = new System.Drawing.Size(84, 20);
            this.cbx_GasList.TabIndex = 3;
            // 
            // cbx_Packsize
            // 
            this.cbx_Packsize.FormattingEnabled = true;
            this.cbx_Packsize.Location = new System.Drawing.Point(535, 2);
            this.cbx_Packsize.Name = "cbx_Packsize";
            this.cbx_Packsize.Size = new System.Drawing.Size(138, 20);
            this.cbx_Packsize.TabIndex = 3;
            // 
            // cbx_Height
            // 
            this.cbx_Height.FormattingEnabled = true;
            this.cbx_Height.Location = new System.Drawing.Point(334, 4);
            this.cbx_Height.Name = "cbx_Height";
            this.cbx_Height.Size = new System.Drawing.Size(121, 20);
            this.cbx_Height.TabIndex = 3;
            // 
            // richTextBoxProductMark
            // 
            this.richTextBoxProductMark.Location = new System.Drawing.Point(605, 36);
            this.richTextBoxProductMark.Name = "richTextBoxProductMark";
            this.richTextBoxProductMark.Size = new System.Drawing.Size(192, 22);
            this.richTextBoxProductMark.TabIndex = 2;
            this.richTextBoxProductMark.Text = "";
            // 
            // textBoxCataseq
            // 
            this.textBoxCataseq.Location = new System.Drawing.Point(140, 37);
            this.textBoxCataseq.Name = "textBoxCataseq";
            this.textBoxCataseq.Size = new System.Drawing.Size(106, 21);
            this.textBoxCataseq.TabIndex = 1;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(334, 43);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(213, 21);
            this.textBoxProductName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(705, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "气源";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(63, 3);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(183, 21);
            this.textBoxBarcode.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "包装尺寸";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(553, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "备注";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "物料编号\r\n（按纸箱分类1~255）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "型号名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "产品高度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "物料号";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 107);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(848, 154);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportCfgs,
            this.toolStripButtonExport,
            this.btnProductCfgAdd,
            this.btnCfgModify,
            this.btnDelSizeCfg,
            this.btnRefreshProductCfg,
            this.textBox1QueryProduct,
            this.btnQueryProductCfg});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1037, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnImportCfgs
            // 
            this.btnImportCfgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnImportCfgs.Image = ((System.Drawing.Image)(resources.GetObject("btnImportCfgs.Image")));
            this.btnImportCfgs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportCfgs.Name = "btnImportCfgs";
            this.btnImportCfgs.Size = new System.Drawing.Size(60, 22);
            this.btnImportCfgs.Text = "导入数据";
            this.btnImportCfgs.Click += new System.EventHandler(this.btnImportCfgs_Click);
            // 
            // toolStripButtonExport
            // 
            this.toolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExport.Name = "toolStripButtonExport";
            this.toolStripButtonExport.Size = new System.Drawing.Size(84, 22);
            this.toolStripButtonExport.Text = "导出型号数据";
            this.toolStripButtonExport.Click += new System.EventHandler(this.toolStripButtonExport_Click);
            // 
            // btnProductCfgAdd
            // 
            this.btnProductCfgAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProductCfgAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnProductCfgAdd.Image")));
            this.btnProductCfgAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProductCfgAdd.Name = "btnProductCfgAdd";
            this.btnProductCfgAdd.Size = new System.Drawing.Size(36, 22);
            this.btnProductCfgAdd.Text = "添加";
            this.btnProductCfgAdd.Click += new System.EventHandler(this.btnProductCfgAdd_Click);
            // 
            // btnCfgModify
            // 
            this.btnCfgModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCfgModify.Image = ((System.Drawing.Image)(resources.GetObject("btnCfgModify.Image")));
            this.btnCfgModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCfgModify.Name = "btnCfgModify";
            this.btnCfgModify.Size = new System.Drawing.Size(36, 22);
            this.btnCfgModify.Text = "修改";
            this.btnCfgModify.Click += new System.EventHandler(this.btnCfgModify_Click);
            // 
            // btnDelSizeCfg
            // 
            this.btnDelSizeCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelSizeCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnDelSizeCfg.Image")));
            this.btnDelSizeCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelSizeCfg.Name = "btnDelSizeCfg";
            this.btnDelSizeCfg.Size = new System.Drawing.Size(36, 22);
            this.btnDelSizeCfg.Text = "删除";
            this.btnDelSizeCfg.Click += new System.EventHandler(this.btnDelSizeCfg_Click);
            // 
            // btnRefreshProductCfg
            // 
            this.btnRefreshProductCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefreshProductCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshProductCfg.Image")));
            this.btnRefreshProductCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshProductCfg.Name = "btnRefreshProductCfg";
            this.btnRefreshProductCfg.Size = new System.Drawing.Size(36, 22);
            this.btnRefreshProductCfg.Text = "刷新";
            this.btnRefreshProductCfg.ToolTipText = "显示所有";
            this.btnRefreshProductCfg.Click += new System.EventHandler(this.btnRefreshProductCfg_Click);
            // 
            // textBox1QueryProduct
            // 
            this.textBox1QueryProduct.Name = "textBox1QueryProduct";
            this.textBox1QueryProduct.Size = new System.Drawing.Size(130, 25);
            this.textBox1QueryProduct.ToolTipText = "请输入物料号";
            // 
            // btnQueryProductCfg
            // 
            this.btnQueryProductCfg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQueryProductCfg.Image = ((System.Drawing.Image)(resources.GetObject("btnQueryProductCfg.Image")));
            this.btnQueryProductCfg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueryProductCfg.Name = "btnQueryProductCfg";
            this.btnQueryProductCfg.Size = new System.Drawing.Size(36, 22);
            this.btnQueryProductCfg.Text = "检索";
            this.btnQueryProductCfg.Click += new System.EventHandler(this.btnQueryProductCfg_Click);
            // 
            // ProductDatasheetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 320);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductDatasheetView";
            this.Text = "产品型号管理";
            this.Load += new System.EventHandler(this.ProductDatasheetView_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cbx_sizeCata;
        private System.Windows.Forms.ToolStripButton btnDicitemAdd;
        private System.Windows.Forms.ToolStripButton btnDicitemModify;
        private System.Windows.Forms.ToolStripButton btnDicitemDel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnProductCfgAdd;
        private System.Windows.Forms.ToolStripButton btnCfgModify;
        private System.Windows.Forms.ToolStripButton btnDelSizeCfg;
        private System.Windows.Forms.ToolStripButton btnRefreshDic;
        private System.Windows.Forms.ToolStripButton btnRefreshProductCfg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.ComboBox cbx_Packsize;
        private System.Windows.Forms.ComboBox cbx_Height;
        private System.Windows.Forms.RichTextBox richTextBoxProductMark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancelCfg;
        private System.Windows.Forms.Button buttonConfirmCfg;
        private System.Windows.Forms.ToolStripButton btnImportCfgs;
        private System.Windows.Forms.ToolStripTextBox textBox1QueryProduct;
        private System.Windows.Forms.ToolStripButton btnQueryProductCfg;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_GasList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButtonExport;
        private System.Windows.Forms.TextBox textBoxCataseq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}