namespace TelegramCalculator.UI.Controls
{
    partial class ChatSelectControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Process_button = new System.Windows.Forms.Button();
            this.Chats_ListBox = new System.Windows.Forms.ListBox();
            this.ChatTitle_TextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Chats_checkBox = new System.Windows.Forms.CheckBox();
            this.Users_checkBox = new System.Windows.Forms.CheckBox();
            this.DateTimeOffset_picker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Process_button
            // 
            this.Process_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Process_button.Location = new System.Drawing.Point(250, 376);
            this.Process_button.Margin = new System.Windows.Forms.Padding(3, 3, 3, 35);
            this.Process_button.MaximumSize = new System.Drawing.Size(100, 35);
            this.Process_button.MinimumSize = new System.Drawing.Size(100, 35);
            this.Process_button.Name = "Process_button";
            this.Process_button.Size = new System.Drawing.Size(100, 35);
            this.Process_button.TabIndex = 2;
            this.Process_button.Text = "Process";
            this.Process_button.UseVisualStyleBackColor = true;
            this.Process_button.Click += new System.EventHandler(this.Process_button_Click);
            // 
            // Chats_ListBox
            // 
            this.Chats_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chats_ListBox.FormattingEnabled = true;
            this.Chats_ListBox.ItemHeight = 25;
            this.Chats_ListBox.Location = new System.Drawing.Point(3, 128);
            this.Chats_ListBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Chats_ListBox.Name = "Chats_ListBox";
            this.Chats_ListBox.Size = new System.Drawing.Size(594, 179);
            this.Chats_ListBox.TabIndex = 0;
            this.Chats_ListBox.DoubleClick += new System.EventHandler(this.Chats_ListBox_DoubleClick);
            // 
            // ChatTitle_TextBox
            // 
            this.ChatTitle_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatTitle_TextBox.Location = new System.Drawing.Point(3, 84);
            this.ChatTitle_TextBox.Name = "ChatTitle_TextBox";
            this.ChatTitle_TextBox.PlaceholderText = "Chat Title";
            this.ChatTitle_TextBox.Size = new System.Drawing.Size(594, 31);
            this.ChatTitle_TextBox.TabIndex = 1;
            this.ChatTitle_TextBox.Tag = "";
            this.ChatTitle_TextBox.TextChanged += new System.EventHandler(this.ChatTitle_TextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ChatTitle_TextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Chats_ListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Process_button, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.50114F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41648F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 437);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.Chats_checkBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Users_checkBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DateTimeOffset_picker, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 318);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 52);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Chats_checkBox
            // 
            this.Chats_checkBox.AutoSize = true;
            this.Chats_checkBox.Location = new System.Drawing.Point(121, 3);
            this.Chats_checkBox.Name = "Chats_checkBox";
            this.Chats_checkBox.Size = new System.Drawing.Size(82, 29);
            this.Chats_checkBox.TabIndex = 1;
            this.Chats_checkBox.Text = "Chats";
            this.Chats_checkBox.UseVisualStyleBackColor = true;
            this.Chats_checkBox.CheckedChanged += new System.EventHandler(this.Chats_checkBox_CheckedChanged);
            // 
            // Users_checkBox
            // 
            this.Users_checkBox.AutoSize = true;
            this.Users_checkBox.Location = new System.Drawing.Point(3, 3);
            this.Users_checkBox.Name = "Users_checkBox";
            this.Users_checkBox.Size = new System.Drawing.Size(81, 29);
            this.Users_checkBox.TabIndex = 0;
            this.Users_checkBox.Text = "Users";
            this.Users_checkBox.UseVisualStyleBackColor = true;
            this.Users_checkBox.CheckedChanged += new System.EventHandler(this.Users_checkBox_CheckedChanged);
            // 
            // DateTimeOffset_picker
            // 
            this.DateTimeOffset_picker.Location = new System.Drawing.Point(239, 3);
            this.DateTimeOffset_picker.Name = "DateTimeOffset_picker";
            this.DateTimeOffset_picker.Size = new System.Drawing.Size(352, 31);
            this.DateTimeOffset_picker.TabIndex = 2;
            // 
            // ChatSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatSelectControl";
            this.Size = new System.Drawing.Size(600, 437);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Process_button;
        private System.Windows.Forms.ListBox Chats_ListBox;
        private System.Windows.Forms.TextBox ChatTitle_TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox Chats_checkBox;
        private System.Windows.Forms.CheckBox Users_checkBox;
        private System.Windows.Forms.DateTimePicker DateTimeOffset_picker;
    }
}
