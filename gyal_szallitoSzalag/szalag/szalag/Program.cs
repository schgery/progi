namespace szalag
{
    internal class Program
    {
        public struct szal
        {
            public int ido, honnan, hova,tomeg;
        }
        static int osszhossz, idoegyseg;
        static szal[] tomb;
        static void Main(string[] args)
        {
            beolvas();
            f(2);
            Console.Write("Adja meg, melyik adatsorra kíváncsi! ");
            int bekertszam = int.Parse(Console.ReadLine());
            Console.WriteLine($"Honnan: {tomb[bekertszam-1].honnan} Hova: {tomb[bekertszam - 1].hova}");
            Console.WriteLine();
            f(4);
            fel4();
            f(4);
            fel5();
            

        }
        static void f(int a) { Console.WriteLine($"{a}. feladat"); }
        static void beolvas()
        {
            FileStream fs = new FileStream("szallit.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] temp = sr.ReadLine().Split(" ");
            osszhossz = int.Parse(temp[0]);
            idoegyseg = int.Parse(temp[1]);
            tomb = new szal[1000];
            int index = 0;
            while (!sr.EndOfStream) 
            {
                string[] sor = sr.ReadLine().Split(" ");
                tomb[index].ido = int.Parse(sor[0]);
                tomb[index].honnan = int.Parse(sor[1]);
                tomb[index].hova = int.Parse(sor[2]);
                tomb[index++].tomeg = int.Parse(sor[3]);
            }   
            Array.Resize(ref tomb, index);
        }
        static int tav(int szalaghossz,int indulashelye,int erkezeshelye)
        {
            if (indulashelye < erkezeshelye)
                return erkezeshelye - indulashelye;
            else
            {
                return szalaghossz-indulashelye+erkezeshelye;
            }
        }
        static void fel4()
        {
            int legg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tav(osszhossz, tomb[i].honnan, tomb[i].hova) > legg) 
                {
                    legg = tav(osszhossz, tomb[i].honnan, tomb[i].hova);
                }
            }
            Console.WriteLine($"A legnagyobb távolság: { legg} ");
            for (int i = 0; i < tomb.Length; i++)
            {
                if(tav(osszhossz, tomb[i].honnan, tomb[i].hova)==legg)
                    Console.WriteLine($"A maximális távolságú szállítások sorszáma: {tomb[i].honnan} {tomb[i].hova}");
            }
        }
        static void fel5()
        {
            int ossz=0;
            foreach (szal i in tomb)
            {
                if (i.hova < i.honnan) ossz += i.tomeg;
            }
            Console.WriteLine($"A kezdőpont előtt elhaladó rekeszek össztömege: {ossz}");
        }
    }
}
