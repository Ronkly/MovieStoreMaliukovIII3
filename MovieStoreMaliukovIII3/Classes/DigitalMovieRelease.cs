using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMaliukovIII3.Classes
{
    internal class DigitalMovieRelease : MovieRelease
    {
        protected string _videoQuality;
        protected bool _dolbyAtmosSupport;
        protected bool _isOnStreaming;
        public DigitalMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string VideoQuality, bool DolbyAtmosSupport, bool IsOnStreaming)
            : base(title, director, studio, price, releaseYear, imdbRating)
        {
            this._videoQuality = VideoQuality;
            this._dolbyAtmosSupport = DolbyAtmosSupport;
            this._isOnStreaming = IsOnStreaming;
        }

        public string VideoQuality
        {
            get => _videoQuality;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _videoQuality = value;
                }
                else
                {
                    _videoQuality = "Unknown quality";
                    Console.WriteLine("Video quality cannot be empty!");
                }
            }
        }

        public bool DolbyAtmosSupport
        {
            get => _dolbyAtmosSupport;
            set => _dolbyAtmosSupport = value;
        }

        public bool IsOnStreaming
        {
            get => _isOnStreaming;
            set => _isOnStreaming = value;
        }

        public override void SellCopy()
        {
            base.SellCopy();
            Console.WriteLine("The movie is available in your library now.");
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"VideoQuality: {_videoQuality}");
            Console.WriteLine($"Dolby Atmos Support: {(_dolbyAtmosSupport ? "Yes" : "No")}");
            Console.WriteLine($"Is On Streaming: {(_isOnStreaming ? "Yes" : "No")}");
        }
        public bool Is4K()
        {
            return _videoQuality != null && _videoQuality.ToUpper().Contains("4K");
        }
    }
}
