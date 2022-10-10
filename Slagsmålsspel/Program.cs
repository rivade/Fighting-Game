Random rnd = new Random();
static string OpponentName(int opponent)
{
    if (opponent == 1)
    {
        return "Tyler Durden";
    }
    else if (opponent == 2)
    {
        return "Narrator";
    }
    else
    {
        return "Robert Paulson";
    }
}
static int Fight(int health, int opphealth, int firststrike, string name, string oppName)
{
    Random hit = new Random();
    int damage = 0;
    int miss = 0;
    if (firststrike == 1)
    {
        int punch = hit.Next(20, 31);
        health -= punch;
        Console.WriteLine($"Det gjorde {punch} skada!");
        Console.WriteLine();
    }
    Console.WriteLine("Tryck enter för att fortsätta.");
    Console.ReadLine();
    while (health > 0){
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + $": {health} HP          {oppName}: {opphealth} HP");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine("Du går till attack!");
        Console.WriteLine("Välj alternativ nedan.");
        Console.WriteLine("[A] Slag (20-30 damage, 100% träffchans)   [B] Spark (30-40 damage, 75% träffchans)  [C] Knä (50-60 damage, 50% träffchans)");
        string attack = Console.ReadLine().ToLower();
        while (attack != "a" && attack != "b" && attack != "c"){
            Console.WriteLine("Du måste välja antingen a, b eller c.");
            attack = Console.ReadLine().ToLower();
        }
        switch(attack){
            case "a":
                damage = hit.Next(20, 31);
                Console.WriteLine("Du slår din motståndare!");
            break;
            case "b":
                damage = hit.Next(30, 41);
                Console.WriteLine("Du sparkar din motståndare!");
                miss = hit.Next(1, 5);
                if (miss == 1){
                Console.WriteLine("Du missade!");
                damage = 0;
                }
            break;
            case "c":
                damage = hit.Next(50, 61);
                Console.WriteLine("Du knäar din motståndare!");
                miss = hit.Next(1, 3);
                if (miss == 1){
                Console.WriteLine("Du missade!");
                damage = 0;
                }
            break;
        }
        opphealth -= damage;
        Console.WriteLine($"Din attack gjorde {damage} skada!");
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
        if (opphealth < 0){
            break;
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + $": {health} HP          {oppName}: {opphealth} HP");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        int oppattack = hit.Next(1, 4);
        switch(oppattack){
            case 1:
                damage = hit.Next(20, 31);
                Console.WriteLine($"{oppName} slår dig!");
            break;
            case 2:
                damage = hit.Next(30, 41);
                Console.WriteLine($"{oppName} sparkar dig!");
                miss = hit.Next(1, 5);
                if (miss == 1){
                Console.WriteLine($"{oppName} missade!");
                damage = 0;
                }
            break;
            case 3:
                damage = hit.Next(50, 61);
                Console.WriteLine($"{oppName} knäar dig!");
                miss = hit.Next(1, 3);
                if (miss == 1){
                Console.WriteLine($"{oppName} missade!");
                damage = 0;
                }
            break;
        }
        Console.WriteLine($"Det gjorde {damage} skada!");
        health -= damage;
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
    }
    if (health < 0){
        health = 0;
    }
    if (opphealth < 0){
        opphealth = 0;
    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + $": {health} HP          {oppName}: {opphealth} HP");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    if (health > opphealth){
        Console.WriteLine("Grattis, du besegrade din motståndare!");
        Console.WriteLine("Tryck enter för att fortsätta.");
        Console.ReadLine();
        return 1;
    }
    else{
        Console.WriteLine("Tyvärr vann din motståndare!");
        Console.WriteLine("Tryck enter för att fortsätta.");
        Console.ReadLine();
        return 0;
    }
}
static void AsciiOne(){
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@" ________  __            __          __      __                             ______   __            __        __ 
/        |/  |          /  |        /  |    /  |                           /      \ /  |          /  |      /  |
$$$$$$$$/ $$/   ______  $$ |____   _$$ |_   $$/  _______    ______        /$$$$$$  |$$ | __    __ $$ |____  $$ |
$$ |__    /  | /      \ $$      \ / $$   |  /  |/       \  /      \       $$ |  $$/ $$ |/  |  /  |$$      \ $$ |
$$    |   $$ |/$$$$$$  |$$$$$$$  |$$$$$$/   $$ |$$$$$$$  |/$$$$$$  |      $$ |      $$ |$$ |  $$ |$$$$$$$  |$$ |
$$$$$/    $$ |$$ |  $$ |$$ |  $$ |  $$ | __ $$ |$$ |  $$ |$$ |  $$ |      $$ |   __ $$ |$$ |  $$ |$$ |  $$ |$$/ 
$$ |      $$ |$$ \__$$ |$$ |  $$ |  $$ |/  |$$ |$$ |  $$ |$$ \__$$ |      $$ \__/  |$$ |$$ \__$$ |$$ |__$$ | __ 
$$ |      $$ |$$    $$ |$$ |  $$ |  $$  $$/ $$ |$$ |  $$ |$$    $$ |      $$    $$/ $$ |$$    $$/ $$    $$/ /  |
$$/       $$/  $$$$$$$ |$$/   $$/    $$$$/  $$/ $$/   $$/  $$$$$$$ |       $$$$$$/  $$/  $$$$$$/  $$$$$$$/  $$/ 
              /  \__$$ |                                  /  \__$$ |                                            
              $$    $$/                                   $$    $$/                                             
               $$$$$$/                                     $$$$$$/                                              ");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
}


