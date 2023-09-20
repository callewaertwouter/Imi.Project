using System.Collections.Generic;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class TheMealDbApiResponse
    {
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        public string IdMeal { get; set; }
        public string StrMeal { get; set; }
        public string StrCategory { get; set; }
        public string StrInstructions { get; set; }
    }
}
