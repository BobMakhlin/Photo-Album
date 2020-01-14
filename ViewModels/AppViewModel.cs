using GalaSoft.MvvmLight.Command;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoAlbum.ViewModels
{
    class AppViewModel : INotifyPropertyChanged
    {
        #region Private Definitions
        private Photo currentPhoto;
        private Location currentLocation;
        #endregion
        
        public ObservableCollection<Location> Locations { get; set; }

        public Photo CurrentPhoto
        {
            get => currentPhoto;
            set
            {
                currentPhoto = value;
                INotifyPropertyChanged();
            }
        }
        public Location CurrentLocation
        {
            get => currentLocation;
            set
            {
                currentLocation = value;
                INotifyPropertyChanged();
            }
        }

        public ICommand CommandChangeLocation { get; set; }
        public ICommand CommandNextPhoto { get; set; }
        public ICommand CommandPrevPhoto { get; set; }

        void InitCommands()
        {
            CommandChangeLocation = new RelayCommand(ChangeLocation);
            CommandNextPhoto = new RelayCommand(SelectNextPhoto);
            CommandPrevPhoto = new RelayCommand(SelectPrevPhoto);
        }

        public AppViewModel()
        {
            InitCommands();

            Locations = PhotoStorage.GetLocations();

            CurrentLocation = Locations[0];
            CurrentPhoto = CurrentLocation.Photos[0];
        }

        void ChangeLocation()
        {
            CurrentPhoto = CurrentLocation.Photos[0];
        }

        private void SelectPrevPhoto()
        {
            int pos = CurrentLocation.Photos.IndexOf(CurrentPhoto);

            if (pos != -1)
            {
                if (pos > 0)
                {
                    CurrentPhoto = CurrentLocation.Photos[pos - 1];
                }
                else
                {
                    CurrentPhoto = CurrentLocation.Photos[CurrentLocation.Photos.Count - 1];
                }
            }
        }

        private void SelectNextPhoto()
        {
            int pos = CurrentLocation.Photos.IndexOf(CurrentPhoto);

            if (pos != -1)
            {
                if (pos < CurrentLocation.Photos.Count - 1)
                {
                    CurrentPhoto = CurrentLocation.Photos[pos + 1];
                }
                else
                {
                    CurrentPhoto = CurrentLocation.Photos[0];
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void INotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
