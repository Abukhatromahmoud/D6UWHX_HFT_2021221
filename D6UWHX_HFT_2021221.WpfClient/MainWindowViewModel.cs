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

namespace D6UWHX_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }



        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Artist> Artists { get; set; }
        public RestCollection<Track> Tracks { get; set; }

        private Album selectedAlbum;
        private Artist selectedArtist;
        private Track selectedTrack;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        Title = value.Title,
                        AlbumID = value.AlbumID
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        Name = value.Name,
                        ArtistId = value.ArtistId
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Track SelectedTrack
        {
            get { return selectedTrack; }
            set
            {
                if (value != null)
                {
                    selectedTrack = new Track()
                    {
                        NamePlace = value.NamePlace,
                        TrackId = value.TrackId
                    };
                    OnPropertyChanged();
                    (DeleteTrackCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public List<Track> GetTracks()
        {
            return Tracks.ToList();
        }

        public List<Album> GetAlbums()
        {
            return Albums.ToList();
        }

        public List<Artist> GetArtists()
        {
            return Artists.ToList();
        }

        public ICommand CreateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand UpdateAlbumCommand { get; set; }


        public ICommand CreateArtistCommand { get; set; }

        public ICommand DeleteArtistCommand { get; set; }

        public ICommand UpdateArtistCommand { get; set; }

        public ICommand CreateTrackCommand { get; set; }

        public ICommand DeleteTrackCommand { get; set; }

        public ICommand UpdateTrackCommand { get; set; }

        

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:39135/", "album", "hub");
                Artists = new RestCollection<Artist>("http://localhost:39135/", "artist", "hub");
                Tracks = new RestCollection<Track>("http://localhost:39135/", "track", "hub");

                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        Title = SelectedAlbum.Title
                    });
                });
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        Name = SelectedArtist.Name
                    });
                });
                CreateTrackCommand = new RelayCommand(() =>
                {
                    Tracks.Add(new Track()
                    {
                        NamePlace = SelectedTrack.NamePlace
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

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Artists.Update(SelectedArtist);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });
                UpdateTrackCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Tracks.Update(SelectedTrack);
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



                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistId);
                },
              () =>
              {
                  return SelectedArtist != null;
              });
                SelectedArtist = new Artist();


                DeleteTrackCommand = new RelayCommand(() =>
                {
                    Tracks.Delete(SelectedTrack.TrackId);
                },
              () =>
              {
                  return SelectedTrack != null;
              });
                SelectedTrack = new Track();
            }

        }
    }
}

