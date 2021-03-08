using System;
using System.Collections.Generic;
using System.Text;
using JobSearch.APP.Models;
using JobSearch.APP.Services;
using JobSearch.APP.Utility.Load;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class Register : ContentPage
	{
		private UserService _service;

		public Register()
		{
			InitializeComponent();
			_service = new UserService();
		}

		void GoBack(System.Object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}

		private async void SaveAction(System.Object sender, System.EventArgs e)
		{
			TxtMessages.Text = String.Empty;
			string name = TxtName.Text;
			string email = TxtEmail.Text;
			string password = TxtPassword.Text;

			User user = new User() { Name = name, Email = email, Password = password };

			await Navigation.PushPopupAsync(new Loading());

			ResponseService<User> responseService = await _service.AddUser(user);

			if (responseService.IsSuccess)
			{
				App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
				await App.Current.SavePropertiesAsync();

				App.Current.MainPage = new NavigationPage(new Start());
			}
			else
			{
				if (responseService.StatusCode == 400)
				{
					//await DisplayAlert("Ops!", "Nenhum usuário encontrado!", "OK");

					StringBuilder sb = new StringBuilder();

					foreach (var dicKey in responseService.Errors)
					{
						foreach (var message in dicKey.Value)
						{
							sb.AppendLine(message);
						}
					}

					TxtMessages.Text = sb.ToString();
				}
				else
				{
					await DisplayAlert("Ops!", "Ocorreu um erro inesperado! Tente Novamente mais tarde.", "OK");
				}

			}

			await Navigation.PopAllPopupAsync();
		}
	}
}