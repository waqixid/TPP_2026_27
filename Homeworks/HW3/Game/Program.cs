class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;
    public Character(string name, int hp, int power)
    {

        try
        {
            if (Character.IsValidStats(hp, power) == true)
            {
                this.name = name;
                this.hp = hp;
                this.power = power;
                count += 1;
            }
            else
            {
                throw new Exception(@"Введены неправильные значения: здоровье и/или сила неположительные");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
            name = "Unknown";
            hp = 1;
            power = 1;
            count += 1;
        }

    }
    public Character Attack(Character target)
    {
        
        this.GetStatus();
        target.GetStatus();
        Console.WriteLine();
        target.hp -= power;
        Console.WriteLine($"Персонаж {target.name} был атакован {name} и потерял {power} ХП");
        Console.WriteLine();
        this.GetStatus();
        target.GetStatus();
        return target;
    }
    public void GetStatus()
    {
        Console.WriteLine($"{name}: {hp} ХП");
    }

    public static int HowMany()
    {
        return count;
    }
    protected static bool IsValidStats(int hp, int power)
    {
        if (hp > 0 && power > 0) return true;
        else return false;
    }
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
    
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
}
class Program
{
    static void Main()
    {
    }
}