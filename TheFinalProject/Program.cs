namespace TheFinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug debug = new Debug();
            //Debug generates large quantity of random items
            // debug.RunDebug();

            //Debug2 allows the admin to create specific items ahead of starting
            //the program.
            debug.RunDebug2();


            Console.WriteLine("DUE TO LACK OF KNOWLEDGE FROM THE IT DEPARMENT IF YOU INPUT A LETTER DURING A MENU CHOICE IT " +
                "\nWILL ALWAYS RESULT IN THE VALUE 0 AND RETURN YOU TO THE PREVIOUS MENU");
            Console.WriteLine("\n\nPRESS ANY BUTTON TO CONTINUE...");
            Console.ReadLine(); 
            Console.Clear();
            Menu.GoToMenu();
           

        }
    }
}
