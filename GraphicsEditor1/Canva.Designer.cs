namespace GraphicsEditor1
{
    partial class Canva
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canva));
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnMouseClick = new System.Windows.Forms.ToolStripButton();
            this.btnRectangularBox = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnPolyline = new System.Windows.Forms.ToolStripButton();
            this.btnPolygon = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEXsaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEXopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineStyleBox = new System.Windows.Forms.ComboBox();
            this.ThicknessTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ThicknessValue = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.btnUnDo = new System.Windows.Forms.Button();
            this.btnReDo = new System.Windows.Forms.Button();
            this.pbHistory = new System.Windows.Forms.PictureBox();
            this.ColorDialog = new System.Windows.Forms.PictureBox();
            this.btnWithoutFill = new System.Windows.Forms.PictureBox();
            this.BrushColor1 = new System.Windows.Forms.PictureBox();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWithoutFill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrushColor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMouseClick,
            this.btnRectangularBox,
            this.btnLine,
            this.btnRectangle,
            this.btnEllipse,
            this.btnPolyline,
            this.btnPolygon});
            this.toolStrip3.Location = new System.Drawing.Point(0, 28);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(0, 29, 1, 0);
            this.toolStrip3.Size = new System.Drawing.Size(25, 642);
            this.toolStrip3.TabIndex = 11;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnMouseClick
            // 
            this.btnMouseClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMouseClick.Image = ((System.Drawing.Image)(resources.GetObject("btnMouseClick.Image")));
            this.btnMouseClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMouseClick.Name = "btnMouseClick";
            this.btnMouseClick.Size = new System.Drawing.Size(22, 24);
            this.btnMouseClick.Text = "Mouse";
            this.btnMouseClick.Click += new System.EventHandler(this.btnMouseClick_Click);
            // 
            // btnRectangularBox
            // 
            this.btnRectangularBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangularBox.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangularBox.Image")));
            this.btnRectangularBox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectangularBox.Name = "btnRectangularBox";
            this.btnRectangularBox.Size = new System.Drawing.Size(22, 24);
            this.btnRectangularBox.Text = "RectangleBox";
            this.btnRectangularBox.Click += new System.EventHandler(this.btnRectangularBox_Click);
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(22, 24);
            this.btnLine.Text = "Line";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(22, 24);
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(22, 24);
            this.btnEllipse.Text = "ellipse";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnPolyline
            // 
            this.btnPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPolyline.Image = ((System.Drawing.Image)(resources.GetObject("btnPolyline.Image")));
            this.btnPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPolyline.Name = "btnPolyline";
            this.btnPolyline.Size = new System.Drawing.Size(22, 24);
            this.btnPolyline.Text = "polyline";
            this.btnPolyline.Click += new System.EventHandler(this.btnPolyline_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnPolygon.Image")));
            this.btnPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(22, 24);
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.imageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(24, 2, 2, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1081, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.newEXsaveToolStripMenuItem,
            this.newEXopenToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // newEXsaveToolStripMenuItem
            // 
            this.newEXsaveToolStripMenuItem.Name = "newEXsaveToolStripMenuItem";
            this.newEXsaveToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.newEXsaveToolStripMenuItem.Text = "Save Project";
            this.newEXsaveToolStripMenuItem.Click += new System.EventHandler(this.newEXsaveToolStripMenuItem_Click);
            // 
            // newEXopenToolStripMenuItem
            // 
            this.newEXopenToolStripMenuItem.Name = "newEXopenToolStripMenuItem";
            this.newEXopenToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.newEXopenToolStripMenuItem.Text = "Open";
            this.newEXopenToolStripMenuItem.Click += new System.EventHandler(this.newEXopenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(12, 24);
            this.toolStripMenuItem4.ToolTipText = "Отменить (Ctrl + Z)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.cutToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 24);
            this.toolStripMenuItem1.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.cutToolStripMenuItem.Text = "Delete";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem1_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // lineStyleBox
            // 
            this.lineStyleBox.FormattingEnabled = true;
            this.lineStyleBox.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.lineStyleBox.Location = new System.Drawing.Point(542, 41);
            this.lineStyleBox.Name = "lineStyleBox";
            this.lineStyleBox.Size = new System.Drawing.Size(128, 24);
            this.lineStyleBox.TabIndex = 33;
            this.lineStyleBox.Text = "Solid";
            this.lineStyleBox.SelectedIndexChanged += new System.EventHandler(this.lineStyleBox_SelectedIndexChanged);
            // 
            // ThicknessTrackBar
            // 
            this.ThicknessTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.ThicknessTrackBar.Location = new System.Drawing.Point(328, 32);
            this.ThicknessTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.ThicknessTrackBar.Name = "ThicknessTrackBar";
            this.ThicknessTrackBar.Size = new System.Drawing.Size(181, 56);
            this.ThicknessTrackBar.TabIndex = 31;
            this.ThicknessTrackBar.Scroll += new System.EventHandler(this.ThicknessTrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(179, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Color Pen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(723, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Color Brush";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Location = new System.Drawing.Point(1058, 626);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 34;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ThicknessValue
            // 
            this.ThicknessValue.AutoSize = true;
            this.ThicknessValue.BackColor = System.Drawing.Color.Gainsboro;
            this.ThicknessValue.Location = new System.Drawing.Point(484, 61);
            this.ThicknessValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ThicknessValue.Name = "ThicknessValue";
            this.ThicknessValue.Size = new System.Drawing.Size(16, 17);
            this.ThicknessValue.TabIndex = 35;
            this.ThicknessValue.Text = "1";
            // 
            // btnUnDo
            // 
            this.btnUnDo.BackColor = System.Drawing.Color.White;
            this.btnUnDo.Image = global::GraphicsEditor1.Properties.Resources.Без_имени_;
            this.btnUnDo.Location = new System.Drawing.Point(34, 40);
            this.btnUnDo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnDo.Name = "btnUnDo";
            this.btnUnDo.Size = new System.Drawing.Size(40, 38);
            this.btnUnDo.TabIndex = 37;
            this.btnUnDo.Text = " ";
            this.btnUnDo.UseVisualStyleBackColor = false;
            this.btnUnDo.Click += new System.EventHandler(this.btnUnDo_Click);
            // 
            // btnReDo
            // 
            this.btnReDo.BackColor = System.Drawing.Color.White;
            this.btnReDo.Image = global::GraphicsEditor1.Properties.Resources.Без_имени;
            this.btnReDo.Location = new System.Drawing.Point(78, 40);
            this.btnReDo.Margin = new System.Windows.Forms.Padding(0);
            this.btnReDo.Name = "btnReDo";
            this.btnReDo.Size = new System.Drawing.Size(40, 38);
            this.btnReDo.TabIndex = 36;
            this.btnReDo.UseVisualStyleBackColor = false;
            this.btnReDo.Click += new System.EventHandler(this.btnReDo_Click);
            // 
            // pbHistory
            // 
            this.pbHistory.BackColor = System.Drawing.SystemColors.Control;
            this.pbHistory.Image = global::GraphicsEditor1.Properties.Resources._4order_history;
            this.pbHistory.Location = new System.Drawing.Point(1038, 32);
            this.pbHistory.Name = "pbHistory";
            this.pbHistory.Size = new System.Drawing.Size(32, 37);
            this.pbHistory.TabIndex = 32;
            this.pbHistory.TabStop = false;
            this.pbHistory.Click += new System.EventHandler(this.pbHistory_Click);
            // 
            // ColorDialog
            // 
            this.ColorDialog.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ColorDialog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorDialog.Location = new System.Drawing.Point(257, 41);
            this.ColorDialog.Margin = new System.Windows.Forms.Padding(4);
            this.ColorDialog.Name = "ColorDialog";
            this.ColorDialog.Size = new System.Drawing.Size(38, 35);
            this.ColorDialog.TabIndex = 29;
            this.ColorDialog.TabStop = false;
            this.ColorDialog.Click += new System.EventHandler(this.ColorDialog_Click);
            // 
            // btnWithoutFill
            // 
            this.btnWithoutFill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnWithoutFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWithoutFill.Image = global::GraphicsEditor1.Properties.Resources.br;
            this.btnWithoutFill.Location = new System.Drawing.Point(866, 32);
            this.btnWithoutFill.Margin = new System.Windows.Forms.Padding(0);
            this.btnWithoutFill.Name = "btnWithoutFill";
            this.btnWithoutFill.Size = new System.Drawing.Size(38, 37);
            this.btnWithoutFill.TabIndex = 27;
            this.btnWithoutFill.TabStop = false;
            this.btnWithoutFill.Click += new System.EventHandler(this.btnWithoutFill_Click);
            // 
            // BrushColor1
            // 
            this.BrushColor1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BrushColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrushColor1.Location = new System.Drawing.Point(824, 32);
            this.BrushColor1.Margin = new System.Windows.Forms.Padding(4);
            this.BrushColor1.Name = "BrushColor1";
            this.BrushColor1.Size = new System.Drawing.Size(38, 37);
            this.BrushColor1.TabIndex = 26;
            this.BrushColor1.TabStop = false;
            this.BrushColor1.Click += new System.EventHandler(this.BrushColor1_Click);
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Canvas.Location = new System.Drawing.Point(34, 92);
            this.Canvas.Margin = new System.Windows.Forms.Padding(4);
            this.Canvas.MaximumSize = new System.Drawing.Size(1040, 550);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1040, 550);
            this.Canvas.TabIndex = 10;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // Canva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 670);
            this.Controls.Add(this.btnUnDo);
            this.Controls.Add(this.btnReDo);
            this.Controls.Add(this.ThicknessValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lineStyleBox);
            this.Controls.Add(this.pbHistory);
            this.Controls.Add(this.ThicknessTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColorDialog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWithoutFill);
            this.Controls.Add(this.BrushColor1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(1099, 717);
            this.MinimumSize = new System.Drawing.Size(1099, 717);
            this.Name = "Canva";
            this.Text = "Form1";
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWithoutFill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrushColor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnMouseClick;
        private System.Windows.Forms.ToolStripButton btnRectangularBox;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnRectangle;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.ToolStripButton btnPolyline;
        private System.Windows.Forms.ToolStripButton btnPolygon;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ComboBox lineStyleBox;
        private System.Windows.Forms.PictureBox pbHistory;
        private System.Windows.Forms.TrackBar ThicknessTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ColorDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnWithoutFill;
        private System.Windows.Forms.PictureBox BrushColor1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ThicknessValue;
        private System.Windows.Forms.Button btnUnDo;
        private System.Windows.Forms.Button btnReDo;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolStripMenuItem newEXsaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newEXopenToolStripMenuItem;
    }
}

