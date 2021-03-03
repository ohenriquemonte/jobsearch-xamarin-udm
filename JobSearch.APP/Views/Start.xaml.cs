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
	}
}