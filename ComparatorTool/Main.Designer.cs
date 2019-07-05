namespace ComparatorTool
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.compareBtn = new System.Windows.Forms.Button();
            this.lblMatchCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSlow = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonfast = new System.Windows.Forms.RadioButton();
            this.textBoxOld = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.checkBoxEdit = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.oldGridView = new System.Windows.Forms.DataGridView();
            this.newGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oldGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // compareBtn
            // 
            this.compareBtn.BackColor = System.Drawing.Color.White;
            this.compareBtn.Image = global::ComparatorTool.Properties.Resources.compare;
            this.compareBtn.Location = new System.Drawing.Point(467, 518);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(66, 43);
            this.compareBtn.TabIndex = 2;
            this.compareBtn.UseVisualStyleBackColor = false;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // lblMatchCount
            // 
            this.lblMatchCount.AutoSize = true;
            this.lblMatchCount.ForeColor = System.Drawing.Color.Blue;
            this.lblMatchCount.Location = new System.Drawing.Point(638, 434);
            this.lblMatchCount.Name = "lblMatchCount";
            this.lblMatchCount.Size = new System.Drawing.Size(0, 13);
            this.lblMatchCount.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSlow);
            this.groupBox1.Controls.Add(this.radioButtonMedium);
            this.groupBox1.Controls.Add(this.radioButtonfast);
            this.groupBox1.Location = new System.Drawing.Point(16, 515);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 55);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // radioButtonSlow
            // 
            this.radioButtonSlow.AutoSize = true;
            this.radioButtonSlow.Checked = true;
            this.radioButtonSlow.Location = new System.Drawing.Point(168, 24);
            this.radioButtonSlow.Name = "radioButtonSlow";
            this.radioButtonSlow.Size = new System.Drawing.Size(48, 17);
            this.radioButtonSlow.TabIndex = 2;
            this.radioButtonSlow.TabStop = true;
            this.radioButtonSlow.Text = "Slow";
            this.radioButtonSlow.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(88, 24);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonfast
            // 
            this.radioButtonfast.AutoSize = true;
            this.radioButtonfast.Location = new System.Drawing.Point(16, 24);
            this.radioButtonfast.Name = "radioButtonfast";
            this.radioButtonfast.Size = new System.Drawing.Size(45, 17);
            this.radioButtonfast.TabIndex = 0;
            this.radioButtonfast.TabStop = true;
            this.radioButtonfast.Text = "Fast";
            this.radioButtonfast.UseVisualStyleBackColor = true;
            // 
            // textBoxOld
            // 
            this.textBoxOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOld.Location = new System.Drawing.Point(0, 0);
            this.textBoxOld.Multiline = true;
            this.textBoxOld.Name = "textBoxOld";
            this.textBoxOld.Size = new System.Drawing.Size(494, 509);
            this.textBoxOld.TabIndex = 16;
            this.textBoxOld.Visible = false;
            this.textBoxOld.TextChanged += new System.EventHandler(this.textBoxOld_TextChanged);
            // 
            // textBoxNew
            // 
            this.textBoxNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNew.Location = new System.Drawing.Point(0, 0);
            this.textBoxNew.Multiline = true;
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(486, 509);
            this.textBoxNew.TabIndex = 17;
            this.textBoxNew.Visible = false;
            this.textBoxNew.TextChanged += new System.EventHandler(this.textBoxNew_TextChanged);
            // 
            // checkBoxEdit
            // 
            this.checkBoxEdit.AutoSize = true;
            this.checkBoxEdit.Location = new System.Drawing.Point(251, 525);
            this.checkBoxEdit.Name = "checkBoxEdit";
            this.checkBoxEdit.Size = new System.Drawing.Size(74, 17);
            this.checkBoxEdit.TabIndex = 18;
            this.checkBoxEdit.Text = "Edit Mode";
            this.checkBoxEdit.UseVisualStyleBackColor = true;
            this.checkBoxEdit.CheckedChanged += new System.EventHandler(this.checkBoxEditOld_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(816, 518);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear Result";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.oldGridView);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxOld);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.newGridView);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxNew);
            this.splitContainer1.Size = new System.Drawing.Size(984, 509);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 21;
            // 
            // oldGridView
            // 
            this.oldGridView.BackgroundColor = System.Drawing.Color.White;
            this.oldGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.oldGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.oldGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oldGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oldGridView.Location = new System.Drawing.Point(0, 0);
            this.oldGridView.Name = "oldGridView";
            this.oldGridView.RowHeadersVisible = false;
            this.oldGridView.Size = new System.Drawing.Size(494, 509);
            this.oldGridView.TabIndex = 22;
            // 
            // newGridView
            // 
            this.newGridView.BackgroundColor = System.Drawing.Color.White;
            this.newGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.newGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.newGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newGridView.Location = new System.Drawing.Point(0, 0);
            this.newGridView.Name = "newGridView";
            this.newGridView.RowHeadersVisible = false;
            this.newGridView.Size = new System.Drawing.Size(486, 509);
            this.newGridView.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(897, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 22;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(984, 579);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.checkBoxEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMatchCount);
            this.Controls.Add(this.compareBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Configuration Diff Utility";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oldGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button compareBtn;
        private System.Windows.Forms.Label lblMatchCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSlow;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonfast;
        private System.Windows.Forms.TextBox textBoxOld;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.CheckBox checkBoxEdit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView oldGridView;
        private System.Windows.Forms.DataGridView newGridView;
        private System.Windows.Forms.Button button1;
    }
}

