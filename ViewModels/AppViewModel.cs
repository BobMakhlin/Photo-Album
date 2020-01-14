using GalaSoft.MvvmLight.Command;
using PhotoAlbum.Models;
using PhotoAlbum.Services.DialogServices;
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

        IDialogService dialogService;

        public ICommand CommandChangeLocation { get; set; }
        public ICommand CommandNextPhoto { get; set; }
        public ICommand CommandPrevPhoto { get; set; }
        public ICommand CommandAddLocation { get; set; }
        public ICommand CommandRemoveLocation { get; set; }

        void InitCommands()
        {
            CommandChangeLocation = new RelayCommand(ChangeLocation);
            CommandNextPhoto = new RelayCommand(SelectNextPhoto);
            CommandPrevPhoto = new RelayCommand(SelectPrevPhoto);
            CommandAddLocation = new RelayCommand(AddLocation);
            CommandRemoveLocation = new RelayCommand(RemoveLocation, RemoveLocationCanExecute);
        }

        private bool RemoveLocationCanExecute()
        {
            return Locations.Count > 0;
        }

        private void RemoveLocation()
        {
            var res = dialogService.MessageBoxYesNo("Are you sure you want to delete the selected location?", "Photo album");
            if (res == DialogResult.Yes)
            {
                Locations.Remove(CurrentLocation);

                if (Locations.Count > 0)
                {
                    CurrentLocation = Locations[Locations.Count - 1];
                }
            }
        }

        private void AddLocation()
        {
            Locations.Add(new Location());
        }

        public AppViewModel(IDialogService dialogService)
        {
            InitCommands();

            this.dialogService = dialogService;

            Locations = PhotoStorage.GetLocations();

            CurrentLocation = Locations[0];
            CurrentPhoto = CurrentLocation.Photos[0];
        }

        void ChangeLocation()
        {
            if (CurrentLocation?.Photos?.Count > 0)
            {
                CurrentPhoto = CurrentLocation.Photos[0];
            }
            else
            {
                CurrentPhoto.Path = "";
            }
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
