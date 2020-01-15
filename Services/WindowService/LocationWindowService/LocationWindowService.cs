using PhotoAlbum.Models;
using PhotoAlbum.ViewModels;
using PhotoAlbum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Services.WindowService.LocationWindowService
{
    class LocationWindowService : ILocationWindowService
    {
        public Location Location { get; set; }

        public void ShowDialog()
        {
            var window = new EditLocationWindow()
            {
                DataContext = new EditLocationViewModel(Location)
            };
            window.ShowDialog();
        }
    }
}
