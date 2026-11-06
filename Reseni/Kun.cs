// IComparable<Kun> — обещание, что коней можно сравнивать. Без него SortedSet упадёт.
class Kun : IComparable<Kun>
{
    // Только get: значения задаются один раз в конструкторе.
    // Если поменять номер коня, который уже лежит в HashSet, HashSet его потеряет.
    public string Jmeno { get; }
    public string Jezdec { get; }
    public int StartovniCislo { get; }

    public Kun(string jmeno, string jezdec, int startovniCislo)
    {
        Jmeno = jmeno;
        Jezdec = jezdec;
        StartovniCislo = startovniCislo;
    }

    // HashSet: "это тот же самый конь?" -> тот же стартовый номер.
    public override bool Equals(object? obj)
    {
        if (obj is Kun jiny)
        {
            return StartovniCislo == jiny.StartovniCislo;
        }
        return false;
    }

    // HashSet: в какую "корзину" положить коня.
    // Только те поля, что и в Equals. Иначе равные кони попадут в разные корзины.
    public override int GetHashCode()
    {
        return StartovniCislo.GetHashCode();
    }

    // SortedSet: кто стоит раньше? Меньше 0 — this раньше, больше 0 — позже, 0 — дубликат.
    public int CompareTo(Kun? other)
    {
        if (other is null)
        {
            return 1;
        }

        // 1) по имени коня
        int vysledek = Jmeno.CompareTo(other.Jmeno);
        if (vysledek != 0)
        {
            return vysledek;
        }

        // 2) при одинаковом имени — по имени жокея
        vysledek = Jezdec.CompareTo(other.Jezdec);
        if (vysledek != 0)
        {
            return vysledek;
        }

        // 3) иначе SortedSet вернул бы 0 и выбросил второго коня с другим номером
        return StartovniCislo.CompareTo(other.StartovniCislo);
    }

    public override string ToString()
    {
        return $"#{StartovniCislo} {Jmeno} (jezdec: {Jezdec})";
    }
}
