using System;
using System.Collections.Generic;

namespace MovieStoreMaliukovIII3
{
    internal abstract class MovieRelease
    {
        protected string Title { get; set; }
        protected string Director { get; set; }
        protected string Studio { get; set; }
        protected double Price { get; set; }
        protected int PurchasedCopies { get; set; }
        protected double IMDbRating { get; set; }
        protected int ReleaseYear { get; set; }

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

        public string GetTitle()
        {
            return Title;
        }
        public void SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Title = title;
            }
            else
            {
                Title = "Unknown title";
                Console.WriteLine("Title cannot be empty!");
            }
        }
        public string GetDirector()
        {
            return Director;
        }
        public void SetDirector(string director)
        {
            if (!string.IsNullOrEmpty(director))
            {
                Director = director;
            }
            else
            {
                Director = "Unknown director";
                Console.WriteLine("Director cannot be empty!");
            }
        }
        public string GetStudio()
        {
            return Studio;
        }
        public void SetStudio(string studio)
        {
            if (!string.IsNullOrEmpty(studio))
            {
                Studio = studio;
            }
            else
            {
                Studio = "Unknown studio";
                Console.WriteLine("Studio cannot be empty!");
            }
        }
        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double price)
        {
            if (price > 0)
            {
                Price = price;
            }
            else
            {
                Price = 0;
                Console.WriteLine("The movie is free!");
            }
        }

        public double GetIMDbRating()
        {
            return IMDbRating;
        }
        public void SetIMDbRating(double rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                IMDbRating = rating;
            }
            else
            {
                IMDbRating = 0;
                Console.WriteLine("Invalid IMDb rating! It must be between 0 and 10.");
            }
        }
        public int GetReleaseYear()
        {
            return ReleaseYear;
        }
        public void SetReleaseYear(int year)
        {
            if (year >= 1888 && year <= DateTime.Now.Year)
            {
                ReleaseYear = year;
            }
            else
            {
                ReleaseYear = DateTime.Now.Year;
                Console.WriteLine("Invalid release year!");
            }
        }
        public int GetPurchasedCopies()
        {
            return PurchasedCopies;
        }
        public void SetPurchasedCopies(int copies)
        {
            if (copies >= 0)
            {
                PurchasedCopies = copies;
            }
            else
            {
                PurchasedCopies = 0;
                Console.WriteLine("There are no purchased copies.");
            }
        }
        public virtual void DisplayData()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Price: " + Price + " dinars");
            Console.WriteLine("Number of purchased copies: " + PurchasedCopies + " copies");
            Console.WriteLine("Release year: " + ReleaseYear);
        }

        public virtual double GetIncome()
        {
            return Price * PurchasedCopies;
        }

        public virtual void SellCopy(List<MovieRelease> catalogue, int index)
        {
            PurchasedCopies++;
            Console.WriteLine("Movie release " + Title + " is sold. Your copy is the " + PurchasedCopies + (PurchasedCopies % 10 == 1 ? "st" : PurchasedCopies % 10 == 2 ? "nd" : PurchasedCopies % 10 == 3 ? "rd" : "th") + " sold copy.");
        }
    }
    internal class DigitalMovieRelease : MovieRelease
    {
        private string VideoQuality { get; set; }
        private bool DolbyAtmosSupport { get; set; }
        private bool IsOnStreaming { get; set; }

        public DigitalMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string VideoQuality, bool DolbyAtmosSupport, bool IsOnStreaming)
            : base(title, director, studio, price, releaseYear, imdbRating)
        {
            this.VideoQuality = VideoQuality;
            this.DolbyAtmosSupport = DolbyAtmosSupport;
            this.IsOnStreaming = IsOnStreaming;
        }

        public string GetVideoQuality()
        {
            return VideoQuality;
        }
        public void SetVideoQuality(string videoQuality)
        {
            if (!string.IsNullOrEmpty(videoQuality))
            {
                VideoQuality = videoQuality;
            }
            else
            {
                VideoQuality = "Unknown quality";
                Console.WriteLine("Video quality cannot be empty!");
            }
        }
        public bool GetDolbyAtmosSupport()
        {
            return DolbyAtmosSupport;
        }
        public void SetDolbyAtmosSupport(bool support)
        {
            DolbyAtmosSupport = support;
        }
        public bool GetIsOnStreaming()
        {
            return IsOnStreaming;
        }
        public void SetIsOnStreaming(bool isOnStreaming)
        {
            IsOnStreaming = isOnStreaming;
        }

        public override void SellCopy(List<MovieRelease> catalogue, int index)
        {
            base.SellCopy(catalogue, index);
            Console.WriteLine("The movie is available in your library now.");
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("VideoQuality: " + VideoQuality);
            Console.WriteLine("Dolby Atmos Support: " + (DolbyAtmosSupport ? "Yes" : "No"));
            Console.WriteLine("Is On Streaming: " + (IsOnStreaming ? "Yes" : "No"));
        }
    }
    internal class DiscMovieRelease : MovieRelease
    {
        private string DiskType { get; set; }
        private int CopiesAvailable { get; set; }
        private double Discount { get; set; }
        public DiscMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string Format, int CopiesAvailable, double Discount)
            : base(title, director, studio, price, releaseYear, imdbRating)
        {
            this.DiskType = Format;
            this.CopiesAvailable = CopiesAvailable;
            this.Discount = Discount;
        }

        public string GetFormat()
        {
            return DiskType;
        }

        public void SetFormat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                DiskType = format;
            }
            else
            {
                DiskType = "Unknown format";
                Console.WriteLine("Format cannot be empty!");
            }
        }
        public bool HasDiscount()
        {
            return Discount > 0;
        }
        public void SetCopiesAvailable(int copies)
        {
            if (copies >= 0)
            {
                CopiesAvailable = copies;
            }
            else
            {
                CopiesAvailable = 0;
                Console.WriteLine("No copies available!");
            }
        }

        public override void SellCopy(List<MovieRelease> catalogue, int index)
        {
            if (CopiesAvailable > 0)
            {
                base.SellCopy(catalogue, index);
                CopiesAvailable--;
                Console.WriteLine("Availability: " + CopiesAvailable + " copies");

                if (CopiesAvailable == 0)
                {
                    Console.WriteLine("MovieRelease: " + Title + " is sold out.");
                }
            }
            else
            {
                Console.WriteLine("Movie release: " + Title + " isn't available anymore.");
            }
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Copies available: " + CopiesAvailable + " copies");
            Console.WriteLine("Discount: " + Discount + "%");
        }
        public override double GetIncome()
        {
            return Price * (100 - Discount) * PurchasedCopies;
        }
    }
    internal class AnalogMovieRelease : MovieRelease
    {
        private string Format { get; set; }
        private int CopiesAvailable { get; set; }
        private double Discount { get; set; }
        private bool GoodCondition { get; set; }

        public AnalogMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string Format, int CopiesAvailable, double Discount, bool goodCondition)
            : base(title, director, studio, price, releaseYear, imdbRating)
        {
            this.Format = Format;
            this.CopiesAvailable = CopiesAvailable;
            this.Discount = Discount;
            GoodCondition = goodCondition;
        }
        public string GetFormat()
        {
            return Format;
        }
        public void SetFormat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                Format = format;
            }
            else
            {
                Format = "Unknown format";
                Console.WriteLine("Format cannot be empty!");
            }
        }
        public bool GetCondition()
        {
            return GoodCondition;
        }
        public void SetCondition(bool condition)
        {
            GoodCondition = condition;
        }
        public double GetDiscount()
        {
            return Discount;
        }
        public void SetDiscount(double discount)
        {
            if (discount >= 0 && discount <= 100)
            {
                Discount = discount;
            }
            else
            {
                Discount = 0;
                Console.WriteLine("Invalid discount! It must be between 0 and 100.");
            }
        }
        public bool HasDiscount()
        {
            return Discount > 0;
        }

        public override double GetIncome()
        {
            return Price * (100 - Discount) * PurchasedCopies;
        }

        public void SetCopiesAvailable(int copies)
        {
            if (copies >= 0)
            {
                CopiesAvailable = copies;
            }
            else
            {
                CopiesAvailable = 0;
                Console.WriteLine("No copies available!");
            }
        }

        public override void SellCopy(List<MovieRelease> catalogue, int index)
        {
            if (CopiesAvailable > 0)
            {
                PurchasedCopies++;
                CopiesAvailable--;
                Console.WriteLine("Movie release: " + Title + " is sold.");
                Console.WriteLine("Availability: " + CopiesAvailable + " copies");

                if (CopiesAvailable == 0)
                {
                    Console.WriteLine("MovieRelease: " + Title + " is sold out.");
                }
            }
            else
            {
                Console.WriteLine("Movie release: " + Title + " isn't avaialable anymore.");
            }
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Format: " + Format);
            Console.WriteLine("Copies available: " + CopiesAvailable + " kom");
            Console.WriteLine("Discount: " + Discount + "%");
        }
    }

    internal class Program
    {
        private static List<MovieRelease> catalogue = new List<MovieRelease>();
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Professor Audio!");
            while (true)
            {
                Console.WriteLine("\nChoose your option:");
                Console.WriteLine("=== View Information ===");
                Console.WriteLine("1. Display the data of all movie releases");
                Console.WriteLine("2. The most expensive movie release");
                Console.WriteLine("3. Display movies with a discount");
                Console.WriteLine("4. Total income");
                Console.WriteLine("\n=== Catalogue Management ===");
                Console.WriteLine("5. Add new movie");
                Console.WriteLine("6. Interact with a movie");
                Console.WriteLine("7. Delete movie");
                Console.WriteLine("\n=== Sales Operations ===");
                Console.WriteLine("8. Sell a movie copy");

                Console.WriteLine("\n0. Quit");

                Console.Write("\n> ");
                int izbor;
                while (!int.TryParse(Console.ReadLine(), out izbor))
                {
                    Console.WriteLine("Error! You must enter a number!\n> .");
                }
                switch (izbor)
                {
                    case 1: DisplayAllMovies(catalogue); break;
                    case 2: MostExpensiveMovieRelease(catalogue); break;
                    case 3: MoviesWithDiscount(catalogue); break;
                    case 4: TotalIncome(); break;
                    case 5: AddMovieToCollection(); break;
                    case 6: InteractWithMovie(); break;
                    case 7: DeleteMovieFromCollection(); break;
                    case 8: SellCopy(); break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Quitting..."); return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option."); break;
                }
            }
        }

        private static string CheckString(string prompt)
        {
            string input;
            Console.Write(prompt);
            while (String.IsNullOrEmpty(input = Console.ReadLine()))
            {
                input = Console.ReadLine();
                Console.Write("Input cannot be empty. Please try again: ");
            }
            return input;
        }
        #region Display Methods
        private static void DisplayAllMovies(List<MovieRelease> catalogue)
        {
            Console.Clear();
            if (catalogue.Count == 0)
            {
                Console.WriteLine("The catalogue is empty.");
                return;
            }
            Console.WriteLine("\n===Our catalogue===");
            for (int i = 0; i < catalogue.Count; i++)
            {
                if (catalogue[i] != null)
                {
                    catalogue[i].DisplayData();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }
        private static void MostExpensiveMovieRelease(List<MovieRelease> catalogue)
        {
            Console.Clear();
            if (catalogue.Count == 0)
            {
                Console.WriteLine("The catalogue is empty.");
                return;
            }
            double maxPrice = -1;
            MovieRelease najskuplja = null;

            foreach (MovieRelease i in catalogue)
            {
                if (i != null && i.GetPrice() > maxPrice)
                {
                    maxPrice = i.GetPrice();
                    najskuplja = i;
                }
            }
            if (najskuplja != null)
            {
                Console.WriteLine("===The most expensive movie release===");
                najskuplja.DisplayData();
            }
            else
            {
                Console.WriteLine("There are no movies in the catalogue.");
            }
        }
        private static void MoviesWithDiscount(List<MovieRelease> catalogue)
        {
            Console.Clear();
            if (catalogue.Count == 0)
            {
                Console.WriteLine("The catalogue is empty.");
                return;
            }
            Console.WriteLine("===Movies with a discount===");
            foreach (MovieRelease i in catalogue)
            {
                if (i is DiscMovieRelease fiz && fiz.HasDiscount())
                {
                    fiz.DisplayData();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }
        #endregion


        private static void AddMovieToCollection()
        {
            Console.Clear();
            Console.WriteLine("===Add new movie release===");
            Console.WriteLine("Choose movie type to add:");
            Console.WriteLine("1. Digital Movie");
            Console.WriteLine("2. Disc Movie");
            Console.WriteLine("3. Analog Movie");
            Console.Write("\n> ");
            int movieType;
            var allowedOptions = new List<int> { 1, 2, 3 };
            if (!int.TryParse(Console.ReadLine(), out movieType) || !allowedOptions.Contains(movieType))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            string title = CheckString("Enter title: ");
            string director = CheckString("Enter director: ");
            string studio = CheckString("Enter studio: ");
            double price;
            Console.Write("Enter price: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Invalid input. Please enter a valid price: ");
            }
            int releaseYear;
            Console.Write("Enter release year: ");
            while (!int.TryParse(Console.ReadLine(), out releaseYear) || releaseYear > DateTime.Now.Year || releaseYear < 1888)
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }
            double imdbRating;
            Console.Write("Enter IMDb rating (0-10): ");
            while (!double.TryParse(Console.ReadLine(), out imdbRating) || imdbRating < 0 || imdbRating > 10)
            {
                Console.Write("Invalid input. Please enter a valid IMDb rating (0-10): ");
            }
            switch (movieType)
            {
                case 1:
                    string videoQuality = CheckString("Enter video quality (e.g., 1080p, 4K): ");
                    Console.Write("Does it support Dolby Atmos? (yes/no): ");
                    bool dolbyAtmosSupport = Console.ReadLine().Trim().ToLower() == "yes";
                    Console.Write("Is it on streaming? (yes/no): ");
                    bool isOnStreaming = Console.ReadLine().Trim().ToLower() == "yes";
                    catalogue.Add(new DigitalMovieRelease(title, director, studio, price, releaseYear, imdbRating, videoQuality, dolbyAtmosSupport, isOnStreaming));
                    break;
                case 2:
                    string discType = CheckString("Enter format (DVD, Blu-ray, CD, LaserDisk...): ");
                    int copiesAvailableDisc;
                    Console.Write("Enter number of copies available: ");
                    while (!int.TryParse(Console.ReadLine(), out copiesAvailableDisc) || copiesAvailableDisc < 0)
                    {
                        Console.Write("Invalid input. Please enter a valid number of copies: ");
                    }
                    double discountDisc;
                    Console.Write("Enter discount percentage: ");
                    while (!double.TryParse(Console.ReadLine(), out discountDisc) || discountDisc < 0 || discountDisc > 100)
                    {
                        Console.Write("Invalid input. Please enter a valid discount percentage (0-100): ");
                    }
                    catalogue.Add(new DiscMovieRelease(title, director, studio, price, releaseYear, imdbRating, discType, copiesAvailableDisc, discountDisc));
                    break;
                case 3:
                    string formatAnalog = CheckString("Enter format (e.g., VHS, Blu-ray): ");
                    int copiesAvailableAnalog;
                    Console.Write("Enter number of copies available: ");
                    while (!int.TryParse(Console.ReadLine(), out copiesAvailableAnalog) || copiesAvailableAnalog < 0)
                    {
                        Console.Write("Invalid input. Please enter a valid number of copies: ");
                    }
                    double discountAnalog;
                    Console.Write("Enter discount percentage: ");
                    while (!double.TryParse(Console.ReadLine(), out discountAnalog) || discountAnalog < 0 || discountAnalog > 100)
                    {
                        Console.Write("Invalid input. Please enter a valid discount percentage (0-100): ");
                    }
                    bool goodCondition;
                    Console.Write("Is the analog movie in good condition? (yes/no): ");
                    goodCondition = Console.ReadLine().Trim().ToLower() == "yes";
                    catalogue.Add(new AnalogMovieRelease(title, director, studio, price, releaseYear, imdbRating, formatAnalog, copiesAvailableAnalog, discountAnalog, goodCondition));
                    break;
            }
            Console.Clear();
            Console.WriteLine("Movie release added successfully.");
        }

        private static void InteractWithMovie()
        {
            while (true)
            {
                Console.Clear();
                if (catalogue.Count == 0)
                {
                    Console.WriteLine("The catalogue is empty. No movies to interact with.");
                    return;
                }
                Console.Write("Enter the movie index to interact with: ");
                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    Console.WriteLine("Error! You must enter a number!");
                    return;
                }
                if (index < 0 || index >= catalogue.Count)
                {
                    Console.WriteLine("Not existing index.");
                    return;
                }
                string movieType;
                if (catalogue[index] is DiscMovieRelease discMovie)
                {
                    Console.WriteLine("Interacting with disc movie release: " + discMovie.GetTitle());
                    movieType = "disc";
                }
                else if (catalogue[index] is AnalogMovieRelease analogMovie)
                {
                    Console.WriteLine("Interacting with analog movie release: " + analogMovie.GetTitle());
                    movieType = "analog";
                }
                else
                {
                    Console.WriteLine("Interacting with digital movie release: " + catalogue[index].GetTitle());
                    movieType = "digital";
                }
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Display movie data");
                Console.WriteLine("2. Change the title");
                Console.WriteLine("3. Change the director");
                Console.WriteLine("4. Change the studio");
                Console.WriteLine("5. Change the price");
                Console.WriteLine("6. Change the IMDb rating");
                Console.WriteLine("7. Change the release year");
                Console.WriteLine("8. Change the number of purchases");
                switch (movieType)
                {
                    case "digital":
                        Console.WriteLine("9. Change video quality");
                        Console.WriteLine("10. Change Dolby Atmos support");
                        Console.WriteLine("11. Change streaming availability");
                        break;
                    case "disc":
                        Console.WriteLine("9. Set available copies");
                        Console.WriteLine("10. Change discount percentage");
                        Console.WriteLine("11. Change disk type");
                        Console.WriteLine("12. Check if there is a discount");
                        Console.WriteLine("13. Change the number of avalaible copies");
                        break;
                    case "analog":
                        Console.WriteLine("9. Set available copies");
                        Console.WriteLine("10. Change discount percentage");
                        Console.WriteLine("11. Change format");
                        Console.WriteLine("12. Change condition");
                        break;
                }
                Console.Write("\n> ");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Error! You must enter a number!");
                    return;
                }
                switch (option)
                {
                    case 1:
                        catalogue[index].DisplayData();
                        break;
                    case 2:
                        string newTitle = CheckString("Enter new title: ");
                        catalogue[index].SetTitle(newTitle);
                        break;
                    case 3:
                        string newDirector = CheckString("Enter new director: ");
                        catalogue[index].SetDirector(newDirector);
                        break;
                    case 4:
                        string newStudio = CheckString("Enter new studio: ");
                        catalogue[index].SetStudio(newStudio);
                        break;
                    case 5:
                        double newPrice;
                        Console.Write("Enter new price: ");
                        while (!double.TryParse(Console.ReadLine(), out newPrice))
                        {
                            Console.Write("Invalid input. Please enter a valid price: ");
                        }
                        catalogue[index].SetPrice(newPrice);
                        break;
                    case 6:
                        double newRating;
                        Console.Write("Enter new IMDb rating (0-10): ");
                        while (!double.TryParse(Console.ReadLine(), out newRating) || newRating < 0 || newRating > 10)
                        {
                            Console.Write("Invalid input. Please enter a valid IMDb rating (0-10): ");
                        }
                        catalogue[index].SetIMDbRating(newRating);
                        break;
                    case 7:
                        int newReleaseYear;
                        Console.Write("Enter new release year: ");
                        while (!int.TryParse(Console.ReadLine(), out newReleaseYear) || newReleaseYear > DateTime.Now.Year || newReleaseYear < 1888)
                        {
                            Console.Write("Invalid input. Please enter a valid year: ");
                        }
                        catalogue[index].SetReleaseYear(newReleaseYear);
                        break;
                    case 8:
                        int newPurchases;
                        Console.Write("Enter new number of purchases: ");
                        while (!int.TryParse(Console.ReadLine(), out newPurchases) || newPurchases < 0)
                        {
                            Console.Write("Invalid input. Please enter a valid number of purchases: ");
                        }
                        catalogue[index].SetPurchasedCopies(newPurchases);
                        break;
                    case 9:
                        switch (movieType)
                        {
                            case "digital":
                                string newVideoQuality = CheckString("Enter new video quality: ");
                                ((DigitalMovieRelease)catalogue[index]).SetVideoQuality(newVideoQuality);
                                break;
                            case "disc":
                                SetAvailableCopiesToMovie(index);
                                break;
                            case "analog":
                                SetAvailableCopiesToMovie(index);
                                break;
                        }
                        break;
                    case 10:
                        switch (movieType)
                        {
                            case "digital":
                                Console.Write("Does it support Dolby Atmos? (yes/no): ");
                                bool newDolbyAtmosSupport = Console.ReadLine().Trim().ToLower() == "yes";
                                ((DigitalMovieRelease)catalogue[index]).SetDolbyAtmosSupport(newDolbyAtmosSupport);
                                break;
                            case "disc":
                                SetDiscountPercentage(index);
                                break;
                            case "analog":
                                SetDiscountPercentage(index);
                                break;
                        }
                        break;
                    case 11:
                        switch (movieType)
                        {
                            case "digital":
                                Console.Write("Is it on streaming? (yes/no): ");
                                bool newIsOnStreaming = Console.ReadLine().Trim().ToLower() == "yes";
                                ((DigitalMovieRelease)catalogue[index]).SetIsOnStreaming(newIsOnStreaming);
                                break;
                            case "disc":
                                string newDiskType = CheckString("Enter new disk type: ");
                                ((DiscMovieRelease)catalogue[index]).SetFormat(newDiskType);
                                break;
                            case "analog":
                                string newFormat = CheckString("Enter new format: ");
                                ((AnalogMovieRelease)catalogue[index]).SetFormat(newFormat);
                                break;
                        }
                        break;
                    case 12:
                        switch (movieType)
                        {
                            case "disc":
                                bool hasDiscount = ((DiscMovieRelease)catalogue[index]).HasDiscount();
                                Console.WriteLine("The disc movie release " + catalogue[index].GetTitle() + (hasDiscount ? " has a discount." : " does not have a discount."));
                                break;
                            case "analog":
                                Console.Write("Is the analog movie in good condition? (yes/no): ");
                                bool newCondition = Console.ReadLine().Trim().ToLower() == "yes";
                                ((AnalogMovieRelease)catalogue[index]).SetCondition(newCondition);
                                break;
                            case "digital":
                                Console.WriteLine("Option not implemented yet.");
                                break;
                        }
                        break;
                    case 13:
                        {
                            if (movieType == "disc")
                            {
                                int newCopies;
                                Console.Write("Enter the new number of available copies: ");
                                while (!int.TryParse(Console.ReadLine(), out newCopies) || newCopies < 0)
                                {
                                    Console.Write("Invalid input. Please enter a valid number of copies: ");
                                }
                                ((DiscMovieRelease)catalogue[index]).SetCopiesAvailable(newCopies);
                                Console.WriteLine("Available copies updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Option not implemented yet.");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Option not implemented yet.");
                        break;
                }
            }
        }

        private static void SetAvailableCopiesToMovie(int index)
        {
            Console.Clear();
            Console.Write("Enter the movie index to set available copies: ");

            if (catalogue[index] is DiscMovieRelease discMovie)
            {
                int newCopies;
                Console.Write("Enter the new number of available copies: ");
                while (!int.TryParse(Console.ReadLine(), out newCopies) || newCopies < 0)
                {
                    Console.Write("Invalid input. Please enter a valid number of copies: ");
                }
                discMovie.SetCopiesAvailable(newCopies);
                Console.WriteLine("Available copies updated successfully.");
            }
            else
            if (catalogue[index] is AnalogMovieRelease analogMovie)
            {
                int newCopies;
                Console.Write("Enter the new number of available copies: ");
                while (!int.TryParse(Console.ReadLine(), out newCopies) || newCopies < 0)
                {
                    Console.Write("Invalid input. Please enter a valid number of copies: ");
                }
                analogMovie.SetCopiesAvailable(newCopies);
                Console.WriteLine("Available copies updated successfully.");
            }
            else
            {
                Console.WriteLine("The selected movie is not a disc movie release.");
            }
        }
        private static void SetDiscountPercentage(int index)
        {
            double newDiscountAnalog;
            Console.Write("Enter new discount percentage: ");
            while (!double.TryParse(Console.ReadLine(), out newDiscountAnalog) || newDiscountAnalog < 0 || newDiscountAnalog > 100)
            {
                Console.Write("Invalid input. Please enter a valid discount percentage (0-100): ");
            }
            ((AnalogMovieRelease)catalogue[index]).SetDiscount(newDiscountAnalog);
        }
        private static void DeleteMovieFromCollection()
        {
            Console.Clear();
            int index;
            Console.Write("Enter the movie index to delete: ");
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= catalogue.Count)
            {
                Console.Write("Invalid input. Please enter a valid movie index to delete: ");
            }
            if (index >= 0 && index < catalogue.Count)
            {
                catalogue.RemoveAt(index);
                Console.WriteLine("Movie release at index " + index + " has been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid index. No movie release deleted.");
            }
        }

        private static void SellCopy()
        {
            Console.Clear();
            Console.Write("Enter the movie index you want to sell: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Error! You must enter a number!");
                return;
            }

            if (index >= 0 && index < catalogue.Count && catalogue[index] != null)
            {
                catalogue[index].SellCopy(catalogue, index);
            }
            else
            {
                Console.WriteLine("Not existing index.");
            }
        }
        private static void TotalIncome()
        {
            Console.Clear();
            Console.WriteLine("===Total income===");
            double ukupnaSuma = 0;
            foreach (MovieRelease i in catalogue)
            {
                if (i != null)
                {
                    ukupnaSuma += i.GetIncome();

                }
            }
            Console.WriteLine("Total income: " + ukupnaSuma + " dinars");
        }
    }

}
