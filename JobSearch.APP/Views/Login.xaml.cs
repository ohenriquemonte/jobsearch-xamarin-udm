using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobSearch.APP.Services;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

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

			User user = await _service.GetUser(email, password);

			if (user == null)
			{
				await DisplayAlert("Ops!", "Nenhum usuário encontrado!", "OK");
			}
			else
			{
				App.Current.Properties.Add("User", JsonConvert.SerializeObject(user));
				await App.Current.SavePropertiesAsync();

				App.Current.MainPage = new NavigationPage(new Start());
			}
		}
	}
}