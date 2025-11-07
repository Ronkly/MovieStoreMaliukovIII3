using System;

namespace MovieStoreMaliukovIII3
{
    internal class Igra
    {
        protected string Naziv { get; set; }
        protected double Cena { get; set; }
        protected int ProdatihKopija { get; set; }
        protected int GodinaIzdanja { get; set; }

        public Igra(string naziv, double cena, int godinaIzdanja)
        {
            Naziv = naziv;
            Cena = cena;
            GodinaIzdanja = godinaIzdanja;
            ProdatihKopija = 0;
        }

        public int VratiBrojProdatihPrimeraka()
        {
            return ProdatihKopija;
        }

        public double VratiCenu()
        {
            return Cena;
        }

        public virtual void PrikaziInformacije()
        {
            Console.WriteLine("Naziv: " + Naziv);
            Console.WriteLine("Cena: " + Cena + " dinara");
            Console.WriteLine("Broj prodatih primeraka: " + ProdatihKopija + " kom.");
            Console.WriteLine("Godina izdanja: " + GodinaIzdanja + ". godina");
        }

        public virtual double IzracunajPrihod()
        {
            return Cena * ProdatihKopija;
        }

        public virtual void ProdajIgru(Igra[] ponuda, int index)
        {
            ProdatihKopija++;
            Console.WriteLine("Igra: " + Naziv + " je prodata.");
            Console.WriteLine("Ukupno prodato:" + ProdatihKopija + " kom.");
        }
    }

    internal class DigitalnaIgra : Igra
    {
        private string Platforma { get; set; }
        private double VelicinaGB { get; set; }

        public DigitalnaIgra(string naziv, double cena, int godinaIzdanja, string Platforma, double VelicinaGB)
            : base(naziv, cena, godinaIzdanja)
        {
            this.Platforma = Platforma;
            this.VelicinaGB = VelicinaGB;
        }

        public bool ZahtevaJakuKonfiguraciju()
        {
            return VelicinaGB > 80;
        }

        public override void ProdajIgru(Igra[] ponuda, int index)
        {
            base.ProdajIgru(ponuda, index);
            Console.WriteLine("Kljuc za video igru je poslat na email.");
        }

        public override void PrikaziInformacije()
        {
            base.PrikaziInformacije();
            Console.WriteLine("Platforma: " + Platforma);
            Console.WriteLine("Velicina: " + VelicinaGB + "GB");
        }
    }

    internal class FizicikaIgra : Igra
    {
        private int NaZalihama { get; set; }
        private double Popust { get; set; }

        public FizicikaIgra(string naziv, double cena, int godinaIzdanja, int NaZalihama, double Popust)
            : base(naziv, cena, godinaIzdanja)
        {
            this.NaZalihama = NaZalihama;
            this.Popust = Popust;
        }

        public bool imaPopust()
        {
            return Popust > 0;
        }

        public override void ProdajIgru(Igra[] ponuda, int index)
        {
            if (NaZalihama > 0)
            {
                ProdatihKopija++;
                NaZalihama--;
                Console.WriteLine("Igra: " + Naziv + " je prodata.");
                Console.WriteLine("Stanje na zalihama: " + NaZalihama + " kom.");

                if (NaZalihama == 0)
                {
                    ponuda[index] = null;
                    Console.WriteLine("Igra: " + Naziv + " je rasprodata.");
                }
            }
            else
            {
                Console.WriteLine("Igra: " + Naziv + " vise nije dostupna.");
            }
        }
        public override void PrikaziInformacije()
        {
            base.PrikaziInformacije();
            Console.WriteLine("Na zalihama: " + NaZalihama + " kom");
            Console.WriteLine("Popust: " + Popust + "%");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Igra[] ponuda = new Igra[5];
            ponuda[0] = new DigitalnaIgra("Ghost of Yotei", 4500, 2025, "PS5", 85);
            ponuda[1] = new FizicikaIgra("Cyberpank", 7000, 2022, 10, 20);
            ponuda[2] = new DigitalnaIgra("SpiderMan", 2500, 2023, "PS5", 90);
            ponuda[3] = new FizicikaIgra("God of War", 4500, 2018, 10, 40);
            ponuda[4] = new DigitalnaIgra("Minecraft", 2000, 2020, "PS5", 15);

            while (true)
            {
                Console.WriteLine("\nGameCentar");
                Console.WriteLine("1. Prikaz podatke o igrama");
                Console.WriteLine("2. Prodaj video igru");
                Console.WriteLine("3. Najskuplja video igra");
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
                    case 1: PrikaziSveIgre(ponuda); break;
                    case 2: ProdajIgru(ponuda); break;
                    case 3: NajskupljaIgra(ponuda); break;
                    case 4: IgreSaPopustom(ponuda); break;
                    case 5: DigitalneZahteveIgre(ponuda); break;
                    case 6: UkupanPrihodProdaje(ponuda); break;
                    case 0:
                        Console.WriteLine("Kraj programa..."); return;
                    default:
                        Console.WriteLine("Nepoznata opcija."); break;
                }
            }
        }

        private static void PrikaziSveIgre(Igra[] ponuda)
        {
            Console.Clear();
            Console.WriteLine("\n===Nasa ponuda===");
            for (int i = 0; i < ponuda.Length; i++)
            {
                if (ponuda[i] != null)
                {
                    ponuda[i].PrikaziInformacije();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }

        private static void ProdajIgru(Igra[] ponuda)
        {
            Console.Clear();
            Console.Write("Unesite index igre za prodaju: ");
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Greska! Morate uneti broj");
                return;
            }

            if (index >= 0 && index < ponuda.Length && ponuda[index] != null)
            {
                ponuda[index].ProdajIgru(ponuda, index);
            }
            else
            {
                Console.WriteLine("Nevazeci index za igru.");
            }
        }

        private static void NajskupljaIgra(Igra[] ponuda)
        {
            Console.Clear();
            double maxCena = -1;
            Igra najskuplja = null;

            foreach (Igra i in ponuda)
            {
                if (i != null && i.VratiCenu() > maxCena)
                {
                    maxCena = i.VratiCenu();
                    najskuplja = i;
                }
            }
            if (najskuplja != null)
            {
                Console.WriteLine("===Najskuplja igra===");
                najskuplja.PrikaziInformacije();
            }
            else
            {
                Console.WriteLine("Nema dostupnih igara u ponudi.");
            }
        }

        private static void IgreSaPopustom(Igra[] ponuda)
        {
            Console.Clear();
            Console.WriteLine("===Igre sa popustom===");
            foreach (Igra i in ponuda)
            {
                if (i is FizicikaIgra fiz && fiz.imaPopust())
                {
                    fiz.PrikaziInformacije();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }

        private static void DigitalneZahteveIgre(Igra[] ponuda)
        {
            Console.Clear();
            Console.WriteLine("===Igre sa zahtevnom konfiguracijom===");
            foreach (Igra i in ponuda)
            {
                if (i is DigitalnaIgra dig && dig.ZahtevaJakuKonfiguraciju())
                {
                    dig.PrikaziInformacije();
                    Console.WriteLine(new string('-', 25));
                }
            }
        }

        private static void UkupanPrihodProdaje(Igra[] ponuda)
        {
            Console.Clear();
            Console.WriteLine("===Ukupan prihod prodaje===");
            double ukupnaSuma = 0;
            foreach (Igra i in ponuda)
            {
                if (i != null)
                {
                    ukupnaSuma += i.IzracunajPrihod();

                }
            }
            Console.WriteLine("Ukupan prihod prodaje: " + ukupnaSuma + " dinara");
        }
    }

}
