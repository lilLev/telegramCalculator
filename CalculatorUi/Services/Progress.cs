using System;
using System.Windows.Forms;

namespace TelegramCalculator.UI.Services
{
    class Progress : IProgress<int>
    {
        private readonly Label _label;

        public Progress(Label label)
        {
            _label = label;
        }
        public void Report(int value)
        {
            _label.Text = value.ToString();
        }
    }
}
