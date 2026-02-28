using System;
class Dish
{
    public string Style { get; private set; }
    public string Protein { get; private set; }
    public string Vegetable { get; private set; }
    public string Starch { get; private set; }
    public string PresentationStyle { get; private set; }

    public int Taste { get; private set; }
    public int Presentation { get; private set; }
    public int Speed { get; private set; }

    public Dish(string style, string protein, string veg, string starch, string presentation)
    {
        Style = style;
        Protein = protein;
        Vegetable = veg;
        Starch = starch;
        PresentationStyle = presentation;

        CalculateScores();
    }

    private void CalculateScores()
    {
        Taste = 3;
        Presentation = 3;
        Speed = 3;


        ApplyStyleModifiers();
        ApplyIngredientModifiers();
        ApplyPresentationModifiers();

        Taste = Clamp(Taste);
        Presentation = Clamp(Presentation);
        Speed = Clamp(Speed);
    }

    private void ApplyStyleModifiers()
    {
        if (Style.Equals("Elegant", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 2;
            Presentation += 3;
            Speed -= 2;
        }
        else if (Style.Equals("Country", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 2;
            Presentation -= 2;
            Speed += 3;
        }
    }

    private void ApplyIngredientModifiers()
    {
        if (Protein.Equals("Steak", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 2;
            Presentation += 1;
            Speed -= 1;
        }
        else if (Protein.Equals("Salmon", StringComparison.OrdinalIgnoreCase))
        {
            Presentation += 1;
            Taste += 1;
        }
        else if (Protein.Equals("Chicken", StringComparison.OrdinalIgnoreCase))
        {
            Speed += 2;
            Presentation -= 1;
            Taste += 1;
        }

        if (Vegetable.Equals("Asparagus", StringComparison.OrdinalIgnoreCase))
        {
            Presentation += 1;
            Taste += 1;
        }
        else if (Vegetable.Equals("Broccoli", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 1;
            Speed += 1;
        }
        else if (Vegetable.Equals("Brussel Sprouts", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 1;
            Presentation += 1;
        }

        if (Starch.Equals("Pasta", StringComparison.OrdinalIgnoreCase))
        {
            Speed += 1;
        }
        else if (Starch.Equals("Rice", StringComparison.OrdinalIgnoreCase))
        {
            Presentation += 1;
        }
        else if (Starch.Equals("Potato", StringComparison.OrdinalIgnoreCase))
        {
            Taste += 1;
        }
    }

    private void ApplyPresentationModifiers()
    {
        if (PresentationStyle.Equals("Complicated", StringComparison.OrdinalIgnoreCase))
        {
            Presentation += 2;
            Speed -= 2;
        }
        else if (PresentationStyle.Equals("Quick", StringComparison.OrdinalIgnoreCase))
        {
            Speed += 2;
            Presentation -= 2;
        }
    }

    private int Clamp(int value)
    {
        return Math.Max(1, Math.Min(10, value));
    }
    public double AverageScore()
    {
        return Math.Round((Taste + Presentation + Speed) / 3.0);
    }
}
class Program
{
    static string chef()
    {
        Random rng =  new Random();
        int chefNo = rng.next(1,3);
        int chefScore;
        switch (chefNo)
        {
    case 1:
        Console.WriteLine("Count Dracula");
        chefScore = 9;
        break;

    case 2:
        Console.WriteLine("Alucard");
        chefScore = 7;
        break;

    case 3:
        Console.WriteLine("Van Helsing");
        chefScore = 5;
        break;
        }
    }
    static void Main()
    {
        // Story Setup/ Welcome
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Counts Cooking Showdown!\n");
        Console.WriteLine("What is your name challenger?\n");
        string playername = Console.ReadLine();
        Console.WriteLine("In the finals of this seasons show we have a showdown between two culinary greats!\n");
        Console.WriteLine("In the blue kitchen we have" + chef +"!\n");
        Console.WriteLine("In the red kitchen we have " + playername + "!\n");
        Console.WriteLine("Tonight we find out who is the best Chef!\n");
        Console.WriteLine("In this competition we are seeking refinement in the shortest time possible, Do you go for the extravagant meal or the quick home meal?\n");
        Console.WriteLine("Dishes are scored based on three metrics on a scale from 1-10\n");
        Console.WriteLine("These metrics will be Taste, Presentation, and Speed, you dont need to max every metric! Do what you think is most important for your Dish!\n");
        // Choosing the main dish you will create with looping on non valid selections
        string dishname;
        string protein;
        string veg;
        string starch;
        string presentation;

        // DISH SELECTION
        while (true)
        {
            Console.WriteLine("Choose your dish style: Elegant or Country\n");
            dishname = Console.ReadLine();

            if (dishname.Equals("Elegant", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You have chosen Elegant.\n");
                break;
            }
            else if (dishname.Equals("Country", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You have chosen Country.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter Elegant or Country.\n");
            }
        }

        // PROTEIN SELECTION
        while (true)
        {
            Console.WriteLine("Choose a protein: Chicken, Steak, or Salmon\n");
            protein = Console.ReadLine();

            if (protein.Equals("Chicken", StringComparison.OrdinalIgnoreCase) ||
                protein.Equals("Steak", StringComparison.OrdinalIgnoreCase) ||
                protein.Equals("Salmon", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(protein + " selected.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid protein choice.\n");
            }
        }

        // VEGETABLE SELECTION
        while (true)
        {
            Console.WriteLine("Choose a vegetable: Broccoli, Asparagus, or Brussel Sprouts\n");
            veg = Console.ReadLine();

            if (veg.Equals("Broccoli", StringComparison.OrdinalIgnoreCase) ||
                veg.Equals("Asparagus", StringComparison.OrdinalIgnoreCase) ||
                veg.Equals("Brussel Sprouts", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(veg + " selected.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid vegetable choice.\n");
            }
        }

        // STARCH SELECTION
        while (true)
        {
            Console.WriteLine("Choose a starch: Potato, Rice, or Pasta\n");
            starch = Console.ReadLine();

            if (starch.Equals("Potato", StringComparison.OrdinalIgnoreCase) ||
                starch.Equals("Rice", StringComparison.OrdinalIgnoreCase) ||
                starch.Equals("Pasta", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(starch + " selected.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid starch choice.\n");
            }
        }

        // PRESENTATION SELECTION
        while (true)
        {
            Console.WriteLine("Choose a Presentation style: Quick or Complicated\n");
            presentation = Console.ReadLine();

            if (presentation.Equals("Quick", StringComparison.OrdinalIgnoreCase) ||
                presentation.Equals("Complicated", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(presentation + " selected.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Presentation choice.\n");
            }
        }
        // FINAL SUMMARY
        Console.WriteLine("Your dish:");
        Console.WriteLine(dishname + " style with " + protein + ", " + veg + ", and " + starch + " presented " + presentation + ".");
        Dish playerDish = new Dish(
    dishname,
    protein,
    veg,
    starch,
    presentation
);

        Console.WriteLine("Taste: " + playerDish.Taste);
        Console.WriteLine("Presentation: " + playerDish.Presentation);
        Console.WriteLine("Speed: " + playerDish.Speed);
        Console.WriteLine("AVERAGE SCORE: " + playerDish.AverageScore());
        if (playerDish.AverageScore() >= chefScore)
            Console.WriteLine("Outstanding! You beat the chef!");
        else
            Console.WriteLine("Better luck next time! Maybe practice your plating.");
    }

}
