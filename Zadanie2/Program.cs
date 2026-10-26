namespace Triedy1;

class Ucet
{
    private string cisloUctu;
    private double zostatok = 0;
    private string majitel;

    public Ucet(string cisloUctu, string majitel)
    {
        this.cisloUctu = cisloUctu;
        this.majitel = majitel;
    }

    public double Pohyb(double mnozstvo)
    {
        if (zostatok + mnozstvo >= 0)
        {
            zostatok += mnozstvo;
        }

        return zostatok;
    }

    public double VlozPeniaze(double mnozstvo)
    {
        if (mnozstvo > 0)
        {
            Console.WriteLine("\nUspesny vklad "+mnozstvo+" na ucet "+cisloUctu);
            return Pohyb(mnozstvo);
        }
        else
        {
            return zostatok;
        }
    }

    public bool VyberPeniaze(double mnozstvo)
    {
        if (mnozstvo <= 0)
        {
            return false;
        }

        double m = mnozstvo;
        double r = Pohyb(- mnozstvo);
        bool result = m != r;
        if (result)
        {
            Console.WriteLine("\nUspesny vyber "+mnozstvo+" z uctu "+cisloUctu);
        }
        return result;
    }
    
    
    public void aktualnyStav()
    {
        Console.WriteLine("\nMajitel: " + majitel);
        Console.WriteLine("Cislo uctu: " + cisloUctu);
        Console.WriteLine("Zostatok na ucte: " + zostatok);
    }
    
    static void Main(string[] args)
    {
        Ucet grullovUcet = new Ucet("SK98258439", "Grull");
        grullovUcet.Pohyb(100);
        Ucet magtheridonovUcet = new Ucet("SK765893038", "Magtheridon");
        magtheridonovUcet.Pohyb(150);
        grullovUcet.VlozPeniaze(100);
        grullovUcet.aktualnyStav();
        grullovUcet.VyberPeniaze(180);
        grullovUcet.aktualnyStav();
        grullovUcet.VyberPeniaze(50);
        grullovUcet.aktualnyStav();
        grullovUcet.VyberPeniaze(-5);
        grullovUcet.aktualnyStav();

        magtheridonovUcet.VlozPeniaze(-10);
        magtheridonovUcet.aktualnyStav();
        magtheridonovUcet.VlozPeniaze(100);
        magtheridonovUcet.aktualnyStav();
        magtheridonovUcet.VyberPeniaze(180);
        magtheridonovUcet.aktualnyStav();
        magtheridonovUcet.VyberPeniaze(70);
        magtheridonovUcet.aktualnyStav();
        magtheridonovUcet.VyberPeniaze(-5);
        magtheridonovUcet.aktualnyStav();
    }
}