using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.APP
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();


			// Logout
			// App.Current.Properties.Remove("User");

			if (App.Current.Properties.ContainsKey("User"))
			{
				MainPage = new NavigationPage(new Views.Start());
			}
			else
			{
				// MainPage = new MainPage();
				MainPage = new NavigationPage(new Views.Login());
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
