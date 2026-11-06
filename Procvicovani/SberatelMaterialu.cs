class SberatelMaterialu
{
    Dictionary<TridaMineralu, List<Mineral>> mineraly { get; set; }
    public string Jmeno { get; set; }

    public SberatelMaterialu()
    {
        mineraly = new Dictionary<TridaMineralu, List<Mineral>>();
    } 

    public void PridatMineral(Mineral mineral)
    {
        if (!mineraly.ContainsKey(mineral.Trida))
        {
            mineraly.Add(mineral.Trida, new List<Mineral>());
        }
        mineraly[mineral.Trida].Add(mineral);
    }

    public List<Mineral> MineralyPodleTridy(TridaMineralu trida)
    {
        if (mineraly.ContainsKey(trida))
        {
            return mineraly[trida];
        }
        return new List<Mineral>();
    }

}

enum TridaMineralu
{
    Prvky, Sulfidy, Halogenidy, OxidyAHidroxidy, Uhlicitany, Sirany, Fosforecnany, Kremicitany, OrganickeMaterialy
}