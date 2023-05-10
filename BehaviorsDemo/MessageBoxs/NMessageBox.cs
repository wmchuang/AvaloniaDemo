using Avalonia.Controls;
using System;
using System.Threading.Tasks;
using YlBaseUI.MessageBox.Base;
using YlBaseUI.MessageBoxs;
using YlBaseUI.MessageBoxs.Enums;

namespace YlBaseUI
{
    public static class NMessageBox
    {
        public static Task<ButtonResult> ShowDialog(Window owner, string title, string message)
        {
            var @params = new NMessageBoxParams
            {
                Title = title,
                Message = message
            };
            return ShowDialog(owner, @params);
        }

        public static Task<ButtonResult> ShowDialog(Window owner, string message,Action okAction=null)
        {
            var @params = new NMessageBoxParams
            {
                Message = message,
                OkAction = okAction
            };
            return ShowDialog(owner, @params);
        }

        public static Task<ButtonResult> ShowDialog(Window owner, NMessageBoxParams @params)
        {
            var mbox = new MessageBoxView(@params);
            var view = new MsBoxWindowBase<MessageBoxView, ButtonResult>(mbox);
            
            return view.ShowDialog(owner);
        }
    }
}