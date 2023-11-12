namespace WindowsFormsApp6
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAim = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tblusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblusersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblusersBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tblusersBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.tblusersBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(66, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 88);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reaction";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAim
            // 
            this.btnAim.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAim.Location = new System.Drawing.Point(66, 170);
            this.btnAim.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnAim.Name = "btnAim";
            this.btnAim.Size = new System.Drawing.Size(142, 88);
            this.btnAim.TabIndex = 0;
            this.btnAim.Text = "Aim";
            this.btnAim.UseVisualStyleBackColor = false;
            this.btnAim.Click += new System.EventHandler(this.btnAim_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogOut.Location = new System.Drawing.Point(66, 276);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(142, 88);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // database1DataSet
            // 
            // 
            // tblusersBindingSource
            // 

            // 
            // tbl_usersTableAdapter
            // 
            // 
            // tblusersBindingSource1
            // 

            // 
            // tblusersBindingSource2
            // 

            // 
            // tblusersBindingSource3
            // 

            // 
            // tblusersBindingSource4
            // 

            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(720, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnAim);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblusersBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAim;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.BindingSource tblusersBindingSource;
        private System.Windows.Forms.BindingSource tblusersBindingSource1;
        private System.Windows.Forms.BindingSource tblusersBindingSource2;
        private System.Windows.Forms.BindingSource tblusersBindingSource4;
        private System.Windows.Forms.BindingSource tblusersBindingSource3;
    }
}