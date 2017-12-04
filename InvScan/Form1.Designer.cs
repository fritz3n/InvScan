namespace InvScan
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AddButt = new System.Windows.Forms.Button();
            this.ParentBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PlaceBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.exploreView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Place = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Available = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Code_Field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExpNameBox = new System.Windows.Forms.TextBox();
            this.ExpPlaceBox = new System.Windows.Forms.TextBox();
            this.ExpDescBox = new System.Windows.Forms.TextBox();
            this.UpdateButt = new System.Windows.Forms.Button();
            this.DeleteButt = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CheckInButt = new System.Windows.Forms.Button();
            this.CheckInBox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CheckOutButt = new System.Windows.Forms.Button();
            this.CheckOutBox = new System.Windows.Forms.CheckBox();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.CodeButt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 304);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Deselected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.AddButt);
            this.tabPage1.Controls.Add(this.ParentBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.DescBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.PlaceBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NameBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(449, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add";
            // 
            // AddButt
            // 
            this.AddButt.Location = new System.Drawing.Point(134, 98);
            this.AddButt.Name = "AddButt";
            this.AddButt.Size = new System.Drawing.Size(75, 23);
            this.AddButt.TabIndex = 10;
            this.AddButt.Text = "Add";
            this.AddButt.UseVisualStyleBackColor = true;
            this.AddButt.Click += new System.EventHandler(this.AddButt_Click);
            // 
            // ParentBox
            // 
            this.ParentBox.Location = new System.Drawing.Point(7, 102);
            this.ParentBox.Name = "ParentBox";
            this.ParentBox.Size = new System.Drawing.Size(100, 20);
            this.ParentBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Parent";
            // 
            // DescBox
            // 
            this.DescBox.Location = new System.Drawing.Point(134, 18);
            this.DescBox.Multiline = true;
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(152, 64);
            this.DescBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // PlaceBox
            // 
            this.PlaceBox.Location = new System.Drawing.Point(6, 62);
            this.PlaceBox.Name = "PlaceBox";
            this.PlaceBox.Size = new System.Drawing.Size(100, 20);
            this.PlaceBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Place";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(6, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(449, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Explore";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.exploreView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(449, 278);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 0;
            // 
            // exploreView
            // 
            this.exploreView.AllowColumnReorder = true;
            this.exploreView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Place,
            this.Available,
            this.Code_Field});
            this.exploreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exploreView.FullRowSelect = true;
            this.exploreView.HideSelection = false;
            this.exploreView.Location = new System.Drawing.Point(0, 0);
            this.exploreView.Name = "exploreView";
            this.exploreView.ShowItemToolTips = true;
            this.exploreView.Size = new System.Drawing.Size(449, 158);
            this.exploreView.TabIndex = 0;
            this.exploreView.UseCompatibleStateImageBehavior = false;
            this.exploreView.View = System.Windows.Forms.View.Details;
            this.exploreView.SelectedIndexChanged += new System.EventHandler(this.exploreView_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 133;
            // 
            // Place
            // 
            this.Place.Text = "Place";
            this.Place.Width = 135;
            // 
            // Available
            // 
            this.Available.Text = "Available";
            this.Available.Width = 113;
            // 
            // Code_Field
            // 
            this.Code_Field.Text = "Code";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExpNameBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ExpPlaceBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ExpDescBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UpdateButt, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.DeleteButt, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 110);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Place:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // ExpNameBox
            // 
            this.ExpNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpNameBox.Location = new System.Drawing.Point(3, 18);
            this.ExpNameBox.Name = "ExpNameBox";
            this.ExpNameBox.Size = new System.Drawing.Size(104, 20);
            this.ExpNameBox.TabIndex = 7;
            // 
            // ExpPlaceBox
            // 
            this.ExpPlaceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpPlaceBox.Location = new System.Drawing.Point(3, 73);
            this.ExpPlaceBox.Name = "ExpPlaceBox";
            this.ExpPlaceBox.Size = new System.Drawing.Size(104, 20);
            this.ExpPlaceBox.TabIndex = 8;
            // 
            // ExpDescBox
            // 
            this.ExpDescBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpDescBox.Location = new System.Drawing.Point(113, 18);
            this.ExpDescBox.Multiline = true;
            this.ExpDescBox.Name = "ExpDescBox";
            this.tableLayoutPanel1.SetRowSpan(this.ExpDescBox, 3);
            this.ExpDescBox.Size = new System.Drawing.Size(215, 89);
            this.ExpDescBox.TabIndex = 9;
            // 
            // UpdateButt
            // 
            this.UpdateButt.Location = new System.Drawing.Point(334, 73);
            this.UpdateButt.Name = "UpdateButt";
            this.UpdateButt.Size = new System.Drawing.Size(75, 23);
            this.UpdateButt.TabIndex = 1;
            this.UpdateButt.Text = "Update";
            this.UpdateButt.UseVisualStyleBackColor = true;
            this.UpdateButt.Click += new System.EventHandler(this.UpdateButt_Click);
            // 
            // DeleteButt
            // 
            this.DeleteButt.Location = new System.Drawing.Point(334, 18);
            this.DeleteButt.Name = "DeleteButt";
            this.DeleteButt.Size = new System.Drawing.Size(75, 23);
            this.DeleteButt.TabIndex = 0;
            this.DeleteButt.Text = "Delete";
            this.DeleteButt.UseVisualStyleBackColor = true;
            this.DeleteButt.Click += new System.EventHandler(this.DeleteButt_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.CheckInButt);
            this.tabPage3.Controls.Add(this.CheckInBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(449, 278);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CheckIn";
            // 
            // CheckInButt
            // 
            this.CheckInButt.Location = new System.Drawing.Point(103, 2);
            this.CheckInButt.Name = "CheckInButt";
            this.CheckInButt.Size = new System.Drawing.Size(75, 23);
            this.CheckInButt.TabIndex = 1;
            this.CheckInButt.Text = "Check In";
            this.CheckInButt.UseVisualStyleBackColor = true;
            this.CheckInButt.Click += new System.EventHandler(this.CheckInButt_Click);
            // 
            // CheckInBox
            // 
            this.CheckInBox.AutoSize = true;
            this.CheckInBox.Location = new System.Drawing.Point(6, 6);
            this.CheckInBox.Name = "CheckInBox";
            this.CheckInBox.Size = new System.Drawing.Size(91, 17);
            this.CheckInBox.TabIndex = 0;
            this.CheckInBox.Text = "Auto CheckIn";
            this.CheckInBox.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.CheckOutButt);
            this.tabPage4.Controls.Add(this.CheckOutBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(449, 278);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "CheckOut";
            // 
            // CheckOutButt
            // 
            this.CheckOutButt.Location = new System.Drawing.Point(111, 2);
            this.CheckOutButt.Name = "CheckOutButt";
            this.CheckOutButt.Size = new System.Drawing.Size(75, 23);
            this.CheckOutButt.TabIndex = 1;
            this.CheckOutButt.Text = "Check Out";
            this.CheckOutButt.UseVisualStyleBackColor = true;
            this.CheckOutButt.Click += new System.EventHandler(this.CheckOutButt_Click);
            // 
            // CheckOutBox
            // 
            this.CheckOutBox.AutoSize = true;
            this.CheckOutBox.Location = new System.Drawing.Point(6, 6);
            this.CheckOutBox.Name = "CheckOutBox";
            this.CheckOutBox.Size = new System.Drawing.Size(99, 17);
            this.CheckOutBox.TabIndex = 0;
            this.CheckOutBox.Text = "Auto CheckOut";
            this.CheckOutBox.UseVisualStyleBackColor = true;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Location = new System.Drawing.Point(13, 36);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(37, 13);
            this.CodeLabel.TabIndex = 2;
            this.CodeLabel.Text = "xxxxxx";
            // 
            // CodeBox
            // 
            this.CodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeBox.Location = new System.Drawing.Point(13, 13);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(400, 20);
            this.CodeBox.TabIndex = 1;
            this.CodeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeBox_KeyDown);
            this.CodeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodeBox_KeyPress);
            // 
            // CodeButt
            // 
            this.CodeButt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeButt.Location = new System.Drawing.Point(419, 12);
            this.CodeButt.Name = "CodeButt";
            this.CodeButt.Size = new System.Drawing.Size(51, 21);
            this.CodeButt.TabIndex = 2;
            this.CodeButt.Text = "OK";
            this.CodeButt.UseVisualStyleBackColor = true;
            this.CodeButt.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 366);
            this.Controls.Add(this.CodeButt);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CodeLabel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(347, 259);
            this.Name = "Form1";
            this.Text = "Inventory";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.Button CodeButt;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView exploreView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Place;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PlaceBox;
        private System.Windows.Forms.TextBox ParentBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.Button AddButt;
        private System.Windows.Forms.ColumnHeader Available;
        private System.Windows.Forms.ColumnHeader Code_Field;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox CheckInBox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox CheckOutBox;
        private System.Windows.Forms.Button CheckInButt;
        private System.Windows.Forms.Button CheckOutButt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ExpNameBox;
        private System.Windows.Forms.TextBox ExpPlaceBox;
        private System.Windows.Forms.TextBox ExpDescBox;
        private System.Windows.Forms.Button UpdateButt;
        private System.Windows.Forms.Button DeleteButt;
    }
}

