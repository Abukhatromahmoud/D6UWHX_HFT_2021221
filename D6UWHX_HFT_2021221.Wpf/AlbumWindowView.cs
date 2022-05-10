using D6UWHX_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace D6UWHX_HFT_2021221.Wpf
{
    public class AlbumWindowView : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }   

        public RestCollection<Album> Albums { get; set; }
        private Album selectedAlbums;

        public Album SelectedAlbum
        {
            get { return selectedAlbums; }
            set
            {
                if (value != null)
                {
                    selectedAlbums = new Album()
                    {
                        Title = value.Title,
                        AlbumID = value.AlbumID,
                        BasePrice = value.BasePrice,
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumWindowView()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:39135/", "hub");
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        Title = SelectedAlbum.Title,
                        BasePrice = SelectedAlbum.BasePrice
                    });
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Albums.Update(SelectedAlbum);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.AlbumID);
                },
                () =>
                {
                    return SelectedAlbum != null;
                });
                SelectedAlbum = new Album();
            }
        }
    }
}
