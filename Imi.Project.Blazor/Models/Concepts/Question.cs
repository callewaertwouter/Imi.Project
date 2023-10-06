namespace Imi.Project.Blazor.Models.Concepts
{
    public class Question : BaseEntity
    {
        public string QuestionTitle { get; set; } = string.Empty;

        public IEnumerable<string> Choices { get; set; } = new List<string>();

        public string Answer { get; set; } = string.Empty;
    }
}