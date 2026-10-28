// Lab 1 starter: a turn-based duel in the console.
// It builds and runs as it is. Fill in the TODO parts, one step at a time.
using System;
using System.Collections.Generic;


/*Player player = new Player("Aya", 100, 2);
player.TakeDamage(30);
player.DrinkPotion();
player.DrinkPotion();
player.DrinkPotion();
player.TakeDamage(150);
Console.WriteLine($"Alive: {player.IsAlive}");*/
/*Random rng = new Random(7); // fixed seed: the same numbers at every run
Player player = new Player("Aya", 100, 2);
Enemy goblin = new Goblin();
Enemy orc = new Orc();
goblin.Attack(player, rng);
orc.Attack(player, rng);
orc.TakeDamage(25);
Console.WriteLine($"{orc.Name} alive: {orc.IsAlive}");
orc.TakeDamage(40);
Console.WriteLine($"{orc.Name} alive: {orc.IsAlive}");*

// TODO step 4: add a Goblin, an Orc and a second Goblin to the list
/*enemies.Add(new Goblin());
enemies.Add(new Orc());
enemies.Add(new Goblin());*/

Player player = new Player("Aya", 100, 2);
List<Enemy> enemies = new List<Enemy>();
enemies.Add(new Goblin());
enemies.Add(new Orc());
enemies.Add(new Goblin());
/*Console.WriteLine("=== Arena ===");
Console.WriteLine($"{player.Name} faces {enemies.Count} enemies:");
foreach (Enemy e in enemies) {
    Console.WriteLine($"- {e.Name}, {e.Health} HP");
}
Console.WriteLine($"First in line: {enemies[0].Name}");*/
// TODO step 5: the game loop
// while the player is alive and enemies remain:
// show the status, read a choice, act, then the first enemy attacks
// TODO step 7: print "Victory" or "Defeat"
Random rng = new Random();
int turn = 0;
Console.WriteLine("=== Arena ===");
/*while (player.IsAlive && enemies.Count > 0){
    turn++;
    Enemy enemy = enemies[0]; // the enemy in front of Aya
    Console.WriteLine();
    Console.WriteLine($"Turn {turn}: {player.Name} {player.Health} HP | {enemy.Name} {enemy.Health} HP");
    Console.WriteLine($"Turn {turn}: {player.Name} {player.Health} HP | {enemy.Name} {enemy.Health} HP");

    // Aya attacks: the enemy takes 12 to 24 damage
    int damage = rng.Next(12, 25);
    enemy.TakeDamage(damage);

    // If defeated, print a message, remove the enemy and continue
    if (!enemy.IsAlive)
    {
        Console.WriteLine($"{enemy.Name} is defeated!");
        enemies.RemoveAt(0);
        continue;
    }
    enemy.Attack(player, rng);
}*/
while (player.IsAlive && enemies.Count > 0)
{
    turn++;
    Enemy enemy = enemies[0];

    Console.WriteLine();
    Console.WriteLine($"Turn {turn}: {player.Name} {player.Health} HP, {player.Potions} potions | {enemy.Name} {enemy.Health} HP");

    Console.Write("1 attack, 2 drink a potion, 3 run away > ");
    string? text = Console.ReadLine();

    if (!int.TryParse(text, out int choice))
    {
        Console.WriteLine("Type 1, 2 or 3.");
        continue;
    }

    switch (choice)
    {
        case 1:
            int damage = rng.Next(12, 25);
            enemy.TakeDamage(damage);
            break;

        case 2:
            player.DrinkPotion();
            break;

        case 3:
            Console.WriteLine("You run away.");
            return;

        default:
            Console.WriteLine("Type 1, 2 or 3.");
            continue;
    }

    if (!enemy.IsAlive)
    {
        Console.WriteLine($"{enemy.Name} is defeated!");
        enemies.RemoveAt(0);
        continue;
    }

    enemy.Attack(player, rng);
}

if (player.IsAlive) { 
    Console.WriteLine($"Victory in {turn} turns!"); 
}else{
    Console.WriteLine("Defeat...");
}


public class Player{
    private int health;
    public string Name { get; }
    public int MaxHealth { get; }
    public int Potions { get; private set; }

    public int Health {
        get => health;
        private set => health = Math.Clamp(value, 0, MaxHealth);
    }
    public bool IsAlive => Health > 0;
    public Player(string name, int maxHealth, int potions) {
        Name = name;
        MaxHealth = maxHealth;
        Potions = potions;
        Health = maxHealth;
    }

    public void TakeDamage(int amount) { 
        Health -= amount; 
        Console.WriteLine($"{Name} takes {amount} damage ({Health} HP)."); 
    }

    public void DrinkPotion() {
        if (Potions > 0 && IsAlive) {
            Health += 30;
            Potions--;
            Console.WriteLine($"{Name} drinks a potion ({Health} HP)");
        }
        else
        {
            Console.WriteLine($"No potion left!");
        }
        
    }
}



public abstract class Enemy {
    public string Name { get; }
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    protected Enemy(string name, int health) {
        Name = name;
        Health = health;
    }
    public void TakeDamage(int amount) {
        Health = Math.Max(0, Health - amount);
        Console.WriteLine($"{Name} takes {amount} damage ({Health} HP)");
    }

    public abstract void Attack(Player target, Random rng);
}

// TODO step 3: public class Goblin : Enemy { ... }
public class Goblin : Enemy{
    public Goblin() : base("Goblin", 30){}

    public override void Attack(Player target, Random rng){
        Console.WriteLine("Goblin stabs!");
        target.TakeDamage(rng.Next(4, 9));
    }
}

// TODO step 3: public class Orc : Enemy { ... }


public class Orc : Enemy
{
    public Orc() : base("Orc", 60)
    {
    }

    public override void Attack(Player target, Random rng)
    {
        Console.WriteLine("Orc swings its club!");
        target.TakeDamage(rng.Next(8, 15));
    }
}
