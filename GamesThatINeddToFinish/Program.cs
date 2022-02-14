// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

public class Program
{
    private static bool swapped = true;
    private static Game[] games = new Game[4];

    public static void Main()
    {
        for (int i = 0; i < games.Length; i++)
        {
            Console.WriteLine("Input Game.");
            games[i].gameName = Console.ReadLine();
            Console.WriteLine("Input How Many Hours Will It Take To Finish.");
            games[i].howLongWillitTake = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input How much do you want to play it.");
            games[i].howMuchYouWantToPlayIt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
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

            for (int v = 1; v < games.Length; v++)
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
}