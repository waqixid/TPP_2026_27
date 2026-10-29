class Character
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
        }

    }
    public void TakeDamage(int power)
    {
        if (Hp>0) hp-=power;
    
    }
    public virtual Character Attack(ref Character target)
    {

        Console.WriteLine(target);
        Console.WriteLine();
        target.TakeDamage(power);
        Console.WriteLine($"Персонаж {target.Name} был атакован {Name} и потерял {Power} ХП");
        Console.WriteLine();
        Console.WriteLine(target);
        return target;
    }
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
    protected static bool IsValidStats(int hp, int power)
    {
        if (hp > 0 && power > 0) return true;
        else return false;
    }
    public override bool Equals(object? obj)
    {
        if(obj ==null || !(obj is Character)) return false;
        else return Name == ((Character) obj).Name;

    }
    
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
    public override Enemy Attack(Enemy target)
    {
         Console.WriteLine(target);
        Console.WriteLine();
        target.TakeDamage(Power);
        Console.WriteLine($"Враг {target.Name} был атакован игроком {Name} и потерял {Power} ХП");
        Console.WriteLine();
         Console.WriteLine(target);
        return target;
    }
    
    
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
        
    }
    public override Player Attack(Player target)
    {
        Console.WriteLine(target);
        Console.WriteLine();
        target.TakeDamage(Power);
        Console.WriteLine($"Игрок {target.Name} был атакован врагом {Name} и потерял {Power} ХП");
        Console.WriteLine();
         Console.WriteLine(target);
        return target;
    }

}
class Program
{
    static void Main()
    
    {
        string name; int hp, power;
        Console.WriteLine("Сколько игроков вы хотите? ");
        byte n = byte.Parse(Console.ReadLine());
        Console.WriteLine("Сколько врагов вы хотите?");
        byte m = byte.Parse(Console.ReadLine());
        var characters = new List<Character>();
        for (int i =0; i< n; i++)
        {
            name = Console.ReadLine();
            hp = int.Parse(Console.ReadLine());
            power = int.Parse(Console.ReadLine());
            characters.Add(new Player(name, hp, power));
            Console.WriteLine($"Создан игрок: {name} (HP: {hp}, Урон: {power})");
        }
        for (int i =0; i< m; i++)
        {
            name = Console.ReadLine();
            hp = int.Parse(Console.ReadLine());
            power = int.Parse(Console.ReadLine());
            characters.Add(new Enemy(name, hp, power));
            Console.WriteLine($"Создан враг: {name} (HP: {hp}, Урон: {power})");
        }
        foreach(Player player in characters)
        {
            foreach(Enemy enemy in characters)
            {
                player.Attack(ref enemy);
                if (enemy.IsAlive() == false)
                {
                    Console.WriteLine($"Игрок {player.Name} победил врага {enemy.Name}!");
                    characters.Remove(enemy);
                    continue;
                }
                enemy.Attack(ref player);
                if (player.IsAlive() == false)
                {
                    Console.WriteLine($"Враг {enemy.Name} победил игрока {player.Name}!");
                    characters.Remove(player);
                    break;
                }
            }
        }
        
    }
}