using PhotoAlbum.AppData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    static class LocationsStorage
    {
        public static ObservableCollection<Location> GetLocations()
        {
            return new ObservableCollection<Location>()
            {
                new Location()
                {
                    Name = "California",
                    Date = new DateTime(2019, 08, 20),
                    Photos = new ObservableCollection<Photo>()
                    {
                        new Photo() { Path=$"{AppFiles.StandartImagesPath}\\california1.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImagesPath}\\california2.jpg" },
                    }
                },
                new Location()
                {
                    Name = "New York",
                    Date = new DateTime(2018, 09, 01),
                    Photos = new ObservableCollection<Photo>()
                    {
                        new Photo() { Path=$"{AppFiles.StandartImagesPath}\\ny1.jpg" },
                    }
                },
                new Location()
                {
                    Name = "Mayami",
                    Date = new DateTime(2020, 01, 05),
                    Photos = new ObservableCollection<Photo>()
                    {
                        new Photo() { Path=$"{AppFiles.StandartImagesPath}\\mayami1.jpg" },
                        new Photo() { Path=$"{AppFiles.StandartImagesPath}\\mayami2.jfif" },
                    }
                }
            };
        }
    }
}
