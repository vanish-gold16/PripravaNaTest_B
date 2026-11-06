// Enum защищает от опечаток: "filozofie" и "Filosofie" были бы разными строками,
// а DeweyTrida.Filozofie компилятор проверит сам. Числа совпадают с кодами из задания.
enum DeweyTrida
{
    Vseobecne = 0,
    Filozofie = 100,
    Nabozenstvi = 200,
    Sociologie = 300,
    Filologie = 400,
    PrirodniVedy = 500,
    UziteVedy = 600,
    Umeni = 700,
    LiteraturaARetorika = 800,
    GeografieAHistorie = 900
}

class Kniha
{
    public string Autor { get; }
    public string Nazev { get; }
    public DeweyTrida Trida { get; }

    public Kniha(string autor, string nazev, DeweyTrida trida)
    {
        Autor = autor;
        Nazev = nazev;
        Trida = trida;
    }

    public override string ToString()
    {
        return $"{Autor}: {Nazev} [{(int)Trida:000} {Trida}]";
    }
}
