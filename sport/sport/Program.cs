namespace sport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sport a1 = new Sport("foci", "Kony SE", "Csorna SE") 
            { Hfelido = 2, Vfelido = 0, Hveg = 3, Vveg = 1 };

            Sport a2 = new Sport("foci", "Beled SE", "csorna SE")
            { Hfelido = 0, Vfelido = 2, Hveg = 3, Vveg = 3 };

            Sport a3 = new Sport("foci", "Kony SE", "Beled SE")
            { Hfelido = 1, Vfelido = 3, Hveg = 12, Vveg = 3 };

            Sport a4 = new Sport("foci", "Kony SE", "Papa SE")
            { Hfelido = 0, Vfelido = 4, Hveg = 3, Vveg = 5 };
        }
    }
}
