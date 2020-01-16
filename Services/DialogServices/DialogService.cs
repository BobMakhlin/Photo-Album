using Microsoft.Win32;
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
        #region Private Definition
        OpenFileDialog openFileDialog = new OpenFileDialog();
        #endregion

        public string File { get; set; }

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

        public bool OpenFileDialog()
        {
            if (openFileDialog.ShowDialog() == true)
            {
                File = openFileDialog.FileName;
                return true;
            }
            return false;
        }
    }
}
