using PhotoAlbum.Services.DialogServices;
using PhotoAlbum.Services.WindowService;
using PhotoAlbum.Services.WindowService.LocationWindowService;
using PhotoAlbum.ViewModels;
using PhotoAlbum.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoAlbum
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel(new DialogService(), new LocationWindowService(), new ParametersWindowService());
        }
    }
}
