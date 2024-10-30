using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaujasProjektas2024_10_30.Projektai.Core.Models
{
    public class Projektas
    {
        public int ProjektoID { get; set; }
        public string ProjektoPavadinimas { get; set; }
        public string VadovoVardas { get; set; }
        public double Biudzetas { get; set; }
        public DateTime PradziosData { get; set; }
        public DateTime PabaigosData { get; set; }

        public Projektas(int projektoID, string projektoPav, string vadovoVardas, double biudzetas, DateTime pradziosData, DateTime pabaigosData)
        {
            ProjektoID = projektoID;
            ProjektoPavadinimas = projektoPav;
            VadovoVardas = vadovoVardas;
            Biudzetas = biudzetas;
            PradziosData = pradziosData;
            PabaigosData = pabaigosData;
        }
        public Projektas()
        {

        }
        public override string ToString()
        {

            return $"{ProjektoID}; {ProjektoPavadinimas}; {Biudzetas}; {PradziosData}; {PabaigosData}";
        }
    }
}
