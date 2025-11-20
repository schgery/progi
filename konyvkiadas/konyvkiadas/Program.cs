namespace konyvkiadas
{
    internal class Program
    {
        static List<konyv> lista;
        static void Main(string[] args)
        {
            lista = new List<konyv>();
            beolvasas();
            Console.WriteLine(lista.Count);
            Console.Write("Szerző: ");
            string bekertadat = Console.ReadLine();
            int nemtom = lista.Where(x => x.nev.Contains(bekertadat)).Count();
            if (nemtom > 0)
                Console.WriteLine($"{nemtom} könyvkiadás");
            else Console.WriteLine("Nem adtak ki");

            int szam = lista.Max(y => y.kiadas);
            int szamszam = lista.Where(x => x.kiadas == szam).Count();
            Console.WriteLine($"Legnagyobb példányszám: {szam}, előfordult {szamszam} alkalommal");

            konyv elso = lista.FirstOrDefault(x => x.kiadas > 40000 && x.szaramazas == "kf");
            Console.WriteLine($"{elso.ev}/{elso.negyedev}. {elso.nev}");

            Dictionary<int, int[]> dic = new Dictionary<int, int[]>();
            for (int i = 0; i < 4; i++)
            {
                int ev = 2020 + i;
                dic[ev] = new int[4];
                dic[ev][0] = lista.Where(x => x.szaramazas == "ma" && x.ev == ev).Count();
                dic[ev][1] = lista.Where(x => x.szaramazas == "ma" && x.ev == ev).Sum(x => x.kiadas);
                dic[ev][2] = lista.Where(x => x.szaramazas == "kf" && x.ev == ev).Count();
                dic[ev][3] = lista.Where(x => x.szaramazas == "kf" && x.ev == ev).Sum(x => x.kiadas);
            }
            Console.WriteLine("Év\tMagyar kiadás\t" +
                "Magyar példányszám\t" +
                "Külföldi kiadás\tKülföldi példányszám");
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key}\t\t{item.Value[0]}\t\t{item.Value[1]}" +
                    $"\t\t{item.Value[2]}\t\t{item.Value[3]}");
            }
        }
        static void beolvasas()
        {
            foreach (string sor in File.ReadAllLines("kiadas.txt").ToList())
            {
                string[] a = sor.Split(';');
                lista.Add(new konyv(
                    int.Parse(a[0]), int.Parse(a[1]),
                    a[2], a[3], int.Parse(a[4])
                    ));
            }
        }

    }
}