AsciiOne();
Console.WriteLine("Tryck enter för att börja!");
Console.ReadLine();
Console.Clear();
Console.WriteLine("Vad heter du som spelar?");
    string name = Console.ReadLine().ToLower();
    while (name.Length == 0)
    {
        Console.WriteLine("Du måste skriva ett namn");
        Console.WriteLine("Vad heter du som spelar?");
        name = Console.ReadLine().ToLower();
    }
///////////////////////////////////////////////////////////////////////////
int wins = 0;
int active = 1;
while (active == 1)
{
    Console.Clear();
    int num = rnd.Next(1, 4);
    string oppName = OpponentName(num);
    Console.Clear();
    Console.WriteLine("Du är ute och går på promenad, när någon kommer fram till dig.");
    Console.WriteLine($"{oppName}: Hörru grabben, vart tror du att du är påväg");
    Console.WriteLine("Vill du slå först? [y/n] ");
    string begin = Console.ReadLine().ToLower();
    while (begin != "y" && begin != "n")
    {
        Console.WriteLine("Du måste skriva antingen y eller n");
        begin = Console.ReadLine().ToLower();
    }
    Console.Clear();
    if (begin == "n")
    {
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + ": Jag måste hem, hej då!");
        Console.WriteLine($"{oppName}: Du ska ingenstans!");
        Console.WriteLine($"{oppName} slår dig!");
        Console.WriteLine();
        int winCheck = Fight(100, 100, 1, name, oppName);
        Console.Clear();
        if (winCheck == 1){
            Console.WriteLine("Grattis "+ char.ToUpper(name[0]) + name.Substring(1) + ", du vann!");
            wins += 1;
        }
        else{
            Console.WriteLine($"Tyvärr " + char.ToUpper(name[0]) + name.Substring(1) + ", du förlorade!");
        };
    }
    else
    {
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + ": Det undrar du allt va?");
        Console.WriteLine($"{oppName} blir distraherad, och du gör dig redo att slåss!");
        int winCheck = Fight(100, 100, 0, name, oppName);
        Console.Clear();
        if (winCheck == 1){
            Console.WriteLine("Grattis "+ char.ToUpper(name[0]) + name.Substring(1) + ", du vann!");
            wins += 1;
        }
        else{
            Console.WriteLine($"Tyvärr " + char.ToUpper(name[0]) + name.Substring(1) + ", du förlorade!");
        };
    }
    Console.WriteLine($"Du har vunnit {wins} gånger!");
    Console.WriteLine("Vill du försöka igen? [y/n]");
    string restart = Console.ReadLine().ToLower();
    while (restart != "y" && restart != "n"){
        Console.WriteLine("Du måste välja antingen y eller n.");
        restart = Console.ReadLine().ToLower();
    }
    if (restart == "n"){
        active = 0;
    }
}
///////////////////////////////////////////////////////////////////////////
Console.WriteLine();
Console.WriteLine("Tack för att du spelade!");
Console.WriteLine("Tryck enter för att stänga programmet.");
Console.ReadLine();