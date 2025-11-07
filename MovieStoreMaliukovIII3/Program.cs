using System;

namespace MovieStoreMaliukovIII3
{
    internal abstract class MovieRelease
    {
        protected string Title { get; set; }
        protected string Director { get; set; }
        protected string Studio { get; set; }
        protected double Price { get; set; }
        protected int IMDbRating { get; set; }
        protected int ReleaseYear { get; set; }

        public MovieRelease(string title, string director, string studio, double price, int releaseYear)
        {
            Title = title;
            Director = director;
            Studio = studio;
            Price = price;
            ReleaseYear = releaseYear;
            IMDbRating = 0;
        }

        public int GetIMDbRating()
        {
            return IMDbRating;
        }

        public double GetCenu()
        {
            return Price;
        }

        public virtual void DisplayData()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Price: " + Price + " dinara");
            Console.WriteLine("Broj prodatih primeraka: " + IMDbRating + " kom.");
            Console.WriteLine("Godina izdanja: " + ReleaseYear + ". godina");
        }

        public virtual double GetIncome()
        {
            return Price * IMDbRating;
        }

        public virtual void SellCopy(MovieRelease[] catalogue, int index)
        {
            IMDbRating++;
            Console.WriteLine("MovieRelease: " + Title + " je prodata.");
            Console.WriteLine("Ukupno prodato:" + IMDbRating + " kom.");
        }
    }

    internal class DigitalMovieRelease : MovieRelease
    {
        private string VideoQuality { get; set; }
        private bool DolbyAtmosSupport { get; set; }
        private bool IsOnStreaming { get; set; }

        public DigitalMovieRelease(string title, string director, string studio, double price, int releaseYear, string VideoQuality, bool IsOnStreaming)
            : base(title, director, studio, price, releaseYear)
        {
            this.VideoQuality = VideoQuality;
            this.IsOnStreaming = IsOnStreaming;
        }

        public override void SellCopy(MovieRelease[] catalogue, int index)
        {
            base.SellCopy(catalogue, index);
            Console.WriteLine("The movie is available in your library now.");
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("VideoQuality: " + VideoQuality);

        }
    }

    internal class DiscMovieRelease : MovieRelease
    {
        private int CopiesAvailable { get; set; }
        private double Discount { get; set; }

        public DiscMovieRelease(string title, string director, string studio, double price, int releaseYear, int CopiesAvailable, double Discount)
            : base(title, director, studio, price, releaseYear)
        {
            this.CopiesAvailable = CopiesAvailable;
            this.Discount = Discount;
        }

        public bool HasDiscount()
        {
            return Discount > 0;
        }

        public override void SellCopy(MovieRelease[] catalogue, int index)
        {
            if (CopiesAvailable > 0)
            {
                IMDbRating++;
                CopiesAvailable--;
                Console.WriteLine("Movie release: " + Title + " is sold.");
                Console.WriteLine("Availability: " + CopiesAvailable + " copies");

                if (CopiesAvailable == 0)
                {
                    catalogue[index] = null;
                    Console.WriteLine("MovieRelease: " + Title + " je rasprodata.");
                }
            }
            else
            {
                Console.WriteLine("Movie release: " + Title + " vise nije dostupna.");
            }
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Na zalihama: " + CopiesAvailable + " kom");
            Console.WriteLine("Discount: " + Discount + "%");
        }
    }
    internal class AnalogMovieRelease : MovieRelease
    {
        private int CopiesAvailable { get; set; }
        private double Discount { get; set; }

        public AnalogMovieRelease(string title, string director, string studio, double price, int releaseYear, int CopiesAvailable, double Discount)
            : base(title, director, studio, price, releaseYear)
        {
            this.CopiesAvailable = CopiesAvailable;
            this.Discount = Discount;
        }

        public bool HasDiscount()
        {
            return Discount > 0;
        }

        public override void SellCopy(MovieRelease[] catalogue, int index)
        {
            if (CopiesAvailable > 0)
            {
                IMDbRating++;
                CopiesAvailable--;
                Console.WriteLine("Movie release: " + Title + " is sold.");
                Console.WriteLine("Availability: " + CopiesAvailable + " copies");

                if (CopiesAvailable == 0)
                {
                    catalogue[index] = null;
                    Console.WriteLine("MovieRelease: " + Title + " je rasprodata.");
                }
            }
            else
            {
                Console.WriteLine("Movie release: " + Title + " vise nije dostupna.");
            }
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Na zalihama: " + CopiesAvailable + " kom");
            Console.WriteLine("Discount: " + Discount + "%");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MovieRelease[] catalogue = new MovieRelease[5];

            while (true)
            {
                Console.WriteLine("\nGameCentar");
                Console.WriteLine("1. Prikaz podatke o MovieReleasema");
                Console.WriteLine("2. Prodaj video igru");
                Console.WriteLine("3. Najskuplja video MovieRelease");
                Console.WriteLine("4. Prikazi igre sa popustom");
                Console.WriteLine("5. Prikazi zahtevne igre");
                Console.WriteLine("6. Ukupan prihod prodaje");
                Console.WriteLine("0. Izlaz iz programa...");

                Console.Write("Unesite izbor: ");
                if (!int.TryParse(Console.ReadLine(), out int izbor))
                {
                    Console.WriteLine("Greska! Morate uneti broj.");
                    continue;
                }

                switch (izbor)
                {
                    case 1: PrikaziSveIgre(catalogue); break;
                    case 2: SellCopy(catalogue); break;
                    case 3: NajskupljaMovieRelease(catalogue); break;
                    case 4: IgreSaDiscountom(catalogue); break;
                    case 5: break;
                    case 6: UkupanPrihodProdaje(catalogue); break;
                    case 0:
                        Console.WriteLine("Kraj programa..."); return;
                    default:
                        Console.WriteLine("Nepoznata opcija."); break;
                }
            }
        }

        private static void PrikaziSveIgre(MovieRelease[] catalogue)
        {
            Console.Clear();
            Console.WriteLine("\n===Nasa catalogue===");
            for (int i = 0; i < catalogue.Length; i++)
            {
                if (catalogue[i] != null)
                {
                    catalogue[i].DisplayData();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }

        private static void SellCopy(MovieRelease[] catalogue)
        {
            Console.Clear();
            Console.Write("Unesite index igre za prodaju: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Greska! Morate uneti broj");
                return;
            }

            if (index >= 0 && index < catalogue.Length && catalogue[index] != null)
            {
                catalogue[index].SellCopy(catalogue, index);
            }
            else
            {
                Console.WriteLine("Nevazeci index za igru.");
            }
        }

        private static void NajskupljaMovieRelease(MovieRelease[] catalogue)
        {
            Console.Clear();
            double maxPrice = -1;
            MovieRelease najskuplja = null;

            foreach (MovieRelease i in catalogue)
            {
                if (i != null && i.GetCenu() > maxPrice)
                {
                    maxPrice = i.GetCenu();
                    najskuplja = i;
                }
            }
            if (najskuplja != null)
            {
                Console.WriteLine("===Najskuplja MovieRelease===");
                najskuplja.DisplayData();
            }
            else
            {
                Console.WriteLine("Nema dostupnih igara u ponudi.");
            }
        }

        private static void IgreSaDiscountom(MovieRelease[] catalogue)
        {
            Console.Clear();
            Console.WriteLine("===Igre sa popustom===");
            foreach (MovieRelease i in catalogue)
            {
                if (i is DiscMovieRelease fiz && fiz.HasDiscount())
                {
                    fiz.DisplayData();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }

        private static void UkupanPrihodProdaje(MovieRelease[] catalogue)
        {
            Console.Clear();
            Console.WriteLine("===Ukupan prihod prodaje===");
            double ukupnaSuma = 0;
            foreach (MovieRelease i in catalogue)
            {
                if (i != null)
                {
                    ukupnaSuma += i.GetIncome();

                }
            }
            Console.WriteLine("Ukupan prihod prodaje: " + ukupnaSuma + " dinara");
        }
    }

}
