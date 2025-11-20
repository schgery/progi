using System.Text;

namespace sorozatok
{
    internal class Program
    {
             
        static List<Sorozat> li;
        
        static void Main(string[] args)
        {
            beolvasas();
            Console.WriteLine("2. feladat");
            int nnnnn = 0;
            foreach (Sorozat s in li) 
            {
                if (s.Datum != null) nnnnn++;
            }
            Console.WriteLine($"A listában {nnnnn} db vetítési dátummal rendelkező epizód van.");
            Console.WriteLine("\n3. feladat");
            double f3 = 0;
            foreach (Sorozat s in li)
            {
                if (s.Latta == true) f3++;
            }
            Console.WriteLine($"A listában lévő epizódok  {Math.Round(f3 / li.Count*100,2)}% -át látta.");  
            int mennyi = 0;
            foreach (Sorozat s in li)
            {

                if (s.Latta == true) mennyi += s.Hossz;
            }
            Console.WriteLine("\n4. feladat");
            Console.WriteLine($"Sorozatnézéssel {mennyi/3600} napot {mennyi%3600/60} órát és {mennyi%3600%60} percet töltött.");
       
            Console.WriteLine("\n5. feladat");
            Console.Write("Adjon meg egy dátumot! Dátum= ");
            DateOnly bekertdatum = DateOnly.Parse(Console.ReadLine());
            foreach (Sorozat s in li)
            {
                if (s.Latta == false && s.Datum != null && bekertdatum >= s.Datum)
                {
                    Console.WriteLine($"{s.Epizod}\t{s.Nev}");
                }
            }




        }
        static void beolvasas() 
        {
            FileStream fs = new FileStream("lista.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            li = new List<Sorozat>();
            while (!sr.EndOfStream) 
            {
                li.Add(new Sorozat(
                    sr.ReadLine(), sr.ReadLine(),
                    sr.ReadLine(), sr.ReadLine(),
                    sr.ReadLine()
                    ));
            }
            sr.Close();
            fs.Close();
        }
    }
}
