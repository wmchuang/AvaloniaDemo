using System;
using System.Collections.Generic;
using System.Text;

namespace YlBaseUI.MessageBoxs
{
    public class NMessageBoxParams
    {
        public string Title { get; set; } = "温馨提示";

        public string Message { get; set; } = string.Empty;

        public string OkBtnContent { get; set; } = "确定";

        public string CancelBtnContent { get; set; } = "取消";

        public Action OkAction { get; set; }
        public Action CancelAction { get; set; }
    }
}