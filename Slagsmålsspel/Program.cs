Random rnd = new Random();
static string OpponentName(int opponent)
{
    if (opponent == 1)
    {
        return "Roxanna";
    }
    else if (opponent == 2)
    {
        return "Noor";
    }
    else
    {
        return "Fatmah";
    }
}
static int Fight(int health, int opphealth, int firststrike, string name, string oppName)
{
    Random hit = new Random();
    int damage = 0;
    int miss = 0;
    if (firststrike == 1)
    {
        int slap = hit.Next(5, 16);
        health -= slap;
        Console.WriteLine($"Det gjorde {slap} skada!");
        if (health < 0){
            Console.WriteLine("Du har nu 0 hp.");
        }
        else{
            Console.WriteLine($"Du har nu {health} hp.");
        }
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
        Console.WriteLine("[A] Slag (20-30 damage, 80% träffchans)   [B] Spark (30-50 damage, 50% träffchans)  [C] Knä (40-60 damage, 25% träffchans)");
        string attack = Console.ReadLine().ToLower();
        while (attack != "a" && attack != "b" && attack != "c"){
            Console.WriteLine("Du måste välja antingen a, b eller c.");
            attack = Console.ReadLine().ToLower();
        }
        switch(attack){
            case "a":
                damage = hit.Next(20, 31);
                Console.WriteLine("Du slår din motståndare!");
                miss = hit.Next(1, 6);
                if (miss == 1){
                Console.WriteLine("Du missade!");
                damage = 0;
                }
            break;
            case "b":
                damage = hit.Next(30, 51);
                Console.WriteLine("Du sparkar din motståndare!");
                miss = hit.Next(1, 3);
                if (miss == 1){
                Console.WriteLine("Du missade!");
                damage = 0;
                }
            break;
            case "c":
                Console.WriteLine("Du knäar din motståndare!");
                miss = hit.Next(1, 5);
                if (miss == 1){
                damage = hit.Next(40, 61);
                }
                else{
                    Console.WriteLine("Du missade!");
                    damage = 0;
                }
            break;
        }    
        int crit = hit.Next(1, 21);
        if (crit == 1){
            Console.WriteLine("Kritisk träff!");
            Console.WriteLine("Du knockade din motståndare!");
            opphealth = 0;
            break;
        }
        opphealth -= damage;
        Console.WriteLine($"Din attack gjorde {damage} skada!");
        if (opphealth > 0){
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        else{
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
                miss = hit.Next(1, 6);
                if (miss == 1){
                Console.WriteLine($"{oppName} missade!");
                damage = 0;
                }
            break;
            case 2:
                damage = hit.Next(30, 51);
                Console.WriteLine($"{oppName} sparkar dig!");
                miss = hit.Next(1, 3);
                if (miss == 1){
                Console.WriteLine($"{oppName} missade!");
                damage = 0;
                }
            break;
            case 3:
                Console.WriteLine($"{oppName} knäar dig!");
                miss = hit.Next(1, 5);
                if (miss == 1){
                damage = hit.Next(40, 61);
                }
                else{
                    Console.WriteLine($"{oppName} missade!");
                    damage = 0;
                }
            break;
        }
        crit = hit.Next(1, 21);
        if (crit == 5){
            Console.WriteLine("Kritisk träff!");
            Console.WriteLine($"{oppName} knockar dig!");
            health = 0;
            break;
        }
        Console.WriteLine($"Det gjorde {damage} skada!");
        health -= damage;
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
    }
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

Console.WriteLine("Välkommen till boxnings simulatorn!");
Console.WriteLine("Är du redo att börja? [y/n] ");
string begin = Console.ReadLine().ToLower();
while (begin != "y" && begin != "n")
{
    Console.WriteLine("Du måste skriva antingen y eller n");
    begin = Console.ReadLine().ToLower();
}
if (begin == "n")
{
    Console.Clear();
    Console.WriteLine("Asså varför startar du spel du inte vill köra");
    Console.WriteLine("Tryck enter för att avsluta");
    Console.ReadLine();
    System.Environment.Exit(1);
}
///////////////////////////////////////////////////////////////////////////
int active = 1;
while (active == 1)
{
    Console.Clear();
    Console.WriteLine("Vad heter du som spelar?");
    string name = Console.ReadLine().ToLower();
    while (name.Length == 0)
    {
        Console.WriteLine("Du måste skriva ett namn");
        Console.WriteLine("Vad heter du som spelar?");
        name = Console.ReadLine().ToLower();
    }
    int num = rnd.Next(1, 4);
    string oppName = OpponentName(num);
    Console.Clear();
    Console.WriteLine("Du är ute och går på promenad, när någon kommer fram till dig.");
    Console.WriteLine($"{oppName}: Har do cigg?");
    Console.WriteLine("Vad svarar du? [y/n] ");
    begin = Console.ReadLine().ToLower();
    while (begin != "y" && begin != "n")
    {
        Console.WriteLine("Du måste skriva antingen y eller n");
        begin = Console.ReadLine().ToLower();
    }
    Console.Clear();
    if (begin == "n")
    {
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + ": Nej tyvärr, jag har inte det är jag rädd");
        Console.WriteLine($"{oppName}: EY DU JAG KNOLLAR DIG");
        Console.WriteLine($"{oppName} bitchslapar dig!");
        Console.WriteLine();
        int winCheck = Fight(100, 100, 1, name, oppName);
        Console.Clear();
        if (winCheck == 1){
            Console.WriteLine("Grattis "+ char.ToUpper(name[0]) + name.Substring(1) + ", du vann!");
        }
        else{
            Console.WriteLine($"Tyvärr " + char.ToUpper(name[0]) + name.Substring(1) + ", du förlorade!");
        };
    }
    else
    {
        Console.WriteLine(char.ToUpper(name[0]) + name.Substring(1) + ": Jo men det tror jag!");
        Console.WriteLine($"Du sträcker ned handen i fickan, och när {oppName} inte tittar gör du dig redo att slåss!");
        int winCheck = Fight(100, 100, 0, name, oppName);
        Console.Clear();
        if (winCheck == 1){
            Console.WriteLine("Grattis "+ char.ToUpper(name[0]) + name.Substring(1) + ", du vann!");
        }
        else{
            Console.WriteLine($"Tyvärr " + char.ToUpper(name[0]) + name.Substring(1) + ", du förlorade!");
        };
    }
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
Console.WriteLine("Tack för att du spelade!");
Console.WriteLine("Tryck enter för att stänga programmet.");
Console.ReadLine();