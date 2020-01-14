using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    [Serializable]
    class Photo : INotifyPropertyChanged
    {
        #region Private Definitions
        private string path;
        #endregion

        public string Path 
        { 
            get => $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\{path}";
            set
            {
                path = value;
                INotifyPropertyChanged();
            }
        }

        #region INotifyPropertyChanged
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        void INotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
