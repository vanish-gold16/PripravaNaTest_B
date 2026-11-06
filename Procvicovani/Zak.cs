class Zak : IComparable<Zak>
{
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public int Cislo { get; set; }

    public override int GetHashCode()
    {
        return Cislo.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Zak jinyZak)
        {
            return Cislo == jinyZak.Cislo;
        }

        return false;
    }

    public int CompareTo(Zak? other)
    {
        if (other == null)
        {
            return 1;
        }

        int result = Prijmeni.CompareTo(other.Prijmeni);
        if (result == 0)
        {
            result = Jmeno.CompareTo(other.Jmeno);
        }
        if (result == 0)
        {
            result = Cislo.CompareTo(other.Cislo);
        }

        return result;
    }
}