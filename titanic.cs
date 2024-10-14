using System.Text;

namespace titanic
{
    class Titanic
    {
        public string nev;
        public int tulelok;
        public int eltuntek;

        public Titanic(string line)
        {   // gyerekek-masodosztaly;24;0                    0                1   2

            string[] parts = line.Split(';'); // ["gyerekek-masodosztaly","24","0"]
            this.nev = parts[0];
            this.tulelok = int.Parse(parts[1]);
            this.eltuntek = int.Parse(parts[2]);
        }

        public int letszam()
        {
            return this.tulelok + this.eltuntek;
        }

        public double eltuntekAranya()
        {
            return Convert.ToDouble(this.eltuntek) / (Convert.ToDouble(this.letszam()) / 100);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(path: "titanic.txt", encoding: Encoding.UTF8);

            string line;

            List<Titanic> kategoriak = new List<Titanic>();

            while( (line = sr.ReadLine()) != null) {
                kategoriak.Add(new Titanic(line));
            }

            // 2. feladat
            Console.WriteLine($"2. feladat: {kategoriak.Count} db");

            // 3. feladat
            int szemelyek = 0;
            foreach (Titanic kategoria in kategoriak)
            {
                szemelyek += kategoria.letszam();
            }
            Console.WriteLine($"3. feladat: {szemelyek} fő");

            // 4. feladat
            Console.Write("4. feladat: Kulcsszó:");
            string kulcsszo = Console.ReadLine();
            bool tartalmazza = false;
            foreach (Titanic kategoria in kategoriak)
            {
                if (kategoria.nev.Contains(kulcsszo))
                {
                    tartalmazza = true;
                    break;
                }
            }
            if (tartalmazza) { Console.WriteLine("Van találat!"); }
            else { Console.WriteLine("Nincs találat!"); }

            // 5. feladat

            if (tartalmazza) {
                foreach (Titanic kategoria in kategoriak)
                {
                    if (kategoria.nev.Contains(kulcsszo))
                    {
                        Console.WriteLine($"\t{kategoria.nev} - {kategoria.letszam()} fő");
                    }
                }
            }

            // 6. feladat
            Console.WriteLine("6. feladat:");
            foreach (Titanic kategoria in kategoriak)
            {   if(kategoria.eltuntekAranya() > 60)
                {
                    Console.WriteLine("\t" + kategoria.nev);
                }
            }

            // 7. feladat
            Console.WriteLine("7. feladat");
            Titanic maxTulelo = kategoriak[0];
            foreach (Titanic kategoria in kategoriak)
            {
                if(kategoria.tulelok > maxTulelo.tulelok)
                {
                    maxTulelo = kategoria;
                }
            }
            Console.WriteLine($"{maxTulelo.nev} - {maxTulelo.tulelok}");
        }
    }
}
