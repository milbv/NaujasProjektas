using NaujasProjektas2024_10_30.Projektai.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NaujasProjektas2024_10_30.Projektai.Core.Repositories
{
    public class FileRepository
    {
        private string _fileLocation;
        public FileRepository(string fileLocation)
        {
            _fileLocation = fileLocation;
        }
        public List<Projektas> GautiVisusProjektus()
        {
            List<Projektas> projektai = new List<Projektas>();
            using(StreamReader sr = new StreamReader(_fileLocation))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if(string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    string[] foo = line.Split(",");
                    projektai.Add(new Projektas(int.Parse(foo[0]), foo[1], foo[2], double.Parse(foo[3], CultureInfo.InvariantCulture), DateTime.Parse(foo[4]), DateTime.Parse(foo[5])));
                }
            }
            return projektai;
        }
        public void RasytiKlientusIFaila(List<Projektas> projektai)
        {
            using(StreamWriter sw = new StreamWriter(_fileLocation))
            {
                foreach(Projektas p in projektai)
                {
                    sw.WriteLine($"{p.ProjektoID},{p.ProjektoPavadinimas},{p.Biudzetas},{p.PradziosData},{p.PabaigosData}");
                }
                sw.Close();
            }
        }
    }
}
