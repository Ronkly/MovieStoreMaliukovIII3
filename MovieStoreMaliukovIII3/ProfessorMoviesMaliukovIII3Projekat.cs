using System;
using System.Collections.Generic;
using System.Linq;
using MovieStoreMaliukovIII3.Classes;

namespace MovieStoreMaliukovIII3
{
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
                Console.WriteLine($"1. Display the data of all movie releases{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");
                Console.WriteLine($"2. The most expensive movie release{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");
                Console.WriteLine("3. Display movies with a discount" + (catalogue.Count == 0 ? " - [NOT AVAILABLE]" : ""));
                Console.WriteLine("4. Total income");
                Console.WriteLine("5. Add new movie");
                Console.WriteLine($"6. Interact with a movie{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");
                Console.WriteLine($"7. Delete a movie{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");
                Console.WriteLine($"8. Sell a movie copy{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");
                Console.WriteLine($"9. Show 4K Digital Movies{(catalogue.Count == 0 ? " - [NOT AVAILABLE]" : "")} ");

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
                    if (i != null && i.Price > maxPrice)
                    {
                        maxPrice = i.Price;
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
                    Console.WriteLine($"Title: {disc.Title}");
                    Console.WriteLine($"Price: {disc.Price}");
                    Console.WriteLine($"Discount: {disc.Discount}");
                    Console.WriteLine($"Price with discount: {disc.GetPriceWithDiscount()}");
                    Console.WriteLine(new string('-', 25));
                }
                else if (i is AnalogMovieRelease analog && analog.HasDiscount())
                {
                    Console.WriteLine($"Title: {analog.Title}");
                    Console.WriteLine($"Price: {analog.Price}");
                    Console.WriteLine($"Discount: {analog.Discount}");
                    Console.WriteLine($"Price with discount: {analog.GetPriceWithDiscount()}");
                    Console.WriteLine(new string('-', 25));
                }
            }
        }
        #endregion

        internal static bool CheckIndex(int index)
        {
            if (index < 0 || index >= catalogue.Count)
            {
                Console.WriteLine("Invalid index.");
                return false;
            }
            return true;
        }
        internal static bool CheckCatalogueEmpty()
        {
            if (catalogue.Count == 0)
            {
                Console.WriteLine("The catalogue is empty.");
                return true;
            }
            return false;
        }

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
            string title = InputHelper.CheckString("Enter title: ");
            string director = InputHelper.CheckString("Enter director: ");
            string studio = InputHelper.CheckString("Enter studio: ");
            double price = InputHelper.CheckDouble("Enter price: ", 0, double.MaxValue);
            int releaseYear = InputHelper.CheckInt("Enter release year: ", 1888, DateTime.Now.Year);
            double imdbRating = InputHelper.CheckDouble("Enter new IMDb rating (0-10): ", 0, 10);
            switch (movieType)
            {
                case 1:
                    string videoQuality = InputHelper.CheckString("Enter video quality (e.g., 1080p, 4K): ");
                    bool dolbyAtmosSupport = InputHelper.CheckBool("Does it support Dolby Atmos? (yes/no): ");
                    bool isOnStreaming = InputHelper.CheckBool("Is it on streaming? (yes/no): ");
                    catalogue.Add(new DigitalMovieRelease(title, director, studio, price, releaseYear, imdbRating, videoQuality, dolbyAtmosSupport, isOnStreaming));
                    break;
                case 2:
                    string discType = InputHelper.CheckString("Enter format (DVD, Blu-ray, CD, LaserDisk): ");
                    int copiesAvailableDisc = InputHelper.CheckInt("Enter number of copies available: ", 0, int.MaxValue);
                    double discountDisc = InputHelper.CheckDouble("Enter discount percentage: ", 0, 100);
                    catalogue.Add(new DiscMovieRelease(title, director, studio, price, releaseYear, imdbRating, discType, copiesAvailableDisc, discountDisc));
                    break;
                case 3:
                    string formatAnalog = InputHelper.CheckString("Enter format (e.g., VHS, ): ");
                    int copiesAvailableAnalog = InputHelper.CheckInt("Enter number of copies available: ", 0, int.MaxValue);
                    double discountAnalog = InputHelper.CheckDouble("Enter discount percentage: ", 0, 100);
                    bool goodCondition = InputHelper.CheckBool("Is the analog movie in good condition? (yes/no): ");
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
                    Console.WriteLine($"- {digital.Title}");
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
                    Console.WriteLine($"\nInteracting with disc movie release: " + catalogue[index].Title);
                    movieType = "disc";
                }
                else if (catalogue[index] is AnalogMovieRelease)
                {
                    Console.WriteLine($"\nInteracting with analog movie release: " + catalogue[index].Title);
                    movieType = "analog";
                }
                else
                {
                    Console.WriteLine($"\nInteracting with digital movie release: " + catalogue[index].Title);
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
                        string newTitle = InputHelper.CheckString("Enter new title: ");
                        catalogue[index].Title = newTitle;
                        break;
                    case 3:
                        Console.Clear();
                        string newDirector = InputHelper.CheckString("Enter new director: ");
                        catalogue[index].Director = newDirector;
                        break;
                    case 4:
                        Console.Clear();
                        string newStudio = InputHelper.CheckString("Enter new studio: ");
                        catalogue[index].Studio = newStudio;
                        break;
                    case 5:
                        Console.Clear();
                        double newPrice = InputHelper.CheckDouble("Enter new price: ", 0, double.MaxValue);
                        catalogue[index].Price = newPrice;
                        break;
                    case 6:
                        Console.Clear();
                        double newRating = InputHelper.CheckDouble("Enter new IMDb rating (0-10): ", 0, 10);
                        catalogue[index].IMDbRating = newRating;
                        break;
                    case 7:
                        Console.Clear();
                        int newReleaseYear = InputHelper.CheckInt("Enter new release year: ", 1888, DateTime.Now.Year);
                        catalogue[index].ReleaseYear = newReleaseYear;
                        break;
                    case 8:
                        Console.Clear();
                        int newPurchases = InputHelper.CheckInt("Enter new number of purchases: ", 0, int.MaxValue);
                        catalogue[index].PurchasedCopies = newPurchases;
                        break;
                    case 9:
                        Console.Clear();
                        switch (movieType)
                        {
                            case "digital":
                                ((DigitalMovieRelease)catalogue[index]).VideoQuality = InputHelper.CheckString("Enter new video quality: ");
                                break;
                            case "disc":
                                ((PhysicalMovieRelease)catalogue[index]).CopiesAvailable = InputHelper.CheckInt("Enter the new number of available copies: ", 0, int.MaxValue);
                                break;
                            case "analog":
                                ((PhysicalMovieRelease)catalogue[index]).CopiesAvailable = InputHelper.CheckInt("Enter the new number of available copies: ", 0, int.MaxValue);
                                break;
                        }
                        break;
                    case 10:
                        Console.Clear();
                        switch (movieType)
                        {
                            case "digital":
                                ((DigitalMovieRelease)catalogue[index]).DolbyAtmosSupport = InputHelper.CheckBool("Does it support Dolby Atmos? (yes/no): ");
                                break;
                            case "disc":
                                ((PhysicalMovieRelease)catalogue[index]).Discount = InputHelper.CheckDouble("Enter new discount percentage: ", 0, 100);
                                break;
                            case "analog":
                                ((PhysicalMovieRelease)catalogue[index]).Discount = InputHelper.CheckDouble("Enter new discount percentage: ", 0, 100);
                                break;
                        }
                        break;
                    case 11:
                        Console.Clear();
                        switch (movieType)
                        {
                            case "digital":
                                ((DigitalMovieRelease)catalogue[index]).IsOnStreaming = InputHelper.CheckBool("Is it on streaming? (yes/no): ");
                                break;
                            case "disc":
                                ((DiscMovieRelease)catalogue[index]).Format = InputHelper.CheckString("Enter new disk type: ");
                                break;
                            case "analog":
                                ((AnalogMovieRelease)catalogue[index]).Format = InputHelper.CheckString("Enter new format: ");
                                break;
                        }
                        break;
                    case 12:
                        Console.Clear();
                        switch (movieType)
                        {
                            case "disc":
                                bool hasDiscount = ((DiscMovieRelease)catalogue[index]).HasDiscount();
                                Console.WriteLine($"The disc movie release " + catalogue[index].Title + (hasDiscount ? " has a discount." : " does not have a discount."));
                                Console.WriteLine("\nPress any key");
                                _ = Console.ReadKey();
                                break;
                            case "analog":
                                ((AnalogMovieRelease)catalogue[index]).GoodCondition = InputHelper.CheckBool("Is the analog movie in good condition? (yes/no): ");
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

            Console.WriteLine(catalogue[index].Title + " has been deleted.");
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
                    Console.WriteLine((i + 1).ToString() + ". " + catalogue[i].Title + " - " + (catalogue[i] is PhysicalMovieRelease phys ? phys.Format : "Digital"));
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
