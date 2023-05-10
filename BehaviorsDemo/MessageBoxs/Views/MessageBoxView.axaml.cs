using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using YlBaseUI.MessageBox.Base;
using YlBaseUI.MessageBoxs;
using YlBaseUI.MessageBoxs.Enums;
using YlBaseUI.MessageBoxs.Views;

namespace YlBaseUI
{
    public partial class MessageBoxView : BaseView, IWindowGetResult<ButtonResult>
    {
        public MessageBoxView()
        {
            InitializeComponent();
            this.btnOk.Click += BtnOk_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        public Action OkAction { get; set; }
        public Action CancelAction { get; set; }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonResult.Cancel);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(ButtonResult.Yes);
        }

        public MessageBoxView(NMessageBoxParams @params) : this()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.FindControl<TextBlock>("Title").Text = @params.Title;
            this.FindControl<TextBlock>("Message").Text = @params.Message;

            this.FindControl<Button>("btnCancel").Content = @params.CancelBtnContent;
            this.FindControl<Button>("btnOk").Content = @params.OkBtnContent;
            OkAction = @params.OkAction;
            CancelAction = @params.CancelAction;
        }

        public ButtonResult ButtonResult { get; set; } = ButtonResult.None;

        public ButtonResult GetResult() => ButtonResult;

        public async void ButtonClick(ButtonResult buttonResult)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                this.ButtonResult = buttonResult;
                this.CloseSafe();
                if (buttonResult == ButtonResult.Yes && OkAction != null)
                {
                    Task.Run(OkAction);
                }
                else if (buttonResult == ButtonResult.Cancel && CancelAction != null)
                {
                    Task.Run(CancelAction);
                }
            });
        }
    }
}