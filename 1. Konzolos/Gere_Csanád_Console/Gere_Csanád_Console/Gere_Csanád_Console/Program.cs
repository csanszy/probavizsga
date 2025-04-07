using System.Text;

namespace Gere_Csanád_Console
{
    internal class Program
    {
        List<Konyvtar> diak;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.diak = Konyvtar.ReadFile();
            program.HarmadikFeladat();
            program.NegyedikFeladat();
            program.ÖtödikFeladat();
            program.HatodikFeladat();
            program.HetedikFeladat();
        }

        void HarmadikFeladat()
        {
            Console.WriteLine($"3. feladat: A forrásfájlban {diak.Count()} diák adatai találhatók.");
        }

        void NegyedikFeladat()
        {
            Console.WriteLine($"4. feladat:");
            diak.GroupBy(a => a.verseny).OrderByDescending(g => g.Key).ToList().ForEach(g => Console.WriteLine($"\t{g.Key} {g.Count()}"));
        }

        void ÖtödikFeladat()
        {
            Console.WriteLine($"5. feladat:");
            diak.Where(a => a.szazalek >= 90).ToList().OrderByDescending(a => a.szazalek).ToList().ForEach(a => Console.WriteLine($"\t{a.name}, {a.iskola}, {a.szazalek}"));
        }

        void HatodikFeladat()
        {
            Console.WriteLine($"6. feladat: A Neumann János Technikum diákjainak átlagos eredménye: {String.Format("{0:0}", Math.Round(diak.Where(a => a.iskola == "Neumann János Technikum").Average(a => a.szazalek), 1))}");
        }

        void HetedikFeladat()
        {
            Console.WriteLine($"7. feladat: Legjobb eredmenyt elérő diák kiadott könyv: {diak.OrderByDescending(a => a.szazalek).First().name}, {diak.OrderByDescending(a => a.szazalek).Last().szazalek}");
        }
    }
}