using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoAlbum.Services.DialogServices
{
    class DialogService : IDialogService
    {
        public DialogResult MessageBoxYesNo(string msg, string caption)
        {
            var res = MessageBox.Show(msg, caption, MessageBoxButton.YesNo);

            switch(res)
            {
                case MessageBoxResult.Yes:
                    return DialogResult.Yes;
                default:
                    return DialogResult.No;
            }
        }
    }
}
