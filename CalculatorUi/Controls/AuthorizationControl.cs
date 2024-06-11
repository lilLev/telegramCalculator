using System;
using System.Windows.Forms;
using TelegramCalculator.UI.Events;

namespace TelegramCalculator.UI.Controls
{
    [System.ComponentModel.DefaultBindingProperty("PhoneNumber")]
    public partial class AuthorizationControl : UserControl
    {
        public event EventHandler<TelegramEventArgs<string>> OnPhoneNumberSubmit;
        public string PhoneNumber
        {
            get => phoneNumber_textBox.Text;
            set => phoneNumber_textBox.Text = value;
        }

        public AuthorizationControl()
        {
            InitializeComponent();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            OnPhoneNumberSubmit.Invoke(this, new TelegramEventArgs<string>(PhoneNumber));
        }
    }
}
