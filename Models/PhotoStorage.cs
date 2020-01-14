using PhotoAlbum.AppData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    static class PhotoStorage
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
                        new Photo() { Path=$"{AppFiles.StandartImages}\\california1.jpg" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\california2.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\california3.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\california4.jfif" }
                    }
                },
                new Location()
                {
                    Name = "New York",
                    Date = new DateTime(2018, 09, 01),
                    Photos = new ObservableCollection<Photo>()
                    {
                        new Photo() { Path=$"{AppFiles.StandartImages}\\ny1.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\ny2.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\ny3.jfif" },
                    }
                },
                new Location()
                {
                    Name = "Mayami",
                    Date = new DateTime(2020, 01, 05),
                    Photos = new ObservableCollection<Photo>()
                    {
                        new Photo() { Path=$"{AppFiles.StandartImages}\\mayami1.jpg" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\mayami2.jfif" },
                        new Photo() { Path=$"{AppFiles.StandartImages}\\mayami3.jpg" },
                    }
                }
            };
        }
    }
}
