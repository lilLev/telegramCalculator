
namespace TelegramCalculator.UI.Modals
{
    partial class AuthorizationModal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.activationCode_textBox = new System.Windows.Forms.TextBox();
            this.submit_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.activationCode_textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.submit_button, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 173);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // activationCode_textBox
            // 
            this.activationCode_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activationCode_textBox.Location = new System.Drawing.Point(3, 27);
            this.activationCode_textBox.Name = "activationCode_textBox";
            this.activationCode_textBox.PlaceholderText = "Activation Code";
            this.activationCode_textBox.Size = new System.Drawing.Size(509, 31);
            this.activationCode_textBox.TabIndex = 0;
            this.activationCode_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // submit_button
            // 
            this.submit_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submit_button.Location = new System.Drawing.Point(207, 112);
            this.submit_button.MaximumSize = new System.Drawing.Size(100, 35);
            this.submit_button.MinimumSize = new System.Drawing.Size(100, 35);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(100, 35);
            this.submit_button.TabIndex = 1;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.Submit_buttonClick);
            // 
            // AuthorizationModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 173);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(537, 229);
            this.MinimumSize = new System.Drawing.Size(537, 229);
            this.Name = "AuthorizationModal";
            this.Text = "Activation Code";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox activationCode_textBox;
        private System.Windows.Forms.Button submit_button;
    }
}