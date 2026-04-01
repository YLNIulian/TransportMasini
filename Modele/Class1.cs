using System;

namespace Modele
{
    public enum Culoare
    {
        Rosu, Alb, Negru
    }

    [Flags]
    public enum Optiuni
    {
        Niciuna = 0,
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4
    }

    public class Sofer
    {
        public string? Nume { get; set; }
        public string? Id { get; set; }
    }

    public class Masina
    {
        public string? Numar { get; set; }
        public double Km { get; set; }
        public Culoare CuloareMasina { get; set; }
        public Optiuni OptiuniMasina { get; set; }
    }

    public class Traseu
    {
        public Sofer? Soferul { get; set; }
        public Masina? Masina { get; set; }
        public string? Ruta { get; set; }
        public double Distanta { get; set; }
    }
}