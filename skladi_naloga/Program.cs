using System;
using Ini;
using System.IO;

namespace skladi_naloga
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spremenite pot do vaše settings.ini datoteke.

            //  primer moje settings.ini datoteke.

            //  [NASTAVITVE]
            //  IZVOR="C:\Users\Matjaž\Desktop\Datoteke"
            //  PONOR="C:\Users\Matjaž\Desktop\kopirane"
            //  MESEC="4"
            //  LETO="2016"

            string potDoDatoteke = @"C:\Users\Matjaž\Desktop\settings.ini";

            IniFile settings = new IniFile(potDoDatoteke);
            int prenesenihDatotek = 0;

            string IZVOR = settings.IniReadValue("NASTAVITVE", "IZVOR");
            string PONOR = settings.IniReadValue("NASTAVITVE", "PONOR") + "\\";
            string mesec = settings.IniReadValue("NASTAVITVE", "mesec");
            string leto = settings.IniReadValue("NASTAVITVE", "leto");

            string[] vseDatoteke = Directory.GetFiles(IZVOR, "*.*", SearchOption.AllDirectories);

            foreach (string datoteka in vseDatoteke)
            {
                DateTime zadnjicSpremenjeno = File.GetLastWriteTime(datoteka);
                if (zadnjicSpremenjeno.Year == Convert.ToInt32(leto) && zadnjicSpremenjeno.Month == Convert.ToInt32(mesec))
                {
                    File.Copy(datoteka, PONOR + Path.GetFileName(datoteka));
                    prenesenihDatotek++;
                }
            }
            Console.WriteLine("V {0} je bilo prenesenih {1} datotek", PONOR, prenesenihDatotek );
        }
    }
}