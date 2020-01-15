using GongSolutions.Wpf.DragDrop;
using PhotoAlbum.Helpers;
using PhotoAlbum.Models;
using PhotoAlbum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoAlbum.DropHandlers
{
    class ImageDropHandler : IDropTarget
    {
        AppViewModel viewModel;

        public ImageDropHandler(AppViewModel vm)
        {
            viewModel = vm;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataObject obj)
            {
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataObject obj)
            {
                var files = obj.GetFileDropList();
                foreach (var file in files)
                {
                    var resFile = Helper.CopyToImageDir(file);
                    viewModel.CurrentLocation.Photos.Add(new Photo { Path = resFile });
                }

                viewModel.SelectLastPhoto();
            }
        }
    }
}
