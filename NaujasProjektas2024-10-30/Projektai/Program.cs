using NaujasProjektas2024_10_30.Projektai.Core.Models;
using NaujasProjektas2024_10_30.Projektai.Core.Repositories;
using System;

namespace NaujasProjektas2024_10_30.Projektai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Meniu();
        }
        public static void Meniu()
        {
            FileRepository fr = new FileRepository("projektai.txt");
            List<Projektas> visiProjektai = fr.GautiVisusProjektus();
            bool running = false;
            while(!running)
            {
                Console.WriteLine("Pasirinkite meniu elementa:\n1. Perziureti visus projektus\n2. Perziureti projekta pagal ID\n3. Prideti nauja projekta\n4. Istrinti projekta pagal ID\n5. Issaugoti visus pakeitimus i faila");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Perziureti visus projektus");
                        for (int i = 0; i < visiProjektai.Count; i++)
                        {
                            Console.WriteLine(visiProjektai[i].ToString());
                        }
                        break;
                    case 2:
                        Console.WriteLine("Perziureti projekta pagal ID");
                        visiProjektai.Sort((p1, p2) => { return p1.ProjektoID - p2.ProjektoID; });
                        for (int i = 0; i < visiProjektai.Count; i++)
                        {
                            Console.WriteLine(visiProjektai[i].ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("Prideti nauja projekta");
                        Console.WriteLine("Iveskite projektoID");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Projekto pavadinimas");
                        string pav = Console.ReadLine();
                        Console.WriteLine("vardas");
                        string vardas = Console.ReadLine();
                        Console.WriteLine("Biudzetas");
                        double biudzetas = double.Parse(Console.ReadLine());
                        Console.WriteLine("Pradzios data");
                        DateTime pradzia = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Pabaigos data");
                        DateTime pabaiga = DateTime.Parse(Console.ReadLine());

                        visiProjektai.Add(new Projektas(id, pav, vardas, biudzetas, pradzia, pabaiga));
                        break;
                    case 4:
                        Console.WriteLine("Istrinti projekta pagal ID");
                        Console.WriteLine("irasykite projekto ID, kuri norite pasalinti");
                        int projektoID = int.Parse(Console.ReadLine());
                        Projektas ieskomasProjektas =  visiProjektai.Find((p) => p.ProjektoID == projektoID);
                        if (ieskomasProjektas != null)
                        {
                            visiProjektai.Remove(ieskomasProjektas);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Issaugoti visus pakeitimus i faila");
                        fr.RasytiKlientusIFaila(visiProjektai);
                        break;
                    default:
                        running = true;
                        break;
                }
            }
        }
    }
}
