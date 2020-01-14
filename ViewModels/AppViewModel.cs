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

        public AppViewModel()
        {
            InitCommands();

            Locations = PhotoStorage.GetLocations();

            CurrentLocation = Locations[0];
            CurrentPhoto = CurrentLocation.Photos[0];
        }

        public ICommand CommandChangeLocation { get; set; }

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

        void ChangeLocation()
        {
            CurrentPhoto = CurrentLocation.Photos[0];
        }

        void InitCommands()
        {
            CommandChangeLocation = new RelayCommand(ChangeLocation);
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
