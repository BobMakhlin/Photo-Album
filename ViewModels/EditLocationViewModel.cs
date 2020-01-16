using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.ViewModels
{
    class EditLocationViewModel
    {
        public EditLocationViewModel(Location location)
        {
            Location = location;
        }

        public Location Location { get; set; }
    }
}
