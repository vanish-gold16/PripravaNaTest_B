class Mineral
{
    public string Nazev { get; set; }
    public TridaMineralu Trida { get; set; }

    public Mineral(string _nazev, TridaMineralu _trida)
    {
        Nazev = _nazev;
        Trida = _trida;
    }

}