using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class Visualizer : ContentPage
	{
		public Visualizer()
		{
			InitializeComponent();
		}

		void GoBack(System.Object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
	}
}
