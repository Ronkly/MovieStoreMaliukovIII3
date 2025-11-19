using System;

namespace MovieStoreMaliukovIII3.Classes
{
    internal abstract class MovieRelease
    {
        protected string _title;
        protected string _director;
        protected string _studio;
        protected double _price;
        protected int _purchasedCopies;
        protected double _imdbRating;
        protected int _releaseYear;

        public MovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating)
        {
            Title = title;
            Director = director;
            Studio = studio;
            Price = price;
            PurchasedCopies = 0;
            ReleaseYear = releaseYear;
            IMDbRating = imdbRating;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
                else
                {
                    _title = "Unknown title";
                    Console.WriteLine("Title cannot be empty!");
                }
            }
        }

        public string Director
        {
            get => _director;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _director = value;
                }
                else
                {
                    _director = "Unknown director";
                    Console.WriteLine("Director cannot be empty!");
                }
            }
        }

        public string Studio
        {
            get => _studio;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _studio = value;
                }
                else
                {
                    _studio = "Unknown studio";
                    Console.WriteLine("Studio cannot be empty!");
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else
                {
                    _price = 0;
                    Console.WriteLine("The movie is free!");
                }
            }
        }

        public double IMDbRating
        {
            get => _imdbRating;
            set
            {
                if (value >= 0 && value <= 10)
                {
                    _imdbRating = value;
                }
                else
                {
                    _imdbRating = 0;
                    Console.WriteLine("Invalid IMDb rating! It must be between 0 and 10.");
                }
            }
        }

        public int ReleaseYear
        {
            get => _releaseYear;
            set
            {
                if (value >= 1888 && value <= DateTime.Now.Year)
                {
                    _releaseYear = value;
                }
                else
                {
                    _releaseYear = DateTime.Now.Year;
                    Console.WriteLine("Invalid release year!");
                }
            }
        }

        public int PurchasedCopies
        {
            get => _purchasedCopies;
            set 
            {
                if (value >= 0)
                {
                    _purchasedCopies = value;
                }
                else
                {
                    _purchasedCopies = 0;
                    Console.WriteLine("There are no purchased copies.");
                }
            }
        }

        public virtual void DisplayData()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Studio: {Studio}");
            Console.WriteLine($"Price: {Price} dinars");
            Console.WriteLine($"Number of purchased copies: {PurchasedCopies} copies");
            Console.WriteLine($"IMDb Rating: {IMDbRating}");
            Console.WriteLine($"Release year: {ReleaseYear}");
            Console.WriteLine(new string('-', 5));
        }

        public virtual double GetIncome()
        {
            return Price * PurchasedCopies;
        }

        public virtual void SellCopy()
        {
            PurchasedCopies++;
            Console.WriteLine($"A copy of the movie release '{Title}' is sold.");
        }
    }
}
