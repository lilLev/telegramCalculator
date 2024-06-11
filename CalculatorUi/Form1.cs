using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramCalculator.Processors;
using TelegramCalculator.Services;
using TelegramCalculator.UI.Configurations;
using TelegramCalculator.UI.Constants;
using TelegramCalculator.UI.Controls;
using TelegramCalculator.UI.Events;
using TelegramCalculator.UI.Modals;
using TelegramCalculator.UI.Services;
using TelegramCalculator.UI.ViewModels;
using TL;

namespace TelegramCalculator.UI
{
    internal partial class Form1 : Form
    {
        private readonly ITelegramSumProcessor _telegramSumProcessor;

        private readonly ILocalStorage _localStorage;

        private readonly ILogger _logger;

        private ChatSelectControl _chatSelectControl;
        
        private AuthorizationControl _phoneNumberControl;

        private CriticalErrorControl _criticalErrorControl;
        
        private Control activeControl;

        private IProgress<int> progress;
        
        public Form1(ITelegramSumProcessor telegramSumProcessor,
            TelegramConfiguration telegramConfigurationsProvider,
            ILocalStorage localStorage,
            ILogger logger)
        {
            InitializeComponent();

            _telegramSumProcessor = telegramSumProcessor ?? throw new ArgumentNullException(nameof(telegramSumProcessor));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(telegramSumProcessor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            telegramConfigurationsProvider.VerificationCodeEventHandler += GetCode;

            _telegramSumProcessor.SetConfig(telegramConfigurationsProvider);

            InitControls();
            SwitchControl(Loading);
            
            Load += OnLoad;
        }

        private async void OnPhoneNumberSubmit(object sender, TelegramEventArgs<string> args)
        {
            _localStorage.Set(new LocalAuthData { PhoneNumber = args.Value });
            await AuthorizeAndLoadChats();
        }

        private async void OnChatSubmit(object sender, TelegramEventArgs<ChatQuery> args)
        {
            try
            {
                progress = new Progress(Progress_label);
                await _telegramSumProcessor.Process(args.Value.InputPeer, progress, dateTimeOffset: args.Value.DateTimeOffset);
                Progress_label.Text += " Done.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                if (ex.Message.Contains(CalculatorError.ChatNotFound.Message))
                {
                    HandleException(CalculatorError.ChatNotFound);
                }
                else
                {
                    HandleException(CalculatorError.UnexpectedError);
                }
            }
        }

        private void GetCode(object sender, TelegramEventArgs<string> args)
        {
            var modal = new AuthorizationModal();
            modal.ShowDialog();

            args.Value = modal.ActivationCode;
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            if (_localStorage.Get()?.PhoneNumber == null)
            {
                SwitchControl(_phoneNumberControl);
            }
            else
            {
                await AuthorizeAndLoadChats();
            }
        }

        private async Task AuthorizeAndLoadChats()
        {
            try
            {
                await _telegramSumProcessor.Login();

                var chats = await _telegramSumProcessor.GetChats();
                var dialogs = await _telegramSumProcessor.GetDialogs();
                _chatSelectControl.Init(chats, dialogs);

                SwitchControl(_chatSelectControl);
            }
            catch (RpcException ex)
            {
                var error = CalculatorError.UnexpectedError;
                if (ex.Message.Contains(CalculatorError.FloodWait.Code))
                {
                    error = CalculatorError.FloodWait;
                    error.Message = string.Format(error.Message, ex.X);
                }

                HandleException(error);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                HandleException(CalculatorError.UnexpectedError);
            }
        }

        private void HandleException(CalculatorError error)
        {
            var modal = new ExceptionModal(error.ModalHeader, error.Message);

            modal.ShowDialog();

            if (error.IsCritical)
            {
                SwitchControl(_criticalErrorControl);
            }
        }

        private void InitControls()
        {
            InitAuthorizeControl();
            InitChatSelectControl();
            InitCriticalErrorControl();
        }

        private void InitAuthorizeControl()
        {
            _phoneNumberControl = new AuthorizationControl
            {
                Dock = DockStyle.Fill,
            };
            _phoneNumberControl.OnPhoneNumberSubmit += OnPhoneNumberSubmit;
            Controls.Add(_phoneNumberControl);
            _phoneNumberControl.Hide();
        }

        private void InitChatSelectControl()
        {
            _chatSelectControl = new ChatSelectControl
            {
                Dock = DockStyle.Fill,
            };
            _chatSelectControl.OnChatSubmit += OnChatSubmit;
            Controls.Add(_chatSelectControl);
            _chatSelectControl.Hide();
        }

        private void InitCriticalErrorControl()
        {
            _criticalErrorControl = new CriticalErrorControl
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_criticalErrorControl);
            _criticalErrorControl.Hide();
        }

        private void SwitchControl(Control control)
        {
            if (control.Name.Equals(Loading.Name))
            {
                Logout_layout.Hide();
            }
            else
            {
                Logout_layout.Show();
            }
            activeControl?.Hide();
            activeControl = control;
            activeControl.Show();
        }

        private void Logout_buttonClick(object sender, EventArgs e)
        {
            _telegramSumProcessor.Logout();
            _localStorage.Set(null);
            SwitchControl(_phoneNumberControl);
        }
    }
}
