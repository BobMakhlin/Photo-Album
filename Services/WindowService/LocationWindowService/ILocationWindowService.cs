using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Services.WindowService.LocationWindowService
{
    interface ILocationWindowService : IWindowService
    {
        Location Location { get; set; }
    }
}
