using System;
using System.Collections.Generic;
using Shared;
using System.Threading; 
using PlayerClass;

public class OneArmBandit 
{
  public void RunMachine(Player p) {
    Random randomGenerator = new Random();
    int differenceToTheAmountOfCoins = animatePlay(10 + randomGenerator.Next(15), p.AmountOfInsertedCoins);
    p.AmountOfInsertedCoins = p.AmountOfInsertedCoins + differenceToTheAmountOfCoins;
  }

  public int animatePlay(int numberOfFrames, int numberOfCoins){
    int speedOfRotation = 0;
    Boolean match = false;

    while(numberOfFrames > 0){
      Console.Clear();
      for(int rows = 0; rows < 3; rows++){
      Console.WriteLine("-------------------------------------");
        if(rows==1){
          match = ShowLine();
        } else {
          ShowLine();
        }
      }
      Console.WriteLine("-------------------------------------");

      numberOfFrames--;
      speedOfRotation++;

      Thread.Sleep(speedOfRotation * 50); 
    }

    return resultOfTheGame(match);
  }
  
  public Boolean ShowLine(){    
    Random randomGenerator = new Random();
    int randomInt = randomGenerator.Next(Enum.GetNames(typeof(Symbole)).Length);
    Symbole firstObject = (Symbole) randomInt;
    randomInt = randomGenerator.Next(Enum.GetNames(typeof(Symbole)).Length);
    Symbole secondObject = (Symbole) randomInt;
    randomInt = randomGenerator.Next(Enum.GetNames(typeof(Symbole)).Length);
    Symbole thirdObject = (Symbole) randomInt;

    string firstObjectString = addSpacesToTextForAligment(firstObject.ToString());
    string secondObjectString = addSpacesToTextForAligment(secondObject.ToString());
    string thirdObjectString = addSpacesToTextForAligment(thirdObject.ToString());

    Console.WriteLine(String.Format("|{0,11}|{1,11}|{2,11}|", firstObjectString, secondObjectString, thirdObjectString));
    if(firstObject == secondObject && secondObject == thirdObject){
      return true;
    } else {
      return false;
    }
  }

  public string addSpacesToTextForAligment(string text){
    for(int i=0; i < (10 - text.Length)/2; i++){
      text = text + " ";
    }
    return text + " ";
  }

  public int resultOfTheGame(Boolean doesRowMatch){
   if(doesRowMatch){
      Random randomGenerator = new Random();
      int wonCoins = randomGenerator.Next(10) + 3;
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine($"Gratulacje! Wygrałeś! Otrzymujesz: {wonCoins} monet");
      return wonCoins;
    } else {
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Przegrałeś! Tracisz jedną monetę.");
      return -1;
    }
  }

}