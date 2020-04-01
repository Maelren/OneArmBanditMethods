using System;
using PlayerClass;

class MainClass 
{
  public static void Main (string[] args) 
  {
    Player p = new Player();
    MainClass.Greetings(p);
    OneArmBandit machine = new OneArmBandit();
    while(true)
    {
      Console.WriteLine(p.PlayerName + p.AmountOfInsertedCoins.ToString());
      machine.RunMachine(p);
      if(p.AmountOfInsertedCoins <= 0){
        break;
      }
      Console.WriteLine();
      Console.WriteLine($"Koniec tego losowania, zostało Ci {p.AmountOfInsertedCoins} monet, kliknij enter aby uruchomić kolejne losowanie!");
      Console.ReadLine();
    }
      Console.WriteLine();
    Console.WriteLine ("Skończyły Ci się monety, zapraszamy ponownie z większą gotówką!");
  }

  public static void Greetings(Player p)
  {
    Console.WriteLine ("Witaj graczu, chcesz pociągnąć mnie za rękę? Najpierw zdradź mi swe imię.");
    p.PlayerName = Console.ReadLine();
    Console.WriteLine ("Powiedz mi, " + p.PlayerName + ", ile monet chciałbyś wydać?");
    p.AmountOfInsertedCoins = int.Parse(Console.ReadLine());
  }
}
