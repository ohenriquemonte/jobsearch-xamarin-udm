using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class RegisterJob : ContentPage
	{
		public RegisterJob()
		{
			InitializeComponent();
		}

		void GoBack(System.Object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}

		void Save(System.Object sender, System.EventArgs e)
		{
			DisplayAlert("Vaga Salva", "A vaga foi cadastrada com sucesso!", "OK");
			Navigation.PopAsync();
		}
	}
}