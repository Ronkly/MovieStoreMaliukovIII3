using System;

namespace MovieStoreMaliukovIII3.Classes
{
    internal class AnalogMovieRelease : PhysicalMovieRelease
    {
        protected bool _goodCondition;

        public AnalogMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string format, int copiesAvailable, double discount, bool goodCondition)
            : base(title, director, studio, price, releaseYear, imdbRating, format, copiesAvailable, discount)
        {
            GoodCondition = goodCondition;
        }
        public override string Format
        {
            get => _format;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _format = value;
                else
                {
                    _format = "Unknown analog format";
                    Console.WriteLine("Format cannot be empty!");
                }
            }
        }

        public bool GoodCondition
        {
            get => _goodCondition;
            set => _goodCondition = value;
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"Format: {Format}");
            Console.WriteLine($"Good Condition: {(GoodCondition ? "Yes" : "No")}");
        }
    }
}
