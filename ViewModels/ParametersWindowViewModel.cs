using GalaSoft.MvvmLight.Command;
using PhotoAlbum.Models;
using PhotoAlbum.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace PhotoAlbum.ViewModels
{
    class ParametersWindowViewModel
    {
        public ParametersWindowViewModel()
        {
            InitCommands();
            SelectedCulture = App.Language;
        }

        public CultureInfo SelectedCulture { get; set; }
        public ICommand CommandChangeLanguage { get; private set; }

        void InitCommands()
        {
            CommandChangeLanguage = new RelayCommand<IClosable>(ChangeLanguage);
        }

        private void ChangeLanguage(IClosable window)
        {
            App.Language = SelectedCulture;
            window.Close();
        }
    }
}
