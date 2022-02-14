// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    private static bool swapped = true;
    private static List<Game> games = new();
    

    public static void Main()
    {
        Load();
        foreach (Game s in games)
        {
            Console.WriteLine(s);
        }
        while (true)
        {
            Console.WriteLine("Input Game.");
            Game game = new Game();
            game.gameName = Console.ReadLine();
            Console.WriteLine("Input How Many Hours Will It Take To Finish.");
            game.howLongWillitTake = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input How much do you want to play it.");
            game.howMuchYouWantToPlayIt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            games.Add(game);
            Console.WriteLine("Press E To Stop or anything else to continue ");
            if (Console.ReadLine()== "E")
            {
                break;
            }
        }
        SortBubbleway();
        foreach (Game s in games)
        {
            Console.WriteLine(s);
        }
        Save();
    }
    

    static void SortBubbleway()
    {
        while (swapped)
        {
            Game temp;
            swapped = false;

            for (int v = 1; v < games.Count; v++)
            {
                if (games[v - 1].totalScore < games[v].totalScore)
                {
                    temp = games[v - 1];
                    games[v - 1] = games[v];
                    games[v] = temp;
                    swapped = true;
                }
            }
        }
    }

    private struct Game
    {
        public string gameName { get; set; }
        public int howMuchYouWantToPlayIt { get; set; }
        public int howLongWillitTake { get; set; }
        public int totalScore => howLongWillitTake + howMuchYouWantToPlayIt;


        public override string ToString()
        {

            return
                $"{gameName} , Hours: {howLongWillitTake} , Score: {howMuchYouWantToPlayIt} , TotalScore: {totalScore}";

        }
    }

    private static void Save()
    {
        StreamWriter save = new StreamWriter("Save.txt");
        foreach (var VARIABLE in games)
        {
            save.WriteLine(VARIABLE.gameName);
            save.WriteLine(VARIABLE.howLongWillitTake);
            save.WriteLine(VARIABLE.howMuchYouWantToPlayIt);
        }
        save.Close();
        
    }

    private static void Load()
    {
        StreamReader loader = new StreamReader("Save.txt");
        for (int i = 0; i < File.ReadLines("Save.txt").Count()/3; i++)
        {
            Game game = new Game();
            game.gameName = loader.ReadLine();
            
            game.howLongWillitTake = Convert.ToInt32(loader.ReadLine());
            
            game.howMuchYouWantToPlayIt = Convert.ToInt32(loader.ReadLine());
            
            games.Add(game);
        }
        
        loader.Close();
        
    }
}