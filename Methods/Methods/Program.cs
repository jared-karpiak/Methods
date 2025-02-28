namespace Methods
{
    internal class Program
    {
        // Methods are a way to modularize our code. They are distinct pieces of code that we can reuse again and again
        // Methods are everywhere in programming and are critical to developing good code.

        //You have already been using methods in many places.
        // Console.WriteLine() and Console.ReadLine() are methods
        // Math.Pow() and Math.Sqrt() are methods
        // Even int.Parse() is a method.

        // There are several ways to create methods. This pirate program will show examples of how we can use methods to 
        // make our program more modular so we don't have to write the same code in multiple places.
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("ARRRRRR Matey. This be your introduction to the world o' Pirates!");
            Console.WriteLine("What do they call ye?");

            string name = Console.ReadLine();
            string pirateName = GeneratePirateName(name);
            char[] validChoices = { 'p', 's', 't', 'u' };
            bool programRunning = true;
            do
            {
                PrintMainOptions(pirateName);
            } while (programRunning);


        }
        // This is a method summary. It describes what your method does, parameters it takes, and its purpose
        // Every method should have a method summary.
        //     |
        //     |
        //     V
        /// <summary>
        /// Name: PrintOptions
        /// Purpose: Print the list of options to the user a retrieves a choice from the user.
        /// </summary>
        /// <param name="pirateName">The pirate's name</param>
        /// <returns>Nothing</returns>

        // A method is made up of several  parts.
        // The Return Type: the data type of the value that is returned by the method. If there is no return value then
        //                  the method is marked as "void"
        // The Method Name: the name of the method, it must follow UpperCamelCase naming conventions.
        // Parameters: Variables that contain any variables sent to the method.

        //  data type | Name |     Parameters
        //       |        |             |
        //       |        |             |
        //       V        V             V
        static void PrintMainOptions(string pirateName)
        {
            Console.WriteLine($"""
                Alrighty {pirateName}! What shall we do this fine day?
                [P] Plunder
                [S] Sail
                [T] Tell silly joke
                [U] Surrender to the British (quit program)
                """);
        }
        /// <summary>
        /// Name: GetUserChoice
        /// 
        /// </summary>
        /// <param name="validChoices">a list of the valid user inputs </param>
        /// <returns></returns>
        static char GetUserChoice(char[] validChoices)
        {
            bool validResponse = false;
            char userChoice;

            do
            {
                Console.Write("Enter a choice: ");
                validResponse = char.TryParse(Console.ReadLine().ToLower(), out userChoice);
                if (validChoices.Contains(userChoice))
                    validResponse = true;
                if (!validResponse)
                    Console.WriteLine("That is not a valid choice. Try again!");
            } while (!validResponse);

            return userChoice;
        }
        /// <summary>
        /// Name: GeneratePirateName
        /// Purpose: Adds a random nick name to the user's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A string that is the user's name and their nick name</returns>
        static string GeneratePirateName(string name)
        {
            Random rand = new Random();
            string[] pirateNickNames =
            {
                "The Vengeful",
                "The Boistrous",
                "The Corkscrew",
                "The Vacant",
                "The Confused",
                "The Drunk",
                "The Wears a Silly Hat"
            };
            int randomNickNameIndex = rand.Next(0, pirateNickNames.Length);
            string nickName = $"{name} {pirateNickNames[randomNickNameIndex]}";

            return nickName;
        }
    }
}
