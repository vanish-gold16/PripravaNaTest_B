class Knihovna
{
    // Ключ — класс Дьюи, значение — все книги этого класса.
    // Поиск по классу сразу находит нужный список, не перебирая всю библиотеку.
    private Dictionary<DeweyTrida, List<Kniha>> knihy;

    public Knihovna()
    {
        knihy = new Dictionary<DeweyTrida, List<Kniha>>();
    }

    public void PridejKnihu(Kniha kniha)
    {
        // Первая книга этого класса: сначала создаём для него пустой список.
        if (!knihy.ContainsKey(kniha.Trida))
        {
            knihy.Add(kniha.Trida, new List<Kniha>());
        }
        knihy[kniha.Trida].Add(kniha);
    }

    public List<Kniha> VratKnihyTridy(DeweyTrida trida)
    {
        if (knihy.ContainsKey(trida))
        {
            // Копия: если снаружи что-то удалят из результата, библиотека не пострадает.
            return new List<Kniha>(knihy[trida]);
        }
        // Нет книг — пустой список, а не исключение и не null.
        return new List<Kniha>();
    }
}
