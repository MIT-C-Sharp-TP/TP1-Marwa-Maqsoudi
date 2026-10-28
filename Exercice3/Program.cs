string name="Aya";
int health=40;

for(int turn=1; turn <=6; turn++){
    health-=8;
    if(health <= 0){
        Console.WriteLine($"Turn {turn}: poison, 0 HP left");
        Console.WriteLine($"{name} is down");
        break;
    }else{

        Console.WriteLine($"Turn {turn}: poison, {health} HP left");
    }
}
