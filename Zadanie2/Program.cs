namespace Triedy2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cauko opicka, zadaj si co chces spravit.");
        Console.Write("> ");
        Console.ReadLine();
        
        
        Ucet grullovUcet = new Ucet("SK98258439", "Grull");
        Ucet magtheridonovUcet = new Ucet("SK765893038", "Magtherigon");
       
    }
}

class Ucet
{
    public string cisloUctu;
    public double zostatok = 0;
    public string majitel;

    public Ucet(string cisloUctu, string majitel)
    {
        this.cisloUctu = cisloUctu;
        this.majitel = majitel;
    }

    public int Pohyb(int mnozstvo)
    {
        if (zostatok + mnozstvo > 0)
        {
            zostatok += mnozstvo;
        }

        return zostatok;
    }

    public int VlozPeniaze(int mnozstvo)
    {
        if (mnozstvo > 0)
        {
            return Pohyb(mnozstvo);
        }
        else
        {
            return zostatok;
        }
    }

    public bool VyberPeniaze(int mnozstvo)
    {
        if (mnozstvo < 1)
        {
            return false;
        }

        int m = mnozstvo;
        int r = Pohyb(-mnozstvo);
        return m != r;
    }
    
    public void aktualnyStav()
    {
        Console.WriteLine("Majitel: " + majitel);
        Console.WriteLine("Cislo uctu: " + cisloUctu);
        Console.WriteLine("Zostatok na ucte: " + zostatok);
    }

    public double VlozPeniaze(double zostatokNaUcte)
    {
        double scitanyZostatok = zostatokNaUcte + 10;
        if (scitanyZostatok > 0)
        {
            Console.WriteLine("Peniaze boli vlozene na vas ucet.");
        }
        else
        {
            Console.WriteLine("Chcete pridat zapornu hodnotu? nie. Tak nacu ju tam zadavate?");
        }

        return scitanyZostatok;
    }
}