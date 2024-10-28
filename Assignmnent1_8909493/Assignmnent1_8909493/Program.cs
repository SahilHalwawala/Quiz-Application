using System.Drawing;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Assignment1_8909493
{

    internal class Program
    {

        static void Main(string[] args)
        {
            //Starting Code for the Quiz 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("------------Welcome to the Quiz Game App!------------");
            Console.WriteLine("------Do you want to start quiz or exit? (s/e)-------");
            string userChoice = Console.ReadLine().ToLower(); ;
            Console.WriteLine($"User input: {userChoice}");
            Console.WriteLine("-----------------------------------------------------");



            // Loop for the timer if user enters "yes"
            if (userChoice.ToLower() == "s")
            {

                for (int x = 5; x >= 1; x--)
                {
                    Console.Clear();
                    Console.WriteLine($"Your Quiz will start in {x} Seconds");
                    Thread.Sleep(1000);

                }

                Console.Clear();
                //Contains Whole quiz Information
                Console.ForegroundColor = ConsoleColor.White;
                QuizInformation();

                retakeQuiz();


            }
            else if (userChoice.ToLower() == "e")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                Main(args);

            }


            
            static void QuizInformation()
            {
                //Create Question
                string[] questions =
                {
                "What is the Capital of Canada?",
                "What is acrophobia a fear of?",
                "What city is known as The Eternal City?",
                "Which is the only continent with land in all four hemispheres?",
                "How many bones do we have in an ear?"
                };

                //Create Answer
                string[] ans =
                {
               "A. Oshawa  \nB.Ottawa   \nC.Toronto   \nD.Kitchener",
               "A. Water  \nB.Fire   \nC.Height   \nD.Sleep",
               "A.Paris  \nB.Rome   \nC.Italy   \nD.India",
               "A.Canada  \nB.Asia   \nC.Denmark   \nD.Africa",
               "A.1  \nB.2   \nC.3   \nD.4"
                  };

                string[] correct = { "B", "C", "B", "D", "C" };
                List<string> answersList = new List<string>();
                double score = 0;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Welcome to the Quiz Trivia!! All the Best ");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Questions--" + (i + 1));
                    Console.WriteLine(questions[i]);
                    Console.WriteLine(ans[i]);

                    Console.WriteLine("Please Enter the answer(A ,B ,C, D or To skip press S");

                    string playerAnswer = Console.ReadLine().ToUpper();
                    if (playerAnswer == "s" || playerAnswer == "S")
                    {
                        answersList.Add("s");
                        Console.WriteLine("Question Skipped");

                        continue;
                    }

                    answersList.Add(playerAnswer);
                    if (playerAnswer == correct[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your answer: {playerAnswer}");
                        Console.WriteLine($"Correct answer: {correct[i]}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Your answer: {playerAnswer}");
                        Console.WriteLine($"Correct answer: {correct[i]}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
                Console.WriteLine("-----------------------------------------------------");



                for (int i = 0; i < questions.Length; i++)
                {
                    if (correct[i] == answersList[i])
                    {

                        score++;
                    }
                    else if (answersList[i] == "s")
                    {
                        score = score;
                    }
                    else if (correct[i] != answersList[i])
                    {
                        score -= 0.25;
                    }
                }
                Console.WriteLine("\n");
                double percentage = Math.Round((score / questions.Length) * 100, 2);
                Console.WriteLine("-------------------REPORT--------------------");

                Console.WriteLine("Your Score is: " + score + "/" + questions.Length);
                if (score > 0)
                {

                    Console.WriteLine($"Total percentage:{percentage}%");
                    Console.WriteLine($"Congratulations!! You Passed the Quiz By {percentage}%");

                }
                else if (score < 0)
                {

                    Console.WriteLine("Total percentage: 0%");
                    Console.WriteLine("You Failed the Quiz:(");

                }

                Console.WriteLine("Quiz Done");
                Console.WriteLine("-----------------------------------------------------");
            }



            static void retakeQuiz()
            {
                Console.WriteLine("\n");
                string userChoiceAgain;

                do
                {
                    Console.WriteLine("Do you want to retake the exam?");
                    userChoiceAgain = Console.ReadLine().ToLower();

                    if (userChoiceAgain.ToLower() == "y")
                    {
                        for (int x = 5; x >= 1; x--)
                        {
                            Console.Clear();
                            Console.WriteLine($"Your Quiz will restart again in {x} Seconds");
                            Thread.Sleep(1000);
                        }
                        QuizInformation();
                    }
                    else if (userChoiceAgain.ToLower() == "n")
                    {
                        Console.WriteLine();
                    }
                } while (userChoiceAgain != "n");
            }
        }
    }
}

