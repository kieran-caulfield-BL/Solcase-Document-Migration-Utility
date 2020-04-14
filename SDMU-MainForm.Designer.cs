namespace Solcase_Document_Migration_Utility
{
    partial class SDMU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDMU));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtBxClientName = new System.Windows.Forms.TextBox();
            this.txtBxMatterDescription = new System.Windows.Forms.TextBox();
            this.lblClientCode = new System.Windows.Forms.Label();
            this.lblMatterCode = new System.Windows.Forms.Label();
            this.treeViewClientMatters = new System.Windows.Forms.TreeView();
            this.btnImport = new MetroFramework.Controls.MetroButton();
            this.btnCopy = new MetroFramework.Controls.MetroButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tboxCopy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(154, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 368);
            this.dataGridView1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtBxClientName
            // 
            this.txtBxClientName.Location = new System.Drawing.Point(224, 61);
            this.txtBxClientName.Name = "txtBxClientName";
            this.txtBxClientName.Size = new System.Drawing.Size(268, 20);
            this.txtBxClientName.TabIndex = 2;
            // 
            // txtBxMatterDescription
            // 
            this.txtBxMatterDescription.Location = new System.Drawing.Point(224, 87);
            this.txtBxMatterDescription.Name = "txtBxMatterDescription";
            this.txtBxMatterDescription.Size = new System.Drawing.Size(462, 20);
            this.txtBxMatterDescription.TabIndex = 3;
            // 
            // lblClientCode
            // 
            this.lblClientCode.AutoSize = true;
            this.lblClientCode.Location = new System.Drawing.Point(153, 64);
            this.lblClientCode.Name = "lblClientCode";
            this.lblClientCode.Size = new System.Drawing.Size(64, 13);
            this.lblClientCode.TabIndex = 4;
            this.lblClientCode.Text = "Client Name";
            this.lblClientCode.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblMatterCode
            // 
            this.lblMatterCode.AutoSize = true;
            this.lblMatterCode.Location = new System.Drawing.Point(153, 90);
            this.lblMatterCode.Name = "lblMatterCode";
            this.lblMatterCode.Size = new System.Drawing.Size(65, 13);
            this.lblMatterCode.TabIndex = 5;
            this.lblMatterCode.Text = "Matter Desc";
            // 
            // treeViewClientMatters
            // 
            this.treeViewClientMatters.Location = new System.Drawing.Point(12, 113);
            this.treeViewClientMatters.Name = "treeViewClientMatters";
            this.treeViewClientMatters.Size = new System.Drawing.Size(136, 262);
            this.treeViewClientMatters.TabIndex = 6;
            this.treeViewClientMatters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewClientMatters_AfterSelect_1);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 61);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "IMPORT";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(905, 61);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "COPY";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tboxCopy
            // 
            this.tboxCopy.Location = new System.Drawing.Point(154, 487);
            this.tboxCopy.Multiline = true;
            this.tboxCopy.Name = "tboxCopy";
            this.tboxCopy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxCopy.Size = new System.Drawing.Size(826, 74);
            this.tboxCopy.TabIndex = 9;
            // 
            // SDMU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 577);
            this.Controls.Add(this.tboxCopy);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.treeViewClientMatters);
            this.Controls.Add(this.lblMatterCode);
            this.Controls.Add(this.lblClientCode);
            this.Controls.Add(this.txtBxMatterDescription);
            this.Controls.Add(this.txtBxClientName);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SDMU";
            this.Text = "Solcase Document Migration Utility";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtBxClientName;
        private System.Windows.Forms.TextBox txtBxMatterDescription;
        private System.Windows.Forms.Label lblClientCode;
        private System.Windows.Forms.Label lblMatterCode;
        private System.Windows.Forms.TreeView treeViewClientMatters;
        private MetroFramework.Controls.MetroButton btnCopy;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tboxCopy;
        private MetroFramework.Controls.MetroButton btnImport;
    }
}

