string name="Aya";

int health=45;


if (health >= 70){
    Console.WriteLine($"{name} has {health} HP: healthy"); 
}else if (health < 70 && health >= 31){
       Console.WriteLine($"{name} has {health} HP: injured");
}else if (health < 30 && health  >= 1){
       Console.WriteLine($"{name} has {health} HP: critically");
}else{
    Console.WriteLine($"{name} is down");
}



