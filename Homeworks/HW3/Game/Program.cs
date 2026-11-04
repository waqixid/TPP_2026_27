abstract class Character
{
    private string name;
    private int id;
    private int hp;
    private int power;
    private static int count = 0;

    public int ID
    {
        get{return id;}
    }
    public string Name
    {
        get{return name;}
    }
    public int Hp
    {
        get{return hp;}
    }
    public int Power
    {
        get{return power;}
    }
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
                id = Character.HowMany();
            }
            else
            {
                throw new Exception(@"Введены неправильные значения: здоровье и/или сила неположительные");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
            this.name = "Unknown";
            this.hp = 1;
            this.power = 1;
            count += 1;
            id = Character.HowMany();
        }

    }
    public void TakeDamage(int power)
    {
        if (Hp>0) hp-=power;
    
    }
    public abstract void Attack(Character target);
    public bool IsAlive()
    {
        if (Hp > 0)
        {
            return true;
        }
        else return false;
    }
    public override string ToString()
    {
        return $"{Name} (HP: {Hp})";
    }
    
    public override int GetHashCode()
    {
        return ID;
    }

    public static int HowMany()
    {
        return count;
    }
    private static bool IsValidStats(int hp, int power)
    {
        if (hp > 0 && power > 0) return true;
        else return false;
    }
    public override bool Equals(object? obj)
    {
        if(obj ==null || !(obj is Character)) return false;
        else return ID == ((Character) obj).ID;

    }
    
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
    public override void Attack(Character target)
    {
        Console.WriteLine();
        target.TakeDamage(Power);
        Console.WriteLine($"Враг {target.Name} был атакован игроком {Name} и потерял {Power} ХП");
        Console.WriteLine(target);
        Console.WriteLine();
    }
    
    
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
    public override void Attack(Character target)
    {
        Console.WriteLine();
        target.TakeDamage(Power);
        Console.WriteLine($"Игрок {target.Name} был атакован врагом {Name} и потерял {Power} ХП");
        Console.WriteLine(target);
        Console.WriteLine();
    }

}
class Program
{
    static void Main()

    {
        string name; int hp, power;

        Console.Write("Имя игрока: ");
        name = Console.ReadLine();
        Console.Write("ХП игрока: ");
        hp = int.Parse(Console.ReadLine());
        Console.Write("Сила атаки игрока: ");
        power = int.Parse(Console.ReadLine());
        Character player = new Player(name, hp, power);
        Console.WriteLine($"Создан игрок: {name} (HP: {hp}, Урон: {power})");

        Console.WriteLine();

        Console.Write("Имя врага: ");
        name = Console.ReadLine();
        Console.Write("ХП врага: ");
        hp = int.Parse(Console.ReadLine());
        Console.Write("Сила атаки врага: ");
        power = int.Parse(Console.ReadLine());
        Character enemy = new Enemy(name, hp, power);
        Console.WriteLine($"Создан враг: {name} (HP: {hp}, Урон: {power})");

        Console.WriteLine();
        Console.WriteLine("FIGHT!!!!!!!!!");
        Console.WriteLine();

        while (player.IsAlive() && enemy.IsAlive())
        {
            player.Attack(enemy);
            if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.Name} побежден {player.Name}! Слава {player.Name}");
                break;
            }
            enemy.Attack(player);
            if (!player.IsAlive())
            {
                Console.WriteLine($"{player.Name} побежден {enemy.Name}. Слава {enemy.Name}...");
                break;
            }
        }
        }
        
        
    
}