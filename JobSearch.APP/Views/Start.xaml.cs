using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using JobSearch.APP.Models;
using JobSearch.APP.Services;
using JobSearch.Domain.Models;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class Start : ContentPage
	{
		private JobService _service;
		private ObservableCollection<Job> _listOfData;

		public Start()
		{
			InitializeComponent();
			_service = new JobService();
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
			App.Current.SavePropertiesAsync();
			App.Current.MainPage = new Login();
		}

		private async void Search(System.Object sender, System.EventArgs e)
		{
			//await Navigation.PushPopupAsync(new Loading());

			string word = TxtSearch.Text;
			string cityState = TxtCityState.Text;

			ResponseService<List<Job>> responseService = await _service.GetJobs(word, cityState);

			if (responseService.IsSuccess)
			{
				_listOfData = new ObservableCollection<Job>(responseService.Data);
				ListOfJobs.ItemsSource = _listOfData;
			}
			else
			{
				//if (responseService.StatusCode == 400)
				//{
				//	StringBuilder sb = new StringBuilder();

				//	foreach (var dicKey in responseService.Errors)
				//	{
				//		foreach (var message in dicKey.Value)
				//		{
				//			sb.AppendLine(message);
				//		}
				//	}

				//	TxtMessages.Text = sb.ToString();
				//}
				//else
				//{
				await DisplayAlert("Ops!", "Ocorreu um erro inesperado! Tente Novamente mais tarde.", "OK");
				//}

				//await Navigation.PopAllPopupAsync();
			}
		}
	}
}