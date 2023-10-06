using Microsoft.AspNetCore.Components;

namespace Imi.Project.Blazor.Models.Concepts
{
    // Giving this class the name "QuizBase" so it doesn't have matching names with Quiz.razor
    public class QuizBase : ComponentBase
    {
        public List<Question> Questions { get; set; } = new List<Question>();

        protected int questionIndex = 0;
        protected int questionCount = 1;
        protected int quizScore = 0;

        protected override Task OnInitializedAsync()
        {
            LoadQuestions();

            return base.OnInitializedAsync();
        }

        protected void SelectedChoice(string choice)
        {
            if (choice == Questions[questionIndex].Answer)
            {
                quizScore++;
            }
            questionIndex++;
            questionCount++;
        }

        private void LoadQuestions()
        {
            List<Question> questionsList = new List<Question>()
            {
            new Question
            {
                QuestionTitle = "Tot welke soort behoort keukenzout?",
                Choices = new List<string>() { "Kruid", "Smaakversterker", "Groente" },
                Answer = "Smaakversterker"
            },

            new Question
            {
                QuestionTitle = "Waar komen hotdogs origineel van?",
                Choices = new List<string>() { "Amerika", "Engeland", "Ierland", "Duitsland" },
                Answer = "Duitsland"
            },

            new Question
            {
                QuestionTitle = "Wat betekent het japanse woord 'Nori'?",
                Choices = new List<string>() { "Zeewier", "Boter", "Mossel", "Vogelborst" },
                Answer = "Zeewier"
            },

            new Question
            {
                QuestionTitle = "Welke saus wordt traditioneel gebruikt voor eieren Benedict?",
                Choices = new List<string>() { "Witte saus", "Hollandaisesaus", "Barbecausaus" },
                Answer = "Hollandaisesaus"
            },

            new Question
            {
                QuestionTitle = "Waar komt graan vandaan?",
                Choices = new List<string>() { "Van de bomen", "Van de struiken", "Van de velden", "Van de dieren" },
                Answer = "Van de velden"
            },

            new Question
            {
                QuestionTitle = "Van welk continent komt Chicken Tikka Masala?",
                Choices = new List<string>() { "Europa", "Azië", "Afrika" },
                Answer = "Azië"
            },

            new Question
            {
                QuestionTitle = "Wat is het hoofdingedriënt van bier?",
                Choices = new List<string>() { "Hops", "Graan", "Water", "Alcohol" },
                Answer = "Water"
            },

            new Question
            {
                QuestionTitle = "Dat Japanners van vis houden, is algemene kennis. Maar naar welke vissoort verwijst 'Fugu'?",
                Choices = new List<string>() { "Tonijn", "Inktvis", "Kogelvis", "Dolfijn" },
                Answer = "Kogelvis"
            },

            new Question
            {
                QuestionTitle = "Is deze quiz de beste quiz ooit?",
                Choices = new List<string>() { "Jaaa!!!", "Nee zeg..." },
                Answer = "Jaaa!!!"
            }
        };

            Questions.AddRange(questionsList);

            Random random = new Random();
            var selectedQuestions = questionsList.OrderBy(x => random.Next()).Take(3).ToList();
            Questions = selectedQuestions;
        }
    }
}