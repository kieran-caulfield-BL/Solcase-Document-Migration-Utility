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
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtBoxImportTotal = new System.Windows.Forms.TextBox();
            this.txtBoxCopyTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxSelectedTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(154, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 352);
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
            this.btnCopy.Location = new System.Drawing.Point(12, 471);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "COPY";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // tboxCopy
            // 
            this.tboxCopy.Location = new System.Drawing.Point(154, 497);
            this.tboxCopy.Multiline = true;
            this.tboxCopy.Name = "tboxCopy";
            this.tboxCopy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxCopy.Size = new System.Drawing.Size(826, 74);
            this.tboxCopy.TabIndex = 9;
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(493, 28);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(402, 23);
            this.metroLink1.TabIndex = 10;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(154, 471);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(826, 20);
            this.progressBar1.TabIndex = 11;
            // 
            // txtBoxImportTotal
            // 
            this.txtBoxImportTotal.Location = new System.Drawing.Point(67, 401);
            this.txtBoxImportTotal.Name = "txtBoxImportTotal";
            this.txtBoxImportTotal.Size = new System.Drawing.Size(81, 20);
            this.txtBoxImportTotal.TabIndex = 12;
            // 
            // txtBoxCopyTotal
            // 
            this.txtBoxCopyTotal.Location = new System.Drawing.Point(67, 551);
            this.txtBoxCopyTotal.Name = "txtBoxCopyTotal";
            this.txtBoxCopyTotal.Size = new System.Drawing.Size(81, 20);
            this.txtBoxCopyTotal.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Import Total";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Copy Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Selected";
            // 
            // txtBoxSelectedTotal
            // 
            this.txtBoxSelectedTotal.Location = new System.Drawing.Point(67, 445);
            this.txtBoxSelectedTotal.Name = "txtBoxSelectedTotal";
            this.txtBoxSelectedTotal.Size = new System.Drawing.Size(81, 20);
            this.txtBoxSelectedTotal.TabIndex = 16;
            // 
            // SDMU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 577);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxSelectedTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxCopyTotal);
            this.Controls.Add(this.txtBoxImportTotal);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.metroLink1);
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
        private MetroFramework.Controls.MetroLink metroLink1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtBoxImportTotal;
        private System.Windows.Forms.TextBox txtBoxCopyTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxSelectedTotal;
    }
}

