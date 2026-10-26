namespace CvicenieClassers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Morituri te salutant.");
        Hrdina nasPrvyHrdina = new Hrdina("Arthas", 150, 50); // nova instancia triedy hrdina
        Hrdina nasDruhyHrdina = new Hrdina("Illidan", 150, 50);
        
        Hrdina prvy = nasPrvyHrdina;
        Hrdina druhy = nasDruhyHrdina;
        do
        {
            prvy.Regeneruj(); // nemal by sa regenerovat pred zapasom (mal by o 5 naviac)
            druhy.Regeneruj();
            bool podarilSaUtok = prvy.Utok(druhy); // cena utoku = sila utoku
            Hrdina virtualny = prvy; // vymena hrdinov cez tretiu premennu
            prvy = druhy;
            druhy = virtualny;
        } while (!(prvy.zdravie() == 0 || druhy.zdravie() == 0));

        if (nasDruhyHrdina.zdravie() == 0 && nasPrvyHrdina.zdravie() == 0)
        {
            Console.WriteLine("Remiza!");
        }
        else if(nasPrvyHrdina.zdravie() == 0)
        {
            Console.WriteLine("Vyhral "+nasDruhyHrdina.meno());
        }
        else if (nasDruhyHrdina.zdravie() == 0)
        {
            Console.WriteLine("Vyhral "+nasPrvyHrdina.meno());
        }
    }
}

class Hrdina
{
    string Meno;
    int Zdravie;
    int Energia;
    int MaxEnergia;
    static Random randomizer = new Random();

    public Hrdina(string m, int z, int e)
    {
        Meno = m;
        Zdravie = z;
        MaxEnergia = Energia = e;
    }

    public void Regeneruj()
    {
        Energia = Energia + 5;
        if (Energia > MaxEnergia)
        {
            Energia = MaxEnergia;
        }
    }

    public int PrijmiZranenie(int sila)
    {
        Zdravie = Zdravie - sila;
        if (Zdravie < 0)
        {
            Zdravie = 0;
        }
        Console.WriteLine(meno() + " ma uz len " + zdravie() + " zdravia.");
        return Zdravie;
    }

    public bool Utok(Hrdina druhy)
    {
        int silaUtoku = randomizer.Next(10,30);
        bool podarilSaUtok = Energia >= silaUtoku;
        if (! podarilSaUtok)
        {
            Console.WriteLine(meno() + " je unaveny");
            return false;
        }
        Energia = Energia - silaUtoku;
        
        Console.WriteLine(meno() + " Trafil");
        druhy.PrijmiZranenie(silaUtoku);
        return podarilSaUtok;
    }

    // fluent api methods
    public Hrdina meno(string m)
    {
        Meno = m;
        return this;
    }

    public string meno()
    {
        return Meno;
    }
    
    public Hrdina energia(int e)
    {
        Energia = e;
        return this;
    }
    public int energia()
    {
        return Energia;
    }
    
    public Hrdina zdravie(int z)
    {
        Zdravie = z;
        return this;
    }
    
    public int zdravie()
    {
        return Zdravie;
    }

    public void VypisAktualnyStav()
    {
        Console.WriteLine("Meno: " + Meno);
        Console.WriteLine("Zdravie: " + Zdravie);
        Console.WriteLine("Energia: " + Energia);
    }
}