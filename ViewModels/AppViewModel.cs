using DebugConsole.DebugInstruments;
using GalaSoft.MvvmLight.Command;
using GongSolutions.Wpf.DragDrop;
using PhotoAlbum.AppData;
using PhotoAlbum.DropHandlers;
using PhotoAlbum.Helpers;
using PhotoAlbum.Models;
using PhotoAlbum.Services.DialogServices;
using PhotoAlbum.Services.WindowService;
using PhotoAlbum.Services.WindowService.LocationWindowService;
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
        IDialogService dialogService;
        ILocationWindowService editLocationWindow;
        IWindowService paramsWindowService;
        #endregion

        public AppViewModel(IDialogService dialogService, ILocationWindowService locationWindow, IWindowService paramsWndService)
        {
            InitCommands();
            this.dialogService = dialogService;
            editLocationWindow = locationWindow;
            paramsWindowService = paramsWndService;
            ImageDropHandler = new ImageDropHandler(this);

            LocationChanged += OnLocationChanged;

            try
            {
                Locations = AppDataManager.LoadLocations(AppFiles.ImagesPath);
            }
            catch (Exception)
            {
                Locations = LocationsStorage.GetLocations();
            }

            if (Locations.Count > 0)
            {
                CurrentLocation = Locations[0];
            }
        }

        event EventHandler LocationChanged;

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
                LocationChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public IDropTarget ImageDropHandler { get; private set; }
        public ICommand CommandChangeLocation { get; private set; }
        public ICommand CommandNextPhoto { get; private set; }
        public ICommand CommandPrevPhoto { get; private set; }
        public ICommand CommandAddLocation { get; private set; }
        public ICommand CommandRemoveLocation { get; private set; }
        public ICommand CommandProgramClosing { get; private set; }
        public ICommand CommandEditLocation { get; private set; }
        public ICommand CommandAddPhoto { get; private set; }
        public ICommand CommandRemovePhoto { get; private set; }
        public ICommand CommandOpenSettingsWindow { get; private set; }

        void InitCommands()
        {
            CommandNextPhoto = new RelayCommand(SelectNextPhoto);
            CommandPrevPhoto = new RelayCommand(SelectPrevPhoto);
            CommandAddLocation = new RelayCommand(AddLocation);
            CommandRemoveLocation = new RelayCommand(RemoveLocation, RemoveLocationCanExecute);
            CommandProgramClosing = new RelayCommand(OnProgramClosing);
            CommandEditLocation = new RelayCommand<Location>(EditLocation);
            CommandAddPhoto = new RelayCommand(LoadPhoto);
            CommandRemovePhoto = new RelayCommand(RemoveSelectedPhoto, RemoveSelectedPhotoCanExecute);
            CommandOpenSettingsWindow = new RelayCommand(OpenSettingsWindow);
        }

        private void OnProgramClosing()
        {
            AppDataManager.SaveLocations(AppFiles.ImagesPath, Locations);
        }

        private void OnLocationChanged(object sender, EventArgs e)
        {
            if (CurrentLocation == null)
                return;

            if (CurrentLocation.Photos.Count > 0)
            {
                CurrentPhoto = CurrentLocation.Photos[0];
            }
            else
            {
                CurrentPhoto = new Photo();
            }
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
                SelectLastLocation();
            }
        }

        private void AddLocation()
        {
            Locations.Add(new Location());
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

        public void SelectLastPhoto()
        {
            if (CurrentLocation.Photos.Count > 0)
            {
                CurrentPhoto = CurrentLocation.Photos[CurrentLocation.Photos.Count - 1];
            }
            else
            {
                CurrentPhoto = new Photo();
            }
        }

        void SelectLastLocation()
        {
            if (Locations.Count > 0)
            {
                CurrentLocation = Locations[Locations.Count - 1];
            }
        }

        private void EditLocation(Location location)
        {
            editLocationWindow.Location = location;
            editLocationWindow.ShowDialog();
        }

        private void LoadPhoto()
        {
            if (dialogService.OpenFileDialog() == true)
            {
                if (!FileFormat.IsImage(dialogService.File))
                    return;

                var filename = Helper.CopyToImageDir(dialogService.File);
                CurrentLocation.Photos.Add(new Photo { Path = filename });

                SelectLastPhoto();
            }
        }

        private void RemoveSelectedPhoto()
        {
            var res = dialogService.MessageBoxYesNo("Are you sure you want to delete this photo?", "Photo album");
            if (res == DialogResult.Yes)
            {
                CurrentLocation.Photos.Remove(CurrentPhoto);
                SelectLastPhoto();
            }
        }

        private bool RemoveSelectedPhotoCanExecute()
        {
            return CurrentLocation.Photos.Count > 0;
        }

        private void OpenSettingsWindow()
        {
            paramsWindowService.ShowDialog();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void INotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
