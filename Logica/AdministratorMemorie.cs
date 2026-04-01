using System;
using System.Collections.Generic;
using System.Linq;
using Modele;

namespace Logica
{
    public class AdministratorMemorie
    {
        public List<Sofer> soferi = new List<Sofer>();
        public List<Masina> masini = new List<Masina>();
        public List<Traseu> trasee = new List<Traseu>();

        public void AdaugaSofer(Sofer s)
        {
            soferi.Add(s);
        }

        public void AdaugaMasina(Masina m)
        {
            masini.Add(m);
        }

        public void AdaugaTraseu(Traseu t)
        {
            trasee.Add(t);
        }

        public List<Sofer> GetSoferi()
        {
            return soferi;
        }

        public List<Masina> GetMasini()
        {
            return masini;
        }

        public List<Traseu> CautaTraseeDupaSofer(string nume)
        {
            return trasee.Where(t => t.Soferul?.Nume == nume).ToList();
        }

        public Sofer? CautaSofer(string nume)
        {
            return soferi.FirstOrDefault(s => s.Nume == nume);
        }

        public Masina? CautaMasina(string numar)
        {
            return masini.FirstOrDefault(m => m.Numar == numar);
        }

        public List<Traseu> GetToateTraseele()
        {
            return trasee;
        }
    }
}