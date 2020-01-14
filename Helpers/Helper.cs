using PhotoAlbum.AppData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Helpers
{
    static class Helper
    {
        public static string CopyToImageDir(string file)
        {
            var filename = Path.GetFileNameWithoutExtension(file);
            var extension = Path.GetExtension(file);
            var resultFile = $"{AppFiles.CustomImages}\\{filename}-{Guid.NewGuid()}{extension}";
            File.Copy(file, resultFile);

            return resultFile;
        }
    }
}
