using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMaliukovIII3.Classes
{
    internal class PhysicalMovieRelease : MovieRelease
    {
        protected int _copiesAvailable;
        protected double _discount;
        protected string _format;

        public PhysicalMovieRelease(string title, string director, string studio, double price, int releaseYear, double imdbRating, string format, int copiesAvailable, double discount)
            : base(title, director, studio, price, releaseYear, imdbRating)
        {
            Format = format;
            CopiesAvailable = copiesAvailable;
            Discount = discount;
        }
        public virtual string Format
        {
            get => _format;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _format = value;
                else
                {
                    _format = "Unknown format";
                    Console.WriteLine("Format cannot be empty!");
                }
            }
        }
        public int CopiesAvailable
        {
            get => _copiesAvailable;
            set
            {
                if (value >= 0)
                    _copiesAvailable = value;
                else
                {
                    _copiesAvailable = 0;
                    Console.WriteLine("No copies available!");
                }
            }
        }

        public double Discount
        {
            get => _discount;
            set
            {
                if (value >= 0 && value <= 100)
                    _discount = value;
                else
                {
                    _discount = 0;
                    Console.WriteLine("Invalid discount! It must be between 0 and 100.");
                }
            }
        }

        public bool HasDiscount() => Discount > 0;

        public double GetPriceWithDiscount() => Price * (100.0 - Discount) / 100.0;

        public override double GetIncome() => Price * (100.0 - Discount) / 100.0 * PurchasedCopies;

        public override void SellCopy()
        {
            if (CopiesAvailable > 0)
            {
                PurchasedCopies++;
                CopiesAvailable--;
                Console.WriteLine($"Movie release: {Title} is sold.");
                Console.WriteLine($"Availability: {CopiesAvailable} copies");

                if (CopiesAvailable == 0)
                {
                    Console.WriteLine($"MovieRelease: {Title} is sold out.");
                }
            }
            else
            {
                Console.WriteLine($"Movie release: {Title} isn't available anymore.");
            }
        }

        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine($"Copies available: {CopiesAvailable} copies");
            Console.WriteLine($"Discount: {Discount}%");
            Console.WriteLine($"Price with Discount: {GetPriceWithDiscount()} dinars");
        }
    }
}
