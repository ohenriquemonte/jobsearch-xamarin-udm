using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
		}

		void GoRegister(System.Object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new Register());
		}

		void GoStart(System.Object sender, System.EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new Start());
		}
	}
}