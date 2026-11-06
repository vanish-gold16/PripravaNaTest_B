// Проверка решения. Этот файл можно скопировать в Procvicovani, чтобы проверить свой код.
// Для этого твои классы и методы должны называться так же:
//   new Kun(jmeno, jezdec, startovniCislo), Jmeno, Jezdec, StartovniCislo
//   new Kniha(autor, nazev, trida), enum DeweyTrida
//   new Knihovna(), PridejKnihu(kniha), VratKnihyTridy(trida)
class Program
{
    static int chyby = 0;

    static void Main(string[] args)
    {
        TestKone();
        Console.WriteLine();
        TestKnihovna();

        Console.WriteLine();
        Console.WriteLine(chyby == 0 ? "Все проверки пройдены." : $"Ошибок: {chyby}");
    }

    static void Zkontroluj(string popis, bool splneno)
    {
        Console.WriteLine($"[{(splneno ? "OK" : "CHYBA")}] {popis}");
        if (!splneno)
        {
            chyby++;
        }
    }

    static void TestKone()
    {
        Console.WriteLine("--- Ukol 1: kone ---");

        HashSet<Kun> hash = new HashSet<Kun>();
        Zkontroluj("HashSet принимает нового коня", hash.Add(new Kun("Blesk", "Novák", 1)));
        Zkontroluj("HashSet отклоняет другого коня с тем же номером", !hash.Add(new Kun("Vítr", "Svoboda", 1)));
        Zkontroluj("HashSet принимает такого же коня с другим номером", hash.Add(new Kun("Blesk", "Novák", 2)));
        Zkontroluj("Equals сравнивает по номеру", new Kun("A", "B", 5).Equals(new Kun("C", "D", 5)));
        Zkontroluj("Равные кони имеют одинаковый хеш",
            new Kun("A", "B", 5).GetHashCode() == new Kun("C", "D", 5).GetHashCode());

        SortedSet<Kun> serazeni = new SortedSet<Kun>();
        serazeni.Add(new Kun("Vítr", "Svoboda", 3));
        serazeni.Add(new Kun("Blesk", "Novák", 1));
        serazeni.Add(new Kun("Blesk", "Dvořák", 2));
        serazeni.Add(new Kun("Amor", "Král", 4));

        List<int> poradi = new List<int>();
        foreach (Kun kun in serazeni)
        {
            Console.WriteLine("    " + kun);
            poradi.Add(kun.StartovniCislo);
        }
        Zkontroluj("SortedSet: сначала по имени, потом по жокею", string.Join(",", poradi) == "4,2,1,3");

        serazeni.Add(new Kun("Blesk", "Novák", 5));
        Zkontroluj("SortedSet не теряет коня с тем же именем и жокеем, но другим номером", serazeni.Count == 5);
    }

    static void TestKnihovna()
    {
        Console.WriteLine("--- Ukol 2: knihovna ---");

        Knihovna knihovna = new Knihovna();
        knihovna.PridejKnihu(new Kniha("Platón", "Ústava", DeweyTrida.Filozofie));
        knihovna.PridejKnihu(new Kniha("Karel Čapek", "R.U.R.", DeweyTrida.LiteraturaARetorika));
        knihovna.PridejKnihu(new Kniha("René Descartes", "Rozprava o metodě", DeweyTrida.Filozofie));

        List<Kniha> filozofie = knihovna.VratKnihyTridy(DeweyTrida.Filozofie);
        foreach (Kniha kniha in filozofie)
        {
            Console.WriteLine("    " + kniha);
        }
        Zkontroluj("Возвращает все книги нужного класса", filozofie.Count == 2);
        Zkontroluj("Не подмешивает книги другого класса", knihovna.VratKnihyTridy(DeweyTrida.LiteraturaARetorika).Count == 1);
        Zkontroluj("Для класса без книг возвращает пустой список", knihovna.VratKnihyTridy(DeweyTrida.Umeni).Count == 0);

        filozofie.Clear();
        Zkontroluj("Изменение результата не портит библиотеку", knihovna.VratKnihyTridy(DeweyTrida.Filozofie).Count == 2);
    }
}
