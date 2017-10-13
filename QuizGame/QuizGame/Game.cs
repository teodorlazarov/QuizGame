using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    

    class Game
    {

        private static Random random = new Random();
        private static string[] directions = { "East", "West", "South", "North" };
        private static int score = 0;

        public static void StartGame()
        {
            Question.LoadAllQuestions();

            for (int i = 0; i < 3; i++)
            {
                DisplayQuestion();
            }
            Console.WriteLine("GG, {0} score", score);
        }

        private static void DisplayQuestion()
        {
            List<Question> randomQuestion = Question.quizDictionary[directions[random.Next(4)]];
            Question currentQuestion = randomQuestion[random.Next(randomQuestion.Count)];
            Console.Write(currentQuestion);

            while (true)
            {
                char answer = Console.ReadKey().KeyChar;
                if (char.ToUpper(answer) == Convert.ToChar(currentQuestion.CorrectAnswer))
                {
                    Console.WriteLine("\nRight Answer!\n");
                    score += 10;
                    break;
                }
                else if (char.ToUpper(answer) >= 'A' && char.ToUpper(answer) <= 'D' && char.ToUpper(answer) != Convert.ToChar(currentQuestion.CorrectAnswer))
                {
                    Console.WriteLine("\nWrong Answer!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nWrong input\n");
                    continue;
                } 
            }
        } 
    }
}
