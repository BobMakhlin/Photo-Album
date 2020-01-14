using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Services.DialogServices
{
    interface IDialogService
    {
        DialogResult MessageBoxYesNo(string msg, string caption);
    }
}
