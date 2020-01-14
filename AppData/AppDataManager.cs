using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.AppData
{
    static class AppDataManager
    {
        public static void SaveLocations(string path, ObservableCollection<Location> locations)
        {
            using (var fs = File.Create(path))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, locations);
            }
        }
        public static ObservableCollection<Location> LoadLocations(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                var bf = new BinaryFormatter();
                return (ObservableCollection<Location>)bf.Deserialize(fs);
            }
        }
    }
}
