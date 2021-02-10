namespace Lab02
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UI_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.UI_tsBtn_Load = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UI_tsBtn_Analyze = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UI_tsCBox_Algorithm = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.UI_tsCBx_selView = new System.Windows.Forms.ToolStripComboBox();
            this.UI_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.Ui_tsLbl_Loaded = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_tsLbl_Installable = new System.Windows.Forms.ToolStripStatusLabel();
            this.Ui_tsLbl_Uninstallable = new System.Windows.Forms.ToolStripStatusLabel();
            this.Ui_tsLBL_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.UI_DGV_Display = new System.Windows.Forms.DataGridView();
            this.UI_BS_Data = new System.Windows.Forms.BindingSource(this.components);
            this.UI_ToolStrip.SuspendLayout();
            this.UI_StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_BS_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_ToolStrip
            // 
            this.UI_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UI_tsBtn_Load,
            this.toolStripSeparator3,
            this.UI_tsBtn_Analyze,
            this.toolStripSeparator2,
            this.UI_tsCBox_Algorithm,
            this.toolStripSeparator1,
            this.UI_tsCBx_selView});
            this.UI_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.UI_ToolStrip.Name = "UI_ToolStrip";
            this.UI_ToolStrip.Size = new System.Drawing.Size(812, 25);
            this.UI_ToolStrip.TabIndex = 0;
            this.UI_ToolStrip.Text = "toolStrip1";
            // 
            // UI_tsBtn_Load
            // 
            this.UI_tsBtn_Load.AutoSize = false;
            this.UI_tsBtn_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_tsBtn_Load.Image = ((System.Drawing.Image)(resources.GetObject("UI_tsBtn_Load.Image")));
            this.UI_tsBtn_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_tsBtn_Load.Name = "UI_tsBtn_Load";
            this.UI_tsBtn_Load.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.UI_tsBtn_Load.Size = new System.Drawing.Size(80, 22);
            this.UI_tsBtn_Load.Text = "Load File";
            this.UI_tsBtn_Load.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // UI_tsBtn_Analyze
            // 
            this.UI_tsBtn_Analyze.AutoSize = false;
            this.UI_tsBtn_Analyze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UI_tsBtn_Analyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UI_tsBtn_Analyze.Name = "UI_tsBtn_Analyze";
            this.UI_tsBtn_Analyze.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.UI_tsBtn_Analyze.Size = new System.Drawing.Size(80, 22);
            this.UI_tsBtn_Analyze.Text = "Analyze";
            this.UI_tsBtn_Analyze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // UI_tsCBox_Algorithm
            // 
            this.UI_tsCBox_Algorithm.Name = "UI_tsCBox_Algorithm";
            this.UI_tsCBox_Algorithm.Size = new System.Drawing.Size(121, 25);
            this.UI_tsCBox_Algorithm.Text = "Raw Access";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // UI_tsCBx_selView
            // 
            this.UI_tsCBx_selView.AutoSize = false;
            this.UI_tsCBx_selView.Name = "UI_tsCBx_selView";
            this.UI_tsCBx_selView.Size = new System.Drawing.Size(125, 23);
            this.UI_tsCBx_selView.Text = "All Packages (Load)";
            // 
            // UI_StatusStrip
            // 
            this.UI_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ui_tsLbl_Loaded,
            this.UI_tsLbl_Installable,
            this.Ui_tsLbl_Uninstallable,
            this.Ui_tsLBL_time});
            this.UI_StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.UI_StatusStrip.Name = "UI_StatusStrip";
            this.UI_StatusStrip.Size = new System.Drawing.Size(812, 22);
            this.UI_StatusStrip.TabIndex = 1;
            this.UI_StatusStrip.Text = "statusStrip1";
            // 
            // Ui_tsLbl_Loaded
            // 
            this.Ui_tsLbl_Loaded.AutoSize = false;
            this.Ui_tsLbl_Loaded.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Ui_tsLbl_Loaded.Name = "Ui_tsLbl_Loaded";
            this.Ui_tsLbl_Loaded.Size = new System.Drawing.Size(166, 17);
            this.Ui_tsLbl_Loaded.Text = "0 Packages Loaded";
            // 
            // UI_tsLbl_Installable
            // 
            this.UI_tsLbl_Installable.AutoSize = false;
            this.UI_tsLbl_Installable.BackColor = System.Drawing.Color.LawnGreen;
            this.UI_tsLbl_Installable.Name = "UI_tsLbl_Installable";
            this.UI_tsLbl_Installable.Size = new System.Drawing.Size(166, 17);
            this.UI_tsLbl_Installable.Text = "0 Packages Installable";
            // 
            // Ui_tsLbl_Uninstallable
            // 
            this.Ui_tsLbl_Uninstallable.AutoSize = false;
            this.Ui_tsLbl_Uninstallable.BackColor = System.Drawing.Color.Red;
            this.Ui_tsLbl_Uninstallable.Name = "Ui_tsLbl_Uninstallable";
            this.Ui_tsLbl_Uninstallable.Size = new System.Drawing.Size(166, 17);
            this.Ui_tsLbl_Uninstallable.Text = "0 Packages Uninstallable";
            // 
            // Ui_tsLBL_time
            // 
            this.Ui_tsLBL_time.AutoSize = false;
            this.Ui_tsLBL_time.BackColor = System.Drawing.SystemColors.Info;
            this.Ui_tsLBL_time.Name = "Ui_tsLBL_time";
            this.Ui_tsLBL_time.Size = new System.Drawing.Size(300, 17);
            this.Ui_tsLBL_time.Text = "Analyze Time: <not run>";
            // 
            // UI_DGV_Display
            // 
            this.UI_DGV_Display.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UI_DGV_Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_Display.Location = new System.Drawing.Point(0, 29);
            this.UI_DGV_Display.Name = "UI_DGV_Display";
            this.UI_DGV_Display.RowHeadersVisible = false;
            this.UI_DGV_Display.Size = new System.Drawing.Size(812, 396);
            this.UI_DGV_Display.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.UI_DGV_Display);
            this.Controls.Add(this.UI_StatusStrip);
            this.Controls.Add(this.UI_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Lab02";
            this.UI_ToolStrip.ResumeLayout(false);
            this.UI_ToolStrip.PerformLayout();
            this.UI_StatusStrip.ResumeLayout(false);
            this.UI_StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_BS_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip UI_ToolStrip;
        private System.Windows.Forms.ToolStripButton UI_tsBtn_Load;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton UI_tsBtn_Analyze;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox UI_tsCBox_Algorithm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox UI_tsCBx_selView;
        private System.Windows.Forms.StatusStrip UI_StatusStrip;
        private System.Windows.Forms.DataGridView UI_DGV_Display;
        private System.Windows.Forms.ToolStripStatusLabel Ui_tsLbl_Loaded;
        private System.Windows.Forms.ToolStripStatusLabel UI_tsLbl_Installable;
        private System.Windows.Forms.ToolStripStatusLabel Ui_tsLbl_Uninstallable;
        private System.Windows.Forms.ToolStripStatusLabel Ui_tsLBL_time;
        private System.Windows.Forms.BindingSource UI_BS_Data;
    }
}

