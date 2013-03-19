namespace MyWellApp
{
    partial class MainForm
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
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResourceList = new System.Windows.Forms.DataGridView();
            this.btnAddResource = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResourceList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.Location = new System.Drawing.Point(42, 34);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(205, 21);
            this.txtSearchContent.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(287, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvResourceList
            // 
            this.dgvResourceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResourceList.Location = new System.Drawing.Point(42, 78);
            this.dgvResourceList.Name = "dgvResourceList";
            this.dgvResourceList.RowTemplate.Height = 23;
            this.dgvResourceList.Size = new System.Drawing.Size(709, 404);
            this.dgvResourceList.TabIndex = 2;
            // 
            // btnAddResource
            // 
            this.btnAddResource.Location = new System.Drawing.Point(615, 34);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(75, 23);
            this.btnAddResource.TabIndex = 3;
            this.btnAddResource.Text = "增加";
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 494);
            this.Controls.Add(this.btnAddResource);
            this.Controls.Add(this.dgvResourceList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchContent);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResourceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResourceList;
        private System.Windows.Forms.Button btnAddResource;
    }
}

