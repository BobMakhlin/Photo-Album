using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Helpers
{
    static class FileFormat
    {
        public static bool IsImage(string file)
        {
            try
            {
                using (var img = new Bitmap(file)) { }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
