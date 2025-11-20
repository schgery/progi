using Microsoft.VisualBasic;

namespace meteor
{
    internal class Program
    {
        public struct adat 
        {
            public string nev,ido,iranyer;
            public int homer;
        }
        static adat[] adatok;
        static void Main(string[] args)
        {
            beolvasvas();
            f(2);
            Console.Write("Adja meg egy település kódját! Település: ");
            string bekert = Console.ReadLine();
            fel2(bekert);
            f(3);
            fel3();
            f(4);
            fel4();
            f(5);
            fel5();
            f(6);
            fel6();
        }
        static void f(int a) 
        {
            Console.WriteLine($"{a}. feladat"); 
        }
        static void beolvasvas()
        {
            FileStream fs = new FileStream("tavirathu13.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int index = 0;
            adatok = new adat[500];
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(" ");
                adatok[index].nev = sor[0];
                adatok[index].ido = sor[1];
                adatok[index].iranyer = sor[2];
                adatok[index++].homer = int.Parse(sor[3]);
            }
            sr.Close();
            fs.Close();
            Array.Resize(ref adatok, index);
        }
        static void fel2(string bekert)
        {
            int temp=0;
            for (int i = adatok.Length - 1; i >= 0; i--)
            {
                if (adatok[i].nev==bekert)
                { 
                    temp = i;
                    break;
                }
            }
            Console.WriteLine($"Az utolsó mérési adat a megadott településről " +
                $"{adatok[temp].ido.Substring(0, 2)}:{adatok[temp].ido.Substring(2, 2)}-kor érkezett.");
        }
        static void fel3()
        {
            int min = adatok[0].homer;
            int minindex = 0;
            int max = adatok[0].homer;
            int maxindex = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].homer < min) 
                {
                    min = adatok[i].homer;
                    minindex = i;
                }
                if (adatok[i].homer > max)
                {
                    max = adatok[i].homer;
                    maxindex = i;
                }
            }
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {adatok[minindex].nev} " +
                $"{adatok[minindex].ido.Substring(0, 2)}:{adatok[minindex].ido.Substring(2, 2)} " +
                $"{adatok[minindex].homer} fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {adatok[maxindex].nev} " +
                $"{adatok[maxindex].ido.Substring(0, 2)}:{adatok[maxindex].ido.Substring(2, 2)} " +
                $"{adatok[maxindex].homer} fok.");
        }
        static void fel4()
        {
            int volt = 0;
            foreach (var item in adatok)
            {
                if (item.iranyer == "00000") { 
                    Console.WriteLine($"{item.nev} {item.ido.Substring(0, 2)}:{item.ido.Substring(2, 2)}");
                    volt++; 
                }
            }
            if (volt == 0)
            { Console.WriteLine("Nem volt szélcsend a mérések idején."); }
        }
        static void fel5()
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var item in adatok)
            {
                set.Add(item.nev);
            }
            foreach (var item in set)
            {
                Console.WriteLine($"{item} {(nevkozep(item))}; Hőmérséklet-ingadozás: {nevmax(item)-nevmin(item)}");
            }
        }
        static int nevmin(string nev)
        {
            int mins = int.MaxValue;
            foreach (var item in adatok)
            {
                if(item.nev==nev && mins>item.homer)
                    mins = item.homer;
            }
            return mins;
        }
        static int nevmax(string nev)
        {
            int maxs = int.MinValue;
            foreach (var item in adatok)
            {
                if (item.nev == nev && maxs < item.homer)
                    maxs = item.homer;
            }
            return maxs;
        }
        static string nevkozep(string nev)
        {
            double hok = 0;
            double hodb = 0;
            bool egy = false;
            bool het = false;
            bool tizenharom = false;
            bool tizenkilenc = false;
            foreach (var item in adatok)
            {
                int temp = int.Parse(item.ido.Substring(0, 2));
                bool b = (temp==1||temp==7||temp==13||temp==19);
                if (item.nev == nev && b)
                {
                    //Console.WriteLine($"{item.nev} {temp}");
                    if (temp == 1) { egy = true; /*Console.WriteLine(temp);*/ }
                    if (temp == 7) {het = true; /*Console.WriteLine(temp);*/ }
                    if (temp == 13) {tizenharom = true; /*Console.WriteLine(temp);*/ }
                    if (temp == 19) {tizenkilenc  = true; /*Console.WriteLine(temp);*/ }
                    hok += item.homer;
                    hodb++;
                }
                    
            }
            //Console.WriteLine($"{egy} {het} {tizenharom} {tizenkilenc}");
            if (egy && het && tizenkilenc && tizenharom)
                return $"Középhőmérséklet: {Math.Round(hok / hodb).ToString()}";
            else return "NA";
        }
        static void fel6()
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var item in adatok)
            {
                set.Add(item.nev);
            }
            foreach (var item in set)
            {
                FileStream fs = new FileStream($"{item}.txt", FileMode.Create);
                StreamWriter w = new StreamWriter(fs);
                w.WriteLine(item);
                foreach (var adatq in adatok)
                {
                    if (adatq.nev == item)
                    {
                        int szelerosseg = int.Parse(adatq.iranyer.Substring(3, 2));
                        w.Write($"{adatq.ido.Substring(0, 2)}:{adatq.ido.Substring(2, 2)} ");
                        for (int i = 0; i < szelerosseg; i++)
                        {
                            w.Write("#");
                        }
                        w.WriteLine();
                    }
                }
                w.Close();
                fs.Close();
            }
            Console.WriteLine("A fájlok elkészültek.");
        }
    }
}/*x.substring(0,count)*/
