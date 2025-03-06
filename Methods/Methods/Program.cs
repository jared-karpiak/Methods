namespace Methods
{
    internal class Program
    {
        // Methods are a way to modularize our code.
        // They are distinct pieces of code that we can reuse again and again
        // Methods are everywhere in programming and are critical to developing good code.

        // There are several ways to create methods. This pirate program will show examples of how we can use methods to 
        // make our program more modular so we don't have to write the same code in multiple places.
        static void Main(string[] args)
        {
            PrintIntroduction();

            string name = Console.ReadLine();
            string pirateName = GeneratePirateName(name);

            // The distance we have sailed so far.
            int totalDistanceSailed = 0;

            Console.WriteLine($"Ye are now known as {pirateName}! Welcome aboard!");
            
            string[] crewMembers = new string[10];
            bool programRunning = true;
            Random rand = new Random();

            do
            {
                GenerateMenu(pirateName);

                // The variable 'userChoice' shares the same name as the variable
                // 'userChoice' in the GetUserChoice() method. We can do this because
                // each of those variables exist in different scopes.

                char userChoice = GetUserChoice();
                switch (userChoice)
                {
                    case 'p':
                        int amountPlundered = Plunder();
                        Console.WriteLine($"You plundered {amountPlundered} shillings.");
                        break;
                    case 'c':
                        Console.Write("What type of ship shall we commandeer? ");
                        string typeOfShip = Console.ReadLine();
                        int riskAttempt = rand.Next(5, 20);
                        Commandeer(typeOfShip, riskAttempt);
                        break;
                    case 's':
                        int distanceSailed = Sail(ref totalDistanceSailed);
                        Console.WriteLine($"Arrrrr. We have sailed {distanceSailed} miles.");
                        break;
                    case 'h':
                        HireCrewMember(crewMembers);
                        break;
                    case 'v':
                        ViewCrewMembers(crewMembers);
                        break;
                    case 'm':
                        MakePort(ref totalDistanceSailed);
                        break;
                    case 'u':
                        Console.WriteLine("You have surrendered to those British scallywags!\n");
                        programRunning = false;
                        break;

                }

            } while (programRunning);
        }

        // a region will allow you to group blocks of code together, making the code
        // more organized and easier to read.
        // make sure each region has a meaningful name that describes the code
        // inside it.

        #region UI methods

        // This is a method summary. It should contain:
        //  - The method name
        //  - A short description of what your method does
        //  - The parameters it takes, if any
        //  - The values it returns, if any
        // Every method should have a method summary.

        /// <summary>
        /// Name: GenerateMenu
        /// Purpose: Print the list of options to the user a retrieves a choice from the user.
        /// </summary>
        /// <param name="pirateName">The pirate's name</param>
        /// <returns>Nothing</returns>

        // A method definition is made up of several parts:
        // The Return Type: the data type of the value that is returned by the method.
        // - If there is no return value then the method is marked as "void"
        // - The method will use the "return" statement to return a value.
        // - Only one value can be returned using the return statement.

        // The Method Name: the name of the method
        // - It must follow UpperCamelCase naming conventions.
        // - It must have a meaningful name

        // Parameters:
        // - Variables that contain any variables sent to the method.
        // - A method can have many parameters, but should only have as many
        //   as necessary.

        //  data type | Name |     Parameters
        //       |        |             |
        //       V        V             V
        static void GenerateMenu(string pirateName)
        {
            Console.WriteLine($"""
                
                Alrighty {pirateName}! What shall we do this fine day?
                [P] Plunder
                [S] Sail
                [C] Commandeer a ship
                [H] Hire crew member
                [V] View crew members
                [M] Make port
                [U] Surrender to the British (quit program)
                
                """);
        }
        /// <summary>
        /// Name: GetUserChoice
        /// Purpose: Get's input from a user.
        /// </summary>
        /// <returns>the user's input</returns>
        static char GetUserChoice()
        {
            char[] validChoices = { 'p', 's', 'c', 'h', 'v', 'm', 'u' };
            bool validResponse = false;
            char userChoice;
            
            do
            {
                Console.Write("Enter a choice: ");
                validResponse = char.TryParse(Console.ReadLine().ToLower(), out userChoice);
                
                if (!validResponse || !validChoices.Contains(userChoice))
                {
                    Console.WriteLine("That is not a valid choice. Try again!");
                    validResponse = false;
                }
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
                "One-eye",
                "The Purple Bearded",
                "No Foot",
                "Cotton",
                "Peg-leg",
                "The Wears a Silly Hat",
                "Cannon Ball",
                "Barbossa",
                "Gold Tooth",
                "Skal E. Wag"
            };
            int randomNickNameIndex = rand.Next(0, pirateNickNames.Length);
            string nickName = $"{name} {pirateNickNames[randomNickNameIndex]}";

            return nickName;
        }
        /// <summary>
        /// Name: PrintIntroduction()
        /// Purpose: Print the introduction to the console.
        /// </summary>
        static void PrintIntroduction()
        {
            Console.WriteLine("ARRRR Matey. Welcome to the world of Pirates!");
            Console.WriteLine("What do they call ye?");
        }

        #endregion

        #region Criminal Methods

        /** SCOPE **/
        // Scope is a term in programming that refers to the accessibility of
        // a variable.
        // Some variables may only be accessed in certain blocks of code, depending
        // on their scope.

        // For example, if a method creates a new variable inside of it, then that
        // variable only exists inside of the method. Other methods or parts of
        // the program will not be able to access it because it doesn't exist outside
        // of the method.
        // This is known as "method scope" or "function scope"

        /// <summary>
        /// Name: Plunder
        /// Purpose: Plunder a random amount of shillings from a specified location
        /// </summary>
        /// <returns>The amount plundered</returns>
        static int Plunder()
        {
            // In this method the placeToPlunder, rand, and amountPlundered
            // variables are all method scope since they were declared here.
            // Other methods cannot access these variables.

            Console.Write("Where shall we plunder today?");
            string placeToPlunder = Console.ReadLine().Trim();

            Console.WriteLine($"Arr matey. Let us plunder {placeToPlunder}!");

            // There is another variable in GeneratePirateName() called 'rand',
            // but it is okay to create one here because it is in a different scope.

            Random rand = new Random();

            int amountPlundered = rand.Next(0, 1001);

            if (amountPlundered < 100)
            {
                Console.WriteLine($"Arr... not much plunder today. Terrible times.");
            }
            else if (amountPlundered >= 100 && amountPlundered < 500) 
            {
                Console.WriteLine($"Arr. A fairly decent number.");
            }
            else
            {
                Console.WriteLine($"ARR! A mighty haul! We are rich! ");
            }
            return amountPlundered;
        }
        /// <summary>
        /// Name: Commandeer
        /// Purpose: Attempt to commandeer a ship
        /// </summary>
        /// <param name="typeOfShip">The type of ship we are going to commandeer (merchant, navy, etc.)</param>
        /// <param name="riskAttempt">The difficulty it will be to capture.</param>
        static void Commandeer(string typeOfShip, int riskAttempt)
        {
            Console.WriteLine($"Time to commandeer a {typeOfShip} ship!");
            if (riskAttempt > 15)
            {
                Console.WriteLine($"Arr. This be risky. May the gods be with us.");
            }
            else
            {
                Console.WriteLine($"Avast!");
            }

            Random rand = new Random();

            int rollValue = rand.Next(1, 21);
            bool success = rollValue > riskAttempt;

            if (success)
            {
                Console.WriteLine($"Congratulations! You have added a new ship to your fleet!");
            }
            else
            {
                Console.WriteLine($"Too bad. Better luck next time!");
            }
        }

        #endregion

        #region Crew Methods
        /// <summary>
        /// Name: HireCrewMember
        /// Purpose: Add a new member to the crew.
        /// </summary>
        /// <param name="crew">The array of the current crew members</param>
        static void HireCrewMember(string[] crewMembers)
        {
            // the 'crew' parameter is an array of strings.
            bool validChoice;
            Console.WriteLine("Time to hire a new crew member.");
            
            do
            {
                Console.Write("Which position would you like to hire for (0-9): ");
                validChoice = int.TryParse(Console.ReadLine(), out int position);
                if (!validChoice || position < 0 || position > 9)
                {
                    Console.WriteLine("Arr. That is not a valid choice. Try again!");
                    validChoice = false;
                }    
                else
                {
                    string currentMember = crewMembers[position];
                    string newCrewMember;
                    if (!string.IsNullOrWhiteSpace(currentMember))
                    {
                        Console.WriteLine($"Aye. {currentMember} is useless. Let us be rid of them.");
                    }

                    do
                    {
                        Console.Write("What is the new crew member's name? ");
                        newCrewMember = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(newCrewMember));

                    crewMembers[position] = newCrewMember;

                    Console.WriteLine($"We have hired {newCrewMember}. Welcome aboard!");
                }
            } while (!validChoice);
        }
        /// <summary>
        /// Name: ViewCrewMembers
        /// Purpose: List all of the members of the crew
        /// </summary>
        /// <param name="crew">Array of all of the crew members.</param>
        static void ViewCrewMembers(string[] crew)
        {
            Console.WriteLine("Here is a list of your crew members:\n-------");
            for (int i = 0; i < crew.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(crew[i]))
                    Console.WriteLine(crew[i]);
            }
            Console.WriteLine();
        }

        #endregion

        #region Navigation Methods
        /*
         Passing by Reference or passing by Value.

        In order to pass a variable by reference into a method, the 'ref' keyword
        must be used when we define the parameter, otherwise the parameter will be passed
        by value.
         
         */
        /// <summary>
        /// Name: Sail
        /// Purpose: Sail the ship a given distance and add that distance to the 
        /// total distance travelled so far.
        /// </summary>
        /// <param name="totalDistanceSailed"></param>
        /// <returns>The distance sailed</returns>
        static int Sail(ref int totalDistanceSailed)
        {
            Console.WriteLine($"We have sailed {totalDistanceSailed} miles so far.");
            int distanceSailed;
            bool validDistance = false;
            do
            {
                Console.Write($"How many miles shall we sail today? ");
                validDistance = int.TryParse(Console.ReadLine(), out distanceSailed);
            } while (!validDistance);

            totalDistanceSailed += distanceSailed;
            return distanceSailed;
        }
        /// <summary>
        /// Name: MakePort
        /// Purpose: Resets the totalDistanceSailed to 0
        /// </summary>
        /// <param name="totalDistanceSailed">The distance that the ship has sailed without making port</param>
        static void MakePort(ref int totalDistanceSailed)
        {
            Console.WriteLine($"Aye. The crew could use some shore leave, we have been sailed {totalDistanceSailed} miles.");
            totalDistanceSailed = 0;
        }

        #endregion
    }
}
