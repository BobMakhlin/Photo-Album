using PhotoAlbum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Services.WindowService
{
    class ParametersWindowService : IWindowService
    {
        public void ShowDialog()
        {
            var window = new ParametersWindow();
            window.ShowDialog();
        }
    }
}
