using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division_Tutor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates the variable that will hold user attempts and refresh with each new problem
            int userAttempts = 0;

            //Program introduction
            Console.WriteLine("Welcome to the Math Tutor!");
            Console.WriteLine("\nToday we will be practicing division.");
            Console.WriteLine("Complete as many examples as you like.");
            Console.WriteLine("Use 'q' to quit");

            //Gives the user a problem
            SpawnProblem();

            //After answering the current problem correctly, this gives the user a new one
            void SpawnProblem()
            {
                //Spawns two numbers randomly
                Random rand = new Random();
                int numOne = rand.Next(1, 12);
                int numTwo = rand.Next(1, 12);
                int placeHold;
                userAttempts = 0;

                //Assigned the product to a placeholder to serve as the first, larger integer
                //This is so that the user can work with all whole numbers from the 12 x 12 timetable
                placeHold = numOne * numTwo;
                numOne = placeHold;

                //Prints the current equation for the user
                Console.WriteLine();
                Console.WriteLine("Please solve the following equation:");
                Console.WriteLine("{0} / {1} = ", numOne, numTwo);

                //Passes the variables to the method that gets answers
                GetAnswer(numOne, numTwo);

            }

            //Checks for the user to quit or submit a numeric answer
            void GetAnswer(int numOne, int numTwo)
            {
                string userAnswer;
                userAnswer = Console.ReadLine();

                //If the user enters 'q', they can quit the program
                if (userAnswer == "q")
                {
                    Console.WriteLine("The user is now quitting.");
                    Console.WriteLine("Thank you!");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }

                //If the user submits literally anything else, they can answer the problem
                else if (userAnswer != "q")
                {
                    int userNum;
                    //The problem numbers and the user answer is passed to be checked
                    try
                    {
                        userNum = Convert.ToInt32(userAnswer);
                        CheckAnswer(numOne, numTwo, userNum);
                        //userNum = Int32.Parse(userAnswer);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a number or use 'q' to quit.");
                        GetAnswer(numOne, numTwo);
                    }
                }
            }

            //This method checks the user's answer
            void CheckAnswer(int valueX, int valueY, int checkThis)
            {
                int cAnswer = valueX / valueY;
                
                //While the answer is wrong, the user will be prompted the question again
                while (checkThis != cAnswer)
                {
                    Console.WriteLine("Incorrect.  Please try again.");
                    //With every correct answer, the attempts are counted
                    userAttempts++;
                    Console.WriteLine("Attempts: {0}", userAttempts);
                    Console.WriteLine();
                    Console.WriteLine("{0} / {1} = ", valueX, valueY);
                    GetAnswer(valueX, valueY);
                }

                //This is triggered when the user is correct
                UserSuccess();
            }

            //Congratulatorily sends the user to the next question.
            void UserSuccess()
            {
                Console.WriteLine("Correct! Proceed to the next question.");
                Console.WriteLine();
                SpawnProblem();
            }
        }
    }
}
