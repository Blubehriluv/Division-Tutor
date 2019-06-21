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
            int userAttempts = 0;
            Console.WriteLine("Welcome to the Math Tutor!");
            Console.WriteLine("\nToday we will be practicing division.");
            Console.WriteLine("Complete as many examples as you like.");
            Console.WriteLine("Use 'q' to quit");

            spawnProblem();


            void spawnProblem()
            {
                Random rand = new Random();
                int numOne = rand.Next(1, 12);
                int numTwo = rand.Next(1, 12);
                int placeHold;
                userAttempts = 0;

                placeHold = numOne * numTwo;
                numOne = placeHold;

                Console.WriteLine();
                Console.WriteLine("Please solve the following equation:");
                Console.WriteLine("{0} / {1} = ", numOne, numTwo);

                getAnswer(numOne, numTwo);

            }

            void getAnswer(int numOne, int numTwo)
            {
                string userAnswer;
                userAnswer = Console.ReadLine();

                if (userAnswer == "q")
                {
                    Console.WriteLine("The user is now quitting.");
                    Console.WriteLine("Thank you!");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }

                if (userAnswer != "q")
                {
                    double userNum = Convert.ToDouble(userAnswer);
                    checkAnswer(numOne, numTwo, userNum);
                }
            }

            void checkAnswer(int valueX, int valueY, double checkThis)
            {
                int cAnswer = valueX / valueY;
                
                while (checkThis != cAnswer)
                {
                    Console.WriteLine("Incorrect.  Please try again.");
                    userAttempts++;
                    Console.WriteLine("Attempts: {0}", userAttempts);
                    Console.WriteLine();
                    Console.WriteLine("{0} / {1} = ", valueX, valueY);
                    getAnswer(valueX, valueY);
                }

                userSuccess();
            }

            void userSuccess()
            {
                Console.WriteLine("Correct! Proceed to the next question.");
                Console.WriteLine();
                spawnProblem();
            }
        }
    }
}
