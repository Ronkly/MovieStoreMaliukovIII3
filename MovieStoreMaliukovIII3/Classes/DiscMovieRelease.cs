using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMaliukovIII3.Classes
{
    internal class DiscMovieRelease : PhysicalMovieRelease
    {
        public List<string> possibleFormats = new List<string> { "dvd", "laserdisk", "cd", "blu-ray" };
        // Assuming disc movies have a specific format like DVD or Blu-ray
        public DiscMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string format, int copiesAvailable, double discount)
            : base(title, director, studio, price, releaseYear, imdbRating, format, copiesAvailable, discount)
        {
            // I gotta add something new here to make it different from PhysicalMovieRelease
        }
        public override string Format
        {
            get => _format;
            set
            {
                if (!string.IsNullOrEmpty(value) && (possibleFormats.Contains(value.ToLower())))
                    _format = value;
                else
                {
                    _format = "Unknown disc format";
                    Console.WriteLine("Format must be either DVD or Blu-ray!");
                }
            }
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"Disk Type: {_format}");
        }
    }
}
