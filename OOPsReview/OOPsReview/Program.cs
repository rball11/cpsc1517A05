using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        static void Main(string[] args)
        {

            //new causes an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance


            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance
            Turn theTurn;


            //new cause the constructor of a class to execute
            //   and a physical instance to be created
            Die player1 = new Die();    //default constructor
            Die player2 = new Die(6, "Green");  //greedy constructor

            //track the gameplays
            List<Turn> rounds = new List<Turn>();

            string menuChoice = "";
            do
            {
                //Console is a static class
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Die is a non-static class
                                player1.Roll();                                //generate a new FaceValue
                                player2.Roll();                                //generate a new FaceValue

                                // save the roll 
                                //method a) default constructor and individual setting
                                theTurn = new Turn();
                                theTurn.Player1Roll = player1.FaceValue;
                                theTurn.Player2Roll = player2.FaceValue;
                                //method b) greedy constructor
                                //theTurn = new Turn(player1.FaceValue, player2.FaceValue);

                                //display the round results
                                Console.WriteLine("Player1 rolled {0}", player1.FaceValue);
                                Console.WriteLine("Player2 rolled {0}", player2.FaceValue);
                                if (player1.FaceValue > player2.FaceValue)
                                {
                                    Console.WriteLine("Player1 wins!");
                                }
                                else if (player2.FaceValue > player1.FaceValue)
                                {
                                    Console.WriteLine("Player2 wins!");
                                }
                                else
                                {
                                    Console.WriteLine("Draw!");
                                }
                                //track the round
                                rounds.Add(theTurn);
                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides))
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        player1.Sides = sides;
                                        player2.SetSides(sides);
                                      
                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                DisplayCurrentPlayerStats(rounds);
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                DisplayCurrentPlayerStats(rounds);
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");
        }//eomain

        public static void DisplayCurrentPlayerStats(List<Turn> rounds)
        {
            
            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins, losses, and draws
            foreach (Turn item in rounds)
            {
                if (item.Player1Roll > item.Player2Roll)
                {
                    wins1++;
                }
                else if (item.Player2Roll > item.Player1Roll)
                {
                    wins2++;
                }
                else
                {
                    draws++;
                }
            }

            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);
           
        }
    }
}
