int Heal(int health, int amount, int maxHealth){
    health+=amount;
    if(health > maxHealth){
        health=Math.Min(health, maxHealth);
    }
    return health;
}
Console.WriteLine($"{Heal(50, 30, 100)}");
Console.WriteLine($"{Heal(90, 30, 100)}");
Console.WriteLine($"{Heal(0, 25, 100)}");
Console.WriteLine($"{Heal(50, 30, 60)}");