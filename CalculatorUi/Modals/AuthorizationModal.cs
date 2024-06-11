using System;
using System.Windows.Forms;

namespace TelegramCalculator.UI.Modals
{
    [System.ComponentModel.DefaultBindingProperty("ActivationCode")]
    public partial class AuthorizationModal : Form
    {
        public string ActivationCode
        {
            get => activationCode_textBox.Text;
            set => activationCode_textBox.Text = value;
        }

        public AuthorizationModal()
        {
            InitializeComponent();
        }

        private void Submit_buttonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
