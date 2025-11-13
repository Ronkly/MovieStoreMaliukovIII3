using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Director: " + Director);
            Console.WriteLine("Studio: " + Studio);
            Console.WriteLine("Price: " + Price + " dinars");
            Console.WriteLine("Number of purchased copies: " + PurchasedCopies + " copies");
            Console.WriteLine("IMDb Rating: " + IMDbRating);
            Console.WriteLine("Release year: " + ReleaseYear);
            Console.WriteLine(new string('-', 5));
        }

        public virtual double GetIncome()
        {
            return Price * PurchasedCopies;
        }

        public virtual void SellCopy()
        {
            PurchasedCopies++;
            Console.WriteLine("A copy of the movie release '" + Title + "' is sold.");
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

        public override void SellCopy()
        {
            base.SellCopy();
            Console.WriteLine("The movie is available in your library now.");
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("VideoQuality: " + VideoQuality);
            Console.WriteLine("Dolby Atmos Support: " + (DolbyAtmosSupport ? "Yes" : "No"));
            Console.WriteLine("Is On Streaming: " + (IsOnStreaming ? "Yes" : "No"));
        }
        public bool Is4K()
        {
            return VideoQuality.ToUpper().Contains("4K");
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
            DiskType = Format;
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
        public double GetPriceWithDiscount()
        {
            return Price * (100.0 - Discount) / 100.0;
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
        public override void SellCopy()
        {
            if (CopiesAvailable > 0)
            {
                base.SellCopy();
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
            Console.WriteLine("Disk Type: " + DiskType);
            Console.WriteLine("Price with Discount: " + GetPriceWithDiscount() + " dinars");
        }
        public override double GetIncome()
        {
            return Price * (100.0 - Discount) / 100.0 * PurchasedCopies;
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
        public double GetPriceWithDiscount()
        {
            return Price * (100.0 - Discount) / 100.0;
        }
        public override double GetIncome()
        {
            return Price * (100.0 - Discount) / 100.0 * PurchasedCopies;
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

        public override void SellCopy()
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
            Console.WriteLine("Copies available: " + CopiesAvailable + " copies");
            Console.WriteLine("Discount: " + Discount + "%");
            Console.WriteLine("Good Condition: " + (GoodCondition ? "Yes" : "No"));
            Console.WriteLine("Price with Discount: " + GetPriceWithDiscount() + " dinars");
        }
    }

    internal class Program
    {
        private static readonly List<MovieRelease> catalogue = new List<MovieRelease>();
        private static void Main(string[] args)
        {
            catalogue.Add(new DigitalMovieRelease("Inception", "Christopher Nolan", "Warner Bros.", 500, 2010, 8.8, "4K", true, true));
            catalogue.Add(new DiscMovieRelease("The Matrix", "The Wachowskis", "Warner Bros.", 300, 1999, 8.7, "Blu-ray", 10, 15));
            catalogue.Add(new AnalogMovieRelease("The Godfather", "Francis Ford Coppola", "Paramount Pictures", 400, 1972, 9.2, "VHS", 5, 10, true));
            Console.WriteLine("Welcome to the Professor Movies!");
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nChoose your option:");
                Console.WriteLine("1. Display the data of all movie releases" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("2. The most expensive movie release" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("3. Display movies with a discount" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("4. Total income");
                Console.WriteLine("5. Add new movie");
                Console.WriteLine("6. Interact with a movie" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("7. Delete a movie" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("8. Sell a movie copy" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("9. Show 4K Digital Movies" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));

                Console.WriteLine("\n0. Quit");

                Console.Write("\n> ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Error! You must enter a number!\n> .");
                }
                switch (choice)
                {
                    case 1: DisplayAllMovies(catalogue); break;
                    case 2: MostExpensiveMovieRelease(catalogue); break;
                    case 3: MoviesWithDiscount(catalogue); break;
                    case 4: TotalIncome(); break;
                    case 5: AddMovieToCollection(); break;
                    case 6: InteractWithMovie(); break;
                    case 7: DeleteMovieFromCollection(); break;
                    case 8: SellCopy(); break;
                    case 9: Show4KMovies(); break;
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
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.Write("Input cannot be empty. Please try again: ");
            }
            return input;
        }
        private static int CheckInt(string prompt, int min, int max)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }
        private static double CheckDouble(string prompt, double min, double max)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }
        private static bool CheckIndex(int index)
        {
            if (index < 0 || index >= catalogue.Count)
            {
                Console.WriteLine("Invalid index.");
                return false;
            }
            return true;
        }
        private static bool CheckCatalogueEmpty()
        {
            if (catalogue.Count == 0)
            {
                Console.WriteLine("The catalogue is empty.");
                return true;
            }
            return false;
        }
        #region Display Methods
        private static void DisplayAllMovies(List<MovieRelease> catalogue)
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            Console.WriteLine("=== Our catalogue ===");
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
            if (!CheckCatalogueEmpty())
            {
                double maxPrice = -1;
                MovieRelease expensive = null;

                foreach (MovieRelease i in catalogue)
                {
                    if (i != null && i.GetPrice() > maxPrice)
                    {
                        maxPrice = i.GetPrice();
                        expensive = i;
                    }
                }
                if (expensive != null)
                {
                    Console.WriteLine("=== The most expensive movie release ===");
                    expensive.DisplayData();
                }
                else
                {
                    Console.WriteLine("There are no movies in the catalogue.");
                }
            }
        }
        private static void MoviesWithDiscount(List<MovieRelease> catalogue)
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            Console.WriteLine("=== Movies with a discount ===");
            foreach (MovieRelease i in catalogue)
            {
                if (i is DiscMovieRelease disc && disc.HasDiscount())
                {
                    Console.WriteLine("Tite: " + disc.GetTitle());
                    Console.WriteLine("Price: " + disc.GetPrice());
                    Console.WriteLine("Discount: " + disc.GetDiscount());
                    Console.WriteLine("Price with discount: " + disc.GetPriceWithDiscount());
                    Console.WriteLine(new string('-', 25));
                }
                else if (i is AnalogMovieRelease analog && analog.HasDiscount())
                {
                    Console.WriteLine(analog.GetTitle());
                    Console.WriteLine(analog.GetPrice());
                    Console.WriteLine(analog.GetDiscount());
                    Console.WriteLine(analog.GetPriceWithDiscount());
                    Console.WriteLine(new string('-', 25));
                }
            }
        }
        #endregion


        private static void AddMovieToCollection()
        {
            Console.Clear();
            Console.WriteLine("=== Add new movie release ===");
            Console.WriteLine("Choose movie type to add:");
            Console.WriteLine("1. Digital Movie");
            Console.WriteLine("2. Disc Movie");
            Console.WriteLine("3. Analog Movie");
            Console.Write("\n> ");
            int movieType;
            List<int> allowedOptions = new List<int> { 1, 2, 3 };
            while (!int.TryParse(Console.ReadLine(), out movieType) || !allowedOptions.Contains(movieType))
            {
                Console.WriteLine("Invalid input! Enter 1, 2 or 3.");
                Console.Write("\n> ");
            }
            string title = CheckString("Enter title: ");
            string director = CheckString("Enter director: ");
            string studio = CheckString("Enter studio: ");
            double price = CheckDouble("Enter price: ", 0, double.MaxValue);
            int releaseYear = CheckInt("Enter release year: ", 1888, DateTime.Now.Year);
            double imdbRating = CheckDouble("Enter new IMDb rating (0-10): ", 0, 10);
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
        private static void Show4KMovies()
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            Console.WriteLine("=== 4K Digital Movie Releases ===");
            bool found = false;
            foreach (MovieRelease i in catalogue)
            {
                if (i is DigitalMovieRelease digital && digital.Is4K())
                {
                    Console.WriteLine("- " + digital.GetTitle());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No 4K digital movies found.");
            }
        }

        private static void InteractWithMovie()
        {
            Console.Clear();
            while (true)
            {
                if (CheckCatalogueEmpty())
                {
                    return;
                }

                DisplayAllMoviesNames();
                Console.Write("\nEnter the movie index to interact with or 0 to leave the interaction: ");
                if (!int.TryParse(Console.ReadLine(), out int index))
                {
                    Console.Clear();
                    Console.WriteLine("Error! You must enter a number!");
                    continue;
                }
                if (index == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Leaving interaction...");
                    return;
                }
                index--;
                if (!CheckIndex(index))
                {
                    continue;
                }

                string movieType;
                if (catalogue[index] is DiscMovieRelease)
                {
                    Console.WriteLine("\nInteracting with disc movie release: " + catalogue[index].GetTitle());
                    movieType = "disc";
                }
                else if (catalogue[index] is AnalogMovieRelease)
                {
                    Console.WriteLine("\nInteracting with analog movie release: " + catalogue[index].GetTitle());
                    movieType = "analog";
                }
                else
                {
                    Console.WriteLine("\nInteracting with digital movie release: " + catalogue[index].GetTitle());
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
                        break;
                    case "analog":
                        Console.WriteLine("9. Set available copies");
                        Console.WriteLine("10. Change discount percentage");
                        Console.WriteLine("11. Change format");
                        Console.WriteLine("12. Change condition");
                        break;
                }
                Console.WriteLine("\n0. Leave interaction");
                Console.Write("\n> ");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Error! You must enter a number!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        catalogue[index].DisplayData();
                        Console.WriteLine("\nPress any key");
                        _ = Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        string newTitle = CheckString("Enter new title: ");
                        catalogue[index].SetTitle(newTitle);
                        break;
                    case 3:
                        Console.Clear();
                        string newDirector = CheckString("Enter new director: ");
                        catalogue[index].SetDirector(newDirector);
                        break;
                    case 4:
                        Console.Clear();
                        string newStudio = CheckString("Enter new studio: ");
                        catalogue[index].SetStudio(newStudio);
                        break;
                    case 5:
                        Console.Clear();
                        double newPrice = CheckDouble("Enter new price: ", 0, double.MaxValue);
                        catalogue[index].SetPrice(newPrice);
                        break;
                    case 6:
                        Console.Clear();
                        double newRating = CheckDouble("Enter new IMDb rating (0-10): ", 0, 10);
                        catalogue[index].SetIMDbRating(newRating);
                        break;
                    case 7:
                        Console.Clear();
                        int newReleaseYear = CheckInt("Enter new release year: ", 1888, DateTime.Now.Year);
                        catalogue[index].SetReleaseYear(newReleaseYear);
                        break;
                    case 8:
                        Console.Clear();
                        int newPurchases = CheckInt("Enter new number of purchases: ", 0, int.MaxValue);
                        catalogue[index].SetPurchasedCopies(newPurchases);
                        break;
                    case 9:
                        Console.Clear();
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
                        Console.Clear();
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
                        Console.Clear();
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
                        Console.Clear();
                        switch (movieType)
                        {
                            case "disc":
                                bool hasDiscount = ((DiscMovieRelease)catalogue[index]).HasDiscount();
                                Console.WriteLine("The disc movie release " + catalogue[index].GetTitle() + (hasDiscount ? " has a discount." : " does not have a discount."));
                                Console.WriteLine("\nPress any key");
                                _ = Console.ReadKey();
                                break;
                            case "analog":
                                Console.Write("Is the analog movie in good condition? (yes/no): ");
                                bool newCondition = Console.ReadLine().Trim().ToLower() == "yes";
                                ((AnalogMovieRelease)catalogue[index]).SetCondition(newCondition);
                                break;
                            case "digital":
                                Console.WriteLine("Option not implemented yet.");
                                Console.WriteLine("\nPress any key");
                                _ = Console.ReadKey();
                                break;
                        }
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Leaving interaction...");
                        return;
                    default:
                        Console.WriteLine("Option not implemented yet.");
                        break;
                }
            }
        }

        private static void SetAvailableCopiesToMovie(int index)
        {
            Console.Clear();
            int newCopies = CheckInt("Enter the new number of available copies: ", 0, int.MaxValue);

            if (catalogue[index] is DiscMovieRelease discMovie)
            {
                discMovie.SetCopiesAvailable(newCopies);
            }
            else if (catalogue[index] is AnalogMovieRelease analogMovie)
            {
                analogMovie.SetCopiesAvailable(newCopies);
            }
            else
            {
                Console.WriteLine("The selected movie is not a disc movie release.");
            }
        }
        private static void SetDiscountPercentage(int index)
        {
            double newDiscount;
            Console.Write("Enter new discount percentage: ");
            while (!double.TryParse(Console.ReadLine(), out newDiscount) || newDiscount < 0 || newDiscount > 100)
            {
                Console.Write("Invalid input. Please enter a valid discount percentage (0-100): ");
            }
            if (catalogue[index] is DiscMovieRelease)
            {
                ((DiscMovieRelease)catalogue[index]).SetDiscount(newDiscount);
            }
            else if (catalogue[index] is AnalogMovieRelease)
            {
                ((AnalogMovieRelease)catalogue[index]).SetDiscount(newDiscount);
            }
        }
        private static void DeleteMovieFromCollection()
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            DisplayAllMoviesNames();
            Console.Write("Enter the movie index to delete or 0 to quit deleting: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.Write("Invalid input.");
                return;
            }
            if (index == 0)
            {
                Console.Clear();
                Console.WriteLine("Quitting deleting...");
                return;
            }
            index--;
            Console.Clear();
            if (!CheckIndex(index))
            {
                return;
            }

            Console.WriteLine(catalogue[index].GetTitle() + " has been deleted.");
            catalogue.RemoveAt(index);
        }

        private static void SellCopy()
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            DisplayAllMoviesNames();
            Console.Write("\nEnter the movie index you want to sell or enter 0 to quit selling: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Error! You must enter a number!");
                return;
            }
            if (index == 0)
            {
                Console.Clear();
                Console.WriteLine("Quitting selling...");
                return;
            }
            index--;
            Console.Clear();
            if (!CheckIndex(index))
            {
                return;
            }

            catalogue[index].SellCopy();
        }
        private static void DisplayAllMoviesNames()
        {
            Console.Clear();
            if (CheckCatalogueEmpty())
            {
                return;
            }

            Console.WriteLine("=== Movie Releases in Catalogue ===");
            for (int i = 0; i < catalogue.Count; i++)
            {
                if (catalogue[i] != null)
                {
                    Console.WriteLine((i + 1).ToString() + ". " + catalogue[i].GetTitle());
                }
            }
        }
        private static void TotalIncome()
        {
            Console.Clear();
            Console.WriteLine("=== Total income ===");
            double totalSum = catalogue.Sum(m => m.GetIncome());
            Console.WriteLine("Total income: " + totalSum + " dinars");
        }
    }

}
