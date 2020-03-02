using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getrank
{
    class Automat
    {
        public int anzahlWasser;
        public int anzahlCola;
        public int anzahlBier;
        public string name;
        public string extra;
        public List<Getränk> listeee;
        
        public Automat()
        {
            Console.WriteLine("Was möchten Sie kaufen ?");
            Console.WriteLine("1) Wasser \t\t 0,5 Euro ");
            Console.WriteLine("2) Cola \t\t 1 Euro");
            Console.WriteLine("3) Bier \t\t 2 Euro");
            strich();
        }

        public List<Getränk> Auswahl()
        {
            List<Getränk> liste = new List<Getränk>();
            start:
            do
            {
                Console.WriteLine("Geben Sie angehörige Nummer ein");
                int nummer = Convert.ToInt16(Console.ReadLine());
                strich();

                switch (nummer)
                {                                          
                    case 1:

                        Console.WriteLine("Wie viel möchten Sie kaufen ?");
                        try
                        {
                            anzahlWasser = Convert.ToInt16(Console.ReadLine());
                        strich();

                        for (int i = 1; i <= anzahlWasser; i++)
                        {
                            liste.Add(new Getränk { Name = "Wasser", Preis = 0.5 });
                        }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Sie dürfen mindestens eine maximal 1000 Getränke kaufen!");
                            
                        }
                        break;

                    case 2:
                        Console.WriteLine("Wie viel möchten Sie kaufen ?");
                        try
                        {

                        
                        anzahlCola = Convert.ToInt16(Console.ReadLine());
                        strich();

                        for (int i = 1; i <= anzahlCola; i++)
                        {
                            liste.Add(new Getränk { Name = "Cola", Preis = 1 });
                            name = "Cola";
                        }
                        }
                        catch (Exception )
                        {
                            Console.WriteLine("Sie dürfen mindestens eine maximal 1000 Getränke kaufen!");
                            throw;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Wie viel möchten Sie kaufen ?");
                        try
                        {

                        
                        anzahlBier = Convert.ToInt16(Console.ReadLine());
                        strich();

                        for (int i = 1; i <= anzahlBier; i++)
                        {
                            liste.Add(new Getränk { Name = "Bier", Preis = 2 });
                            name = "Bier";
                        }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Sie dürfen mindestens eine maximal 1000 Getränke kaufen!");
                            throw;
                        }
                        break;

                    default:
                        Console.WriteLine("Es wurde falsche Nummer eingetragen");
                        strich();
                        goto start;                                               
                }
                
                Console.WriteLine("Möchten Sie ncoh was kaufen? (j/n)");
                extra = Console.ReadLine();
                if ((extra != "j") && extra != "n")
                {
                    Console.WriteLine("Sie sollen entweder \"j\" oder \"n\" eingeben!");
                    strich();
                    goto start;
                }
                

            } while (extra == "j");
            listeee = liste;
            return liste;



        }

        public double EndPreisBerechnung(List<Getränk> list)
        {
            double summe = 0;
            foreach (Getränk item in list)
            {
                summe += item.Preis;
            }
            Console.WriteLine("Es kostet {0} Euro", summe);
            return summe;
        }


        public void Ausgabe(List<Getränk> list)
        {
            bool wasser = false;
            bool cola = false;
            bool bier = false;
            foreach (Getränk item in list)
            {
                if (item.Name == "Wasser")
                {
                    
                    wasser = true;
                }

                else if (item.Name == "Cola")
                {
                    
                    cola = true;
                }

                else if (item.Name == "Bier")
                {
                    bier = true;
                    
                }
            }

            if (wasser == true)
            {
                Console.WriteLine("Es werden {0} Wasser ausgegeben", anzahlWasser);
            }

            if (cola == true)
            {
                Console.WriteLine("Es werden {0} Cola ausgegeben", anzahlCola);
            }

            if (bier == true)
            {
                Console.WriteLine("Es werden {0} Bier ausgegeben", anzahlBier);
            }
            
        }

        public double Bezahlung(double summee , List<Getränk>list)
        {
            Console.WriteLine("Werfen Sie das geld ein");
            double geld = double.Parse(Console.ReadLine());
            strich();
            if (geld < summee)
            {
                while (geld < summee)
                {
                    Console.WriteLine("Sie haben {0} Euro gezahlt, zahlen Sie noch Euro", geld, summee - geld);
                    double geld2 = double.Parse(Console.ReadLine());
                    geld += geld2;
                    strich();
                }
                if (geld > summee)
                {
                    Console.WriteLine("Sie erhalten {0} Euro Zurück", Math.Abs(summee - geld));
                    strich();
                    Ausgabe(list);
                }
                else
                {
                    Ausgabe(list);
                }
            }

            else if (geld == summee)
            {
                Ausgabe(list);
            }

            else if (geld > summee)
            {
                summee -= geld;
                Console.WriteLine("Sie erhalten {0} Euro Zurück", Math.Abs(summee));
                Ausgabe(list);
                strich();
            }

            return 0;
        }






        public void strich()
        {
            Console.WriteLine("----------------------------------");
        }

    }
}
