namespace QuickRESTexample
{
    partial class QuickRESTform
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
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnUSA = new System.Windows.Forms.Button();
            this.btnIT = new System.Windows.Forms.Button();
            this.btnCA = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(13, 13);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(75, 23);
            this.btnGetAll.TabIndex = 0;
            this.btnGetAll.Text = "Get All";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnUSA
            // 
            this.btnUSA.Location = new System.Drawing.Point(95, 12);
            this.btnUSA.Name = "btnUSA";
            this.btnUSA.Size = new System.Drawing.Size(108, 23);
            this.btnUSA.TabIndex = 1;
            this.btnUSA.Text = "Get USA ISO3";
            this.btnUSA.UseVisualStyleBackColor = true;
            this.btnUSA.Click += new System.EventHandler(this.btnUSA_Click);
            // 
            // btnIT
            // 
            this.btnIT.Location = new System.Drawing.Point(209, 12);
            this.btnIT.Name = "btnIT";
            this.btnIT.Size = new System.Drawing.Size(75, 23);
            this.btnIT.TabIndex = 2;
            this.btnIT.Text = "Get IT ISO2";
            this.btnIT.UseVisualStyleBackColor = true;
            this.btnIT.Click += new System.EventHandler(this.btnIT_Click);
            // 
            // btnCA
            // 
            this.btnCA.Location = new System.Drawing.Point(300, 12);
            this.btnCA.Name = "btnCA";
            this.btnCA.Size = new System.Drawing.Size(75, 23);
            this.btnCA.TabIndex = 3;
            this.btnCA.Text = "Search CA";
            this.btnCA.UseVisualStyleBackColor = true;
            this.btnCA.Click += new System.EventHandler(this.btnCA_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(13, 43);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(362, 343);
            this.txtResults.TabIndex = 4;
            // 
            // QuickRESTform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 398);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnCA);
            this.Controls.Add(this.btnIT);
            this.Controls.Add(this.btnUSA);
            this.Controls.Add(this.btnGetAll);
            this.Name = "QuickRESTform";
            this.Text = "QuickREST Example Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnUSA;
        private System.Windows.Forms.Button btnIT;
        private System.Windows.Forms.Button btnCA;
        private System.Windows.Forms.TextBox txtResults;
    }
}

