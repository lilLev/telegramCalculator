using System;
using System.Windows.Forms;

namespace TelegramCalculator.UI.Modals
{
    public partial class ExceptionModal : Form
    {
        public ExceptionModal(string header, string text)
        {
            InitializeComponent();

            Text = header ?? "Unexpected error";
            ErrorText_label.Text = text ?? "Unexpected error";
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
