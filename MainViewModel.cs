using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibVLCSharp.Shared;
using LibVLCSharp.WPF;
using System;

namespace Stream1
{
    public enum PlayerState
    {
        Init,
        Play,
        Stop,
        Pause
    }
    public class MainViewModel : ViewModelBase
    {
        private LibVLC libVLC;
        public MediaPlayer mediaPlayer;
        private Uri uri;
        private PlayerState mediaState;
        private string uriSource;
        private bool showOnWpfWindow;

        public MainViewModel()
        {
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);

            mediaState = PlayerState.Init;
            UriSource = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
            uri = new Uri(UriSource);
            ShowOnWpfWindow = false;

            PlayCommand = new RelayCommand(Play);
            StopCommand = new RelayCommand(Stop);
            PauseCommand = new RelayCommand(Pause);
        }
        public bool ShowOnWpfWindow
        {
            get => showOnWpfWindow;
            set
            {
                showOnWpfWindow = value;
                RaisePropertyChanged();
            }
        }
        private void Pause()
        {
            mediaPlayer.Pause();
            mediaState = PlayerState.Pause;
        }

        private void Stop()
        {
            mediaPlayer.Stop();
            mediaState = PlayerState.Stop;
        }

        private void Play()
        {
            if (mediaState == PlayerState.Init)
            {
                mediaPlayer.Play(new Media(libVLC, uri));
                mediaState = PlayerState.Play;
            }
            else
            {
                mediaPlayer.Play();
            }
        }
        public string UriSource
        {
            get => uriSource;
            set
            {
                uriSource = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        public RelayCommand PauseCommand { get; set; }
        public VideoView MediaWindow { get; set; }
    }
}
