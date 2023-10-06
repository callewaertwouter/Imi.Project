using Microsoft.AspNetCore.Components;

namespace Imi.Project.Blazor.Models.Concepts
{
	// Naming this ChoiceBase instead of Choice.cs else it might clash names with Choice.razor
	public class ChoiceBase : ComponentBase
	{
		[Parameter]
		public string Choice { get; set; } = string.Empty;

		[Parameter]
		public EventCallback<string> OnSelectedChoice { get; set; }

		protected async void SelectChoice()
		{
			await OnSelectedChoice.InvokeAsync(Choice);
		}
	}
}