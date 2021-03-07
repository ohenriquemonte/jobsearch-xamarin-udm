using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearch.APP.Models;
using JobSearch.APP.Services;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using JobSearch.APP.Utility.Load;

namespace JobSearch.APP.Views
{
	public partial class Login : ContentPage
	{
		private UserService _service;

		public Login()
		{
			InitializeComponent();

			_service = new UserService();
		}

		void GoRegister(System.Object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new Register());
		}

		private async void GoStart(System.Object sender, System.EventArgs e)
		{
			string email = TxtEmail.Text;
			string password = TxtPassword.Text;

			await Navigation.PushPopupAsync(new Loading());

			//await Task.Delay(3000);

			ResponseService<User> responseService = await _service.GetUser(email, password);

			if (responseService.IsSuccess)
			{
				App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
				await App.Current.SavePropertiesAsync();

				App.Current.MainPage = new NavigationPage(new Start());
			}
			else
			{
				await DisplayAlert("Ops!", "Nenhum usuário encontrado!", "OK");
			}

			await Navigation.PopAllPopupAsync();
		}
	}
}