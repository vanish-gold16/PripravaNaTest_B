class Kun : IComparable<Kun>
{
    public String Jmeno { get; set; }
    public String JmenoJezdce { get; set; }
    public int StartovniCislo { get; set; }

    public Kun(String _jmeno, String _jmenoJezdce, int _startovniCislo)
    {
        Jmeno = _jmeno;
        JmenoJezdce = _jmenoJezdce;
        StartovniCislo = _startovniCislo;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Kun jinyKun)
        {
            return StartovniCislo == jinyKun.StartovniCislo;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return StartovniCislo.GetHashCode();
    }

    public int CompareTo(Kun? other)
    {
        if (other == null)
        {
            return 1;
        }

        int result = Jmeno.CompareTo(other.Jmeno);
        if (result == 0)
        {
            result = JmenoJezdce.CompareTo(other.JmenoJezdce);
        }
        if (result == 0)
        {
            result = StartovniCislo.CompareTo(other.StartovniCislo);
        }
        
        return result;
    }

}