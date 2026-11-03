namespace ObjednavkovySystem;

class Program
{
    static void Main(string[] args)
    {
        Customer Tomino = new Customer();
        Tomino.Name = "Tomino";
        Tomino.Email = "tomas.sigma@more.dyg";
        Tomino.Address = "Les 6 Raca";

        Product prod1 = new Product();
        prod1.Name = "Pracka";
        prod1.Price = 599;

        Product prod2 = new Product();
        prod2.Name = "Zehlicka";
        prod2.Price = 120;

        Order obj1 = new Order();
        obj1.Id = 1;
        obj1.Client = Tomino;
        obj1.Items.Add(prod1);
        obj1.Items.Add(prod2);
    }
}

class Customer
{
    public string Email;
    public string Name;
    public string Address;
}

class Product
{
    public double Price;
    public string Name;
}

class Order
{
    public int Id;
    public Customer Client;
    public List<Product> Items = new List<Product>();
}