using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizGame
{
    class Question
    {
        private static List<Question> eastQuestions = new List<Question>();
        private static List<Question> westQuestions = new List<Question>();
        private static List<Question> northQuestions = new List<Question>();
        private static List<Question> southQuestions = new List<Question>();
        public static Dictionary<string, List<Question>> quizDictionary = new Dictionary<string, List<Question>>();

        public Question(string question, string a1, string a2, string a3, string a4, string correct)
        {
            Answer = new string[4];
            QuestionText = question;
            Answer[0] = a1;
            Answer[1] = a2;
            Answer[2] = a3;
            Answer[3] = a4;
            CorrectAnswer = correct;
        }

        public string QuestionText { get; set; }
        public string[] Answer { get; set; }
        public string CorrectAnswer { get; set; }

        private static void LoadQuestions(string direction)
        {
            string question, a, b, c, d, correct;
            XDocument doc = XDocument.Load("Questions.xml");

            var quiz = from elements in doc.Element("Quiz").Elements(direction).Elements("Question") select elements;

            foreach (var item in quiz)
            {
                question = item.Element("QuestionText").Value;
                a = item.Element("Answer1").Value;
                b = item.Element("Answer2").Value;
                c = item.Element("Answer3").Value;
                d = item.Element("Answer4").Value;
                correct = item.Element("CorrectAnswer").Value;


                switch (direction)
                {
                    case "East":
                        eastQuestions.Add(new Question(question, a, b, c, d, correct));
                        break;
                    case "West":
                        westQuestions.Add(new Question(question, a, b, c, d, correct));
                        break;
                    case "South":
                        southQuestions.Add(new Question(question, a, b, c, d, correct));
                        break;
                    case "North":
                        northQuestions.Add(new Question(question, a, b, c, d, correct));
                        break;
                }
                
            }
        }

        public static void LoadAllQuestions()
        {
            LoadQuestions("East");
            quizDictionary.Add("East", eastQuestions);
            LoadQuestions("West");
            quizDictionary.Add("West", westQuestions);
            LoadQuestions("South");
            quizDictionary.Add("South", southQuestions);
            LoadQuestions("North");
            quizDictionary.Add("North", northQuestions);
        }

        public override string ToString()
        {
            return string.Format("{0}\nA.{1}\nB.{2}\nC.{3}\nD.{4}\n", QuestionText, Answer[0], Answer[1], Answer[2], Answer[3]);
        }
    }
}
