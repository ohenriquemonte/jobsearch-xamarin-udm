using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class Start : ContentPage
	{
		public Start()
		{
			InitializeComponent();
		}

		void GoVisualizer(System.Object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new Visualizer());
		}

		void GoRegisterJob(System.Object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new RegisterJob());
		}

		void FocusPesquisa(System.Object sender, System.EventArgs e)
		{
			TxtSearch.Focus();
		}

		void FocusCityState(System.Object sender, System.EventArgs e)
		{
			TxtCityState.Focus();
		}

		void Logout(System.Object sender, System.EventArgs e)
		{
			App.Current.Properties.Remove("User");
			Navigation.PushAsync(new Login());
		}
	}
}