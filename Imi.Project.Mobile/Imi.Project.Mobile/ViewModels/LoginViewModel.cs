using FreshMvvm;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Imi.Project.Mobile.Domain.Models;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.ViewModels
{
	public class LoginViewModel : FreshBasePageModel
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public LoginViewModel()
		{

		}

		public ICommand LoginCommand => new Command(
			async () =>
			{
				if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
				{
					try
					{
						// Attempt to dodge SSL certificate validation error
						System.Net.ServicePointManager.ServerCertificateValidationCallback +=
							(sender, certificate, chain, sslPolicyErrors) => true;

						var loginData = new
						{
							Email = Email,
							Password = Password
						};

						var jsonData = JsonConvert.SerializeObject(loginData);
						var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

						using (var httpClient = new HttpClient())
						{
							var apiUrl = "https://localhost:5001/api/Users/api/auth/login";

							var response = await httpClient.PostAsync(apiUrl, content);
							if (response.IsSuccessStatusCode)
							{
								var responseContent = await response.Content.ReadAsStringAsync();
								var tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(responseContent);

								// Store token
								await SecureStorage.SetAsync("JWTBearer", tokenResponse.Token);

								await CoreMethods.PushPageModel<MenuViewModel>(true);
							}
							else
							{
								// Authentication failure
								await CoreMethods.DisplayAlert("Login Failed", "Incorrecte gegevens.", "OK");
							}
						}
					}
					catch (HttpRequestException ex)
					{
						await CoreMethods.DisplayAlert("Error", "An error occurred: " + ex.Message + ex.InnerException, "OK");
					}
				}
				else
				{
					await CoreMethods.DisplayAlert("Error", "Vul alle velden in.", "OK");
				}
			});
	}
}

