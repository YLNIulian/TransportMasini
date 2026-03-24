using System;
using System.Collections.Generic;

namespace TransportMasini
{
    class Sofer
    {
        public string Nume { get; set; }
        public string Id { get; set; }
    }

    class Masina
    {
        public string Numar { get; set; }
        public double Km { get; set; }
    }

    class Traseu
    {
        public Sofer Soferul { get; set; }
        public Masina Masina { get; set; }
        public string Ruta { get; set; }
        public double Distanta { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Sofer> soferi = new List<Sofer>();
            List<Masina> masini = new List<Masina>();
            List<Traseu> trasee = new List<Traseu>();

            while (true)
            {
                Console.WriteLine("\n1. Adauga sofer");
                Console.WriteLine("2. Adauga masina");
                Console.WriteLine("3. Adauga traseu");
                Console.WriteLine("4. Afiseaza toate traseele");
                Console.WriteLine("5. Cauta trasee dupa sofer");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                if (optiune == "1")
                {
                    Sofer s = new Sofer();
                    Console.Write("Nume sofer: ");
                    s.Nume = Console.ReadLine();
                    Console.Write("ID sofer: ");
                    s.Id = Console.ReadLine();
                    soferi.Add(s);
                }
                else if (optiune == "2")
                {
                    Masina m = new Masina();
                    Console.Write("Numar inmatriculare: ");
                    m.Numar = Console.ReadLine();
                    Console.Write("Kilometri initiali: ");
                    m.Km = Convert.ToDouble(Console.ReadLine());
                    masini.Add(m);
                }
                else if (optiune == "3")
                {
                    Console.Write("Numele soferului: ");
                    string numeSofer = Console.ReadLine();
                    Sofer soferGasit = null;

                    foreach (Sofer s in soferi)
                    {
                        if (s.Nume == numeSofer)
                        {
                            soferGasit = s;
                        }
                    }

                    Console.Write("Numarul masinii: ");
                    string numarMasina = Console.ReadLine();
                    Masina masinaGasita = null;

                    foreach (Masina m in masini)
                    {
                        if (m.Numar == numarMasina)
                        {
                            masinaGasita = m;
                        }
                    }

                    if (soferGasit != null && masinaGasita != null)
                    {
                        Traseu t = new Traseu();
                        t.Soferul = soferGasit;
                        t.Masina = masinaGasita;

                        Console.Write("Ruta: ");
                        t.Ruta = Console.ReadLine();
                        Console.Write("Distanta parcursa (km): ");
                        t.Distanta = Convert.ToDouble(Console.ReadLine());

                        masinaGasita.Km = masinaGasita.Km + t.Distanta;
                        trasee.Add(t);
                    }
                    else
                    {
                        Console.WriteLine("Soferul sau masina nu a fost gasita in sistem.");
                    }
                }
                else if (optiune == "4")
                {
                    foreach (Traseu t in trasee)
                    {
                        Console.WriteLine(t.Soferul.Nume + " a condus " + t.Masina.Numar + " pe ruta " + t.Ruta + ". Distanta: " + t.Distanta + " km. Masina are acum " + t.Masina.Km + " km.");
                    }
                }
                else if (optiune == "5")
                {
                    Console.Write("Introdu numele soferului pentru cautare: ");
                    string numeCautat = Console.ReadLine();
                    int gasite = 0;

                    foreach (Traseu t in trasee)
                    {
                        if (t.Soferul.Nume == numeCautat)
                        {
                            Console.WriteLine("Ruta: " + t.Ruta + " | Masina: " + t.Masina.Numar + " | Distanta: " + t.Distanta + " km");
                            gasite++;
                        }
                    }

                    if (gasite == 0)
                    {
                        Console.WriteLine("Nu s-au gasit trasee pentru acest sofer.");
                    }
                }
                else if (optiune == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Optiune gresita!");
                }
            }
        }
    }
}