namespace TelegramCalculator.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Logout_button = new System.Windows.Forms.Button();
            this.Logout_layout = new System.Windows.Forms.TableLayoutPanel();
            this.Loading = new System.Windows.Forms.PictureBox();
            this.Progress_label = new System.Windows.Forms.Label();
            this.Logout_layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // Logout_button
            // 
            this.Logout_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Logout_button.Location = new System.Drawing.Point(463, 3);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(112, 34);
            this.Logout_button.TabIndex = 1;
            this.Logout_button.Text = "Logout";
            this.Logout_button.UseVisualStyleBackColor = true;
            this.Logout_button.Click += new System.EventHandler(this.Logout_buttonClick);
            // 
            // Logout_layout
            // 
            this.Logout_layout.ColumnCount = 1;
            this.Logout_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Logout_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Logout_layout.Controls.Add(this.Logout_button, 0, 0);
            this.Logout_layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logout_layout.Location = new System.Drawing.Point(0, 0);
            this.Logout_layout.Name = "Logout_layout";
            this.Logout_layout.RowCount = 1;
            this.Logout_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Logout_layout.Size = new System.Drawing.Size(578, 40);
            this.Logout_layout.TabIndex = 2;
            // 
            // Loading
            // 
            this.Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Loading.Image = ((System.Drawing.Image)(resources.GetObject("Loading.Image")));
            this.Loading.Location = new System.Drawing.Point(228, 91);
            this.Loading.MaximumSize = new System.Drawing.Size(100, 100);
            this.Loading.MinimumSize = new System.Drawing.Size(100, 100);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(100, 100);
            this.Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Loading.TabIndex = 3;
            this.Loading.TabStop = false;
            // 
            // Progress_label
            // 
            this.Progress_label.AutoSize = true;
            this.Progress_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progress_label.Location = new System.Drawing.Point(0, 269);
            this.Progress_label.Name = "Progress_label";
            this.Progress_label.Size = new System.Drawing.Size(0, 25);
            this.Progress_label.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 294);
            this.Controls.Add(this.Progress_label);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.Logout_layout);
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "Form1";
            this.Text = "Telegram calculator";
            this.Logout_layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Loading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Logout_button;
        private System.Windows.Forms.TableLayoutPanel Logout_layout;
        private System.Windows.Forms.PictureBox Loading;
        private System.Windows.Forms.Label Progress_label;
    }
}

