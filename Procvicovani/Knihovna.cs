class Knihovna
{
    public Dictionary<DeweyTrida, List<Kniha>> knihy { get; set; }

    public Knihovna()
    {
        knihy = new Dictionary<DeweyTrida, List<Kniha>>();
    }

    public void PridejKnihu(Kniha kniha)
    {
        if(!knihy.ContainsKey(kniha.Trida))
        {
            knihy.Add(kniha.Trida, new List<Kniha>());
        }
        knihy[kniha.Trida].Add(kniha);
    }

    public List<Kniha> KnihyPodleTridy(DeweyTrida trida)
    {
        if (knihy.ContainsKey(trida))
        {
            return knihy[trida];
        }
        return new List<Kniha>();
    }

}

enum DeweyTrida
{
    Vseobecne = 0, Filozofie = 100, Nabozenstvi = 200, Sociologie = 300, Filologie = 400, 
    PrirodniVedy = 500, UziteVedy = 600, Umeni = 700, LiteraturaARetorika = 800, GeografieAHistorie = 900
}