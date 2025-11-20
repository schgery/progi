namespace telekes
{
    internal class Program
    {
        static List<telek> telkek;
        static string[] fejlec;
        static void Main(string[] args)
        {
            telkek = new List<telek>();
            beolvasas();
            Console.WriteLine($"2. feladat. A mintában {telkek.Count} telek szerepel.");
            Console.Write("3. feladat. Egy tulajdonos adószáma: ");
            string bekertszam = Console.ReadLine();
            List<telek> sajattelkek = (from t in telkek
                                      where t.adoszam == bekertszam
                                      select t).ToList();
            if(sajattelkek.Count>0)
                foreach (var item in sajattelkek)
                {
                    Console.WriteLine($"{item.utca} utca {item.hazszam}");
                }
            else Console.WriteLine("Nem szerepel az adatállományban.");  

        }
        static void beolvasas() 
        {
            FileStream fs = new FileStream("utca.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            fejlec = sr.ReadLine().Split(" ");
            telek.adosavok[0] = int.Parse(fejlec[0]);
            telek.adosavok[1] = int.Parse(fejlec[1]);
            telek.adosavok[2] = int.Parse(fejlec[2]);
            while (!sr.EndOfStream) 
            {
                string[] sor = sr.ReadLine().Split(" ");
                telkek.Add(new telek(sor[0], sor[1], sor[2], sor[3], sor[4]));
            }
            sr.Close();
            fs.Close();
        }
    }
}
