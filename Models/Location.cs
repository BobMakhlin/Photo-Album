using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    class Location : INotifyPropertyChanged
    {
        #region Private Definitions
        private string name = "Unknown";
        private DateTime date;
        #endregion

        public string Name 
        { 
            get => name; 
            set
            {
                name = value;
                INotifyPropertyChanged();
            }
        }
        public DateTime Date 
        { 
            get => date;
            set
            {
                date = value;
                INotifyPropertyChanged();
            }
        }
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void INotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
