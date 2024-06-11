using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TelegramCalculator.Service.Models;
using TelegramCalculator.UI.Events;
using TelegramCalculator.UI.ViewModels;
using TL;

namespace TelegramCalculator.UI.Controls
{
    public partial class ChatSelectControl : UserControl
    {
        private List<ChatShort> Chats { get; set; } = new List<ChatShort>();

        private List<ChatShort> Dialogs { get; set; } = new List<ChatShort>();

        private bool DisplayChats
        {
            get => Chats_checkBox.Checked;
            set => Chats_checkBox.Checked = value;
        }

        private bool DisplayDialogs
        {
            get => Users_checkBox.Checked;
            set => Users_checkBox.Checked = value;
        }

        public DateTime DateTimeOffset
        {
            get => DateTimeOffset_picker.Value;
            set => DateTimeOffset_picker.Value = value;
        }

        public event EventHandler<TelegramEventArgs<ChatQuery>> OnChatSubmit;

        public InputPeer SelectedValue { get; set; }
        
        private string SearchFilter
        {
            get => ChatTitle_TextBox.Text;
            set => ChatTitle_TextBox.Text = value;
        }

        private List<ChatShort> FilteredChats { get; set; } = new List<ChatShort>();
        
        public ChatSelectControl()
        {
            InitializeComponent();
            Process_button.Enabled = false;
            DisplayChats = true;
            DisplayDialogs = true;
            SearchFilter = string.Empty;
            ApplyFilter();
        }

        public void Init(List<ChatShort> chats, List<ChatShort> dialogs)
        {
            Chats = chats;
            Dialogs = dialogs;
            ApplyFilter();
        }

        private void ChatTitle_TextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            FilteredChats.Clear();
            if (DisplayChats)
            {
                FilteredChats.AddRange(Chats);
            }
            if (DisplayDialogs)
            {
                FilteredChats.AddRange(Dialogs);
            }
            FilteredChats = FilteredChats
                .Where(c => c.Title != null && c.Title.Contains(SearchFilter, StringComparison.OrdinalIgnoreCase))
                .ToList();
            Chats_ListBox.Items.Clear();

            Chats_ListBox.Items.AddRange(
                FilteredChats.Select(c => c.Title).ToArray()
            );
        }

        private void Process_button_Click(object sender, EventArgs e)
        {
            OnChatSubmit(this, new TelegramEventArgs<ChatQuery>(new ChatQuery(SelectedValue, DateTimeOffset)));
            Process_button.Enabled = false;
        }

        private void Chats_ListBox_DoubleClick(object sender, EventArgs e)
        {
            SelectedValue = FilteredChats.FirstOrDefault(c => c.Title.Equals(Chats_ListBox.SelectedItem)).Peer;
            SearchFilter = Chats_ListBox.SelectedItem.ToString();
            Process_button.Enabled = true;
        }

        private void Chats_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!DisplayDialogs && !DisplayChats)
            {
                DisplayChats = true;
            }
            else
            {
                ApplyFilter();
            }
        }

        private void Users_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!DisplayDialogs && !DisplayChats)
            {
                DisplayDialogs = true;
            }
            else
            {
                ApplyFilter();
            }
        }
    }
}
