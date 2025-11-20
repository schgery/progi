using System.Globalization;

namespace kosarlabda
{
    internal class Program
    {
        static List<kosar> lista;
        static void Main(string[] args)
        {
            lista = new List<kosar>();
            beolvasas();
            f(3);
            Console.WriteLine($"Real Madrid hazai: {lista.Where(i => i.hazai== "Real Madrid").Count()} " +
                $"idegen: {lista.Where(i => i.idegen == "Real Madrid").Count()}");
            f(4);
            Console.Write("volt döntetlen? ");
            if (lista.Where(i => i.idegen_pont == i.hazai_pont).Any()) Console.WriteLine("igen");
            else Console.WriteLine("nem");
            f(5);
            List<kosar> nemtom = lista.Where(i => i.hazai.Contains("Barcelona")).ToList();
            Console.WriteLine($"barcelanai csapat neve: {nemtom[0].hazai}");
            f(6);
            Console.WriteLine();
            List<kosar> nemtom1 = lista.Where(i=>i.idopont== "2004-11-21").ToList();
            foreach (var item in nemtom1)
            {
                Console.WriteLine($"\t{item.hazai} {item.idegen} ({item.hazai_pont}:{item.idegen_pont})");
            }
            f(7);
            Console.WriteLine();
            HashSet<string> set = new HashSet<string>();
            foreach (var item in lista) 
                set.Add(item.helyszin);
            Dictionary<string,int> dic = new Dictionary<string,int>();
            foreach (var item in set)
            {
                int random = lista.Where(i => i.helyszin == item).Count();
                if (random > 20) dic[item] = random;
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"\t {item.Key}: {item.Value}");
            }
        }
        static void f(int a)
        { Console.Write($"{a}.feladat: "); }
        static void beolvasas()
        {
            FileStream fs = new FileStream("eredmenyek.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();
            while (!sr.EndOfStream) 
            {
                lista.Add(new kosar(sr.ReadLine()));
            }
            sr.Close();
            fs.Close();
        }
    }
}
