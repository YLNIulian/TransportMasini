using System;
using Modele;
using Logica;

namespace TransportMasini
{
    class Program
    {
        static void Main(string[] args)
        {
            AdministratorMemorie admin = new AdministratorMemorie();

            while (true)
            {
                Console.WriteLine("\n=== Meniu ===");
                Console.WriteLine("1. Adauga sofer");
                Console.WriteLine("2. Adauga masina");
                Console.WriteLine("3. Adauga traseu");
                Console.WriteLine("4. Afiseaza toate traseele");
                Console.WriteLine("5. Cauta trasee dupa sofer (LINQ)");
                Console.WriteLine("6. Afiseaza toti soferii");
                Console.WriteLine("7. Afiseaza toate masinile");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine() ?? "";

                if (optiune == "1")
                {
                    Sofer s = new Sofer();
                    Console.Write("Nume sofer: ");
                    s.Nume = Console.ReadLine() ?? "";
                    Console.Write("ID sofer: ");
                    s.Id = Console.ReadLine() ?? "";
                    admin.AdaugaSofer(s);
                }
                else if (optiune == "2")
                {
                    Masina m = new Masina();
                    Console.Write("Numar inmatriculare: ");
                    m.Numar = Console.ReadLine() ?? "";
                    Console.Write("Kilometri initiali: ");
                    m.Km = Convert.ToDouble(Console.ReadLine() ?? "0");

                    Console.Write("Culoare (0=Rosu,1=Alb,2=Negru): ");
                    int indexCuloare = Convert.ToInt32(Console.ReadLine() ?? "0");
                    m.CuloareMasina = (Culoare)indexCuloare;

                    m.OptiuniMasina = Optiuni.AerConditionat | Optiuni.Navigatie;
                    admin.AdaugaMasina(m);
                }
                else if (optiune == "3")
                {
                    Console.Write("Numele soferului: ");
                    string numeSofer = Console.ReadLine() ?? "";
                    Sofer? soferGasit = admin.CautaSofer(numeSofer);

                    Console.Write("Numarul masinii: ");
                    string numarMasina = Console.ReadLine() ?? "";
                    Masina? masinaGasita = admin.CautaMasina(numarMasina);

                    if (soferGasit != null && masinaGasita != null)
                    {
                        Traseu t = new Traseu();
                        t.Soferul = soferGasit;
                        t.Masina = masinaGasita;

                        Console.Write("Ruta: ");
                        t.Ruta = Console.ReadLine() ?? "";
                        Console.Write("Distanta parcursa (km): ");
                        t.Distanta = Convert.ToDouble(Console.ReadLine() ?? "0");

                        masinaGasita.Km = masinaGasita.Km + t.Distanta;
                        admin.AdaugaTraseu(t);
                    }
                    else
                    {
                        Console.WriteLine("Soferul sau masina nu a fost gasita!");
                    }
                }
                else if (optiune == "4")
                {
                    var toateTraseele = admin.GetToateTraseele();
                    foreach (Traseu t in toateTraseele)
                    {
                        Console.WriteLine(t.Soferul?.Nume + " a condus " + t.Masina?.Numar + " pe ruta " + t.Ruta);
                    }
                }
                else if (optiune == "5")
                {
                    Console.Write("Introdu numele soferului: ");
                    string numeCautat = Console.ReadLine() ?? "";

                    var traseeGasite = admin.CautaTraseeDupaSofer(numeCautat);

                    if (traseeGasite.Count == 0)
                    {
                        Console.WriteLine("Nu s-au gasit trasee.");
                    }
                    else
                    {
                        foreach (Traseu t in traseeGasite)
                        {
                            Console.WriteLine("Ruta: " + t.Ruta + " | Masina: " + t.Masina?.Numar);
                        }
                    }
                }
                else if (optiune == "6")
                {
                    Console.WriteLine("\n--- Lista Soferi ---");
                    var listaSoferi = admin.GetSoferi();
                    if (listaSoferi.Count == 0)
                    {
                        Console.WriteLine("Nu exista soferi inregistrati.");
                    }
                    else
                    {
                        foreach (var s in listaSoferi)
                        {
                            Console.WriteLine("Nume: " + s.Nume + " | ID: " + s.Id);
                        }
                    }
                }
                else if (optiune == "7")
                {
                    Console.WriteLine("\n--- Lista Masini ---");
                    var listaMasini = admin.GetMasini();
                    if (listaMasini.Count == 0)
                    {
                        Console.WriteLine("Nu exista masini inregistrate.");
                    }
                    else
                    {
                        foreach (var m in listaMasini)
                        {
                            Console.WriteLine("Nr: " + m.Numar + " | Km: " + m.Km + " | Culoare: " + m.CuloareMasina + " | Optiuni: " + m.OptiuniMasina);
                        }
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