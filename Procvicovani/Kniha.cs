class Kniha
{
    public string Nazev { get; set; }
    public string Autor { get; set; }
    public DeweyTrida Trida { get; set; }

    public Kniha(string _nazev, string _autor, DeweyTrida _trida)
    {
        Nazev = _nazev;
        Autor = _autor;
        Trida = _trida;
    } 

}