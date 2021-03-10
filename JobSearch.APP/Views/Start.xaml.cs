using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		private ObservableCollection<Job> _listOfJobs;
		private SearchParams _searchParams;
		private int _listOfJobsFirstRequest;

		public Start()
		{
			InitializeComponent();
			_service = new JobService();
		}

		void GoVisualizer(System.Object sender, System.EventArgs e)
		{
			var eventArgs = (TappedEventArgs)e;
			var page = new Visualizer();
			page.BindingContext = eventArgs.Parameter;

			Navigation.PushAsync(page);
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
			Loading.IsVisible = true;
			Loading.IsRunning = true;
			NoResult.IsVisible = false;

			//System.Threading.Thread.Sleep(2000);
			//await Task.Delay(2000);

			string word = TxtSearch.Text;
			string cityState = TxtCityState.Text;

			_searchParams = new SearchParams() { Word = word, CityState = cityState, NumberOfPage = 1 };

			ResponseService<List<Job>> responseService = await _service.GetJobs(_searchParams.Word, _searchParams.CityState, _searchParams.NumberOfPage);

			if (responseService.IsSuccess)
			{
				_listOfJobs = new ObservableCollection<Job>(responseService.Data);
				_listOfJobsFirstRequest = _listOfJobs.Count;
				ListOfJobs.ItemsSource = _listOfJobs;
				ListOfJobs.RemainingItemsThreshold = 1;
			}
			else
			{
				await DisplayAlert("Ops!", "Ocorreu um erro inesperado! Tente Novamente mais tarde.", "OK");
			}

			if (_listOfJobs.Count == 0)
				NoResult.IsVisible = true;
			else
				NoResult.IsVisible = false;

			Loading.IsVisible = false;
			Loading.IsRunning = false;
		}

		private async void InfinitySearch(System.Object sender, System.EventArgs e)
		{
			ListOfJobs.RemainingItemsThreshold = -1;
			_searchParams.NumberOfPage++;

			ResponseService<List<Job>> responseService = await _service.GetJobs(_searchParams.Word, _searchParams.CityState, _searchParams.NumberOfPage);

			if (responseService.IsSuccess)
			{
				var listOfJobsFromService = responseService.Data;
				foreach (var item in listOfJobsFromService)
				{
					_listOfJobs.Add(item);
				}

				if (_listOfJobsFirstRequest == listOfJobsFromService.Count)
				{
					ListOfJobs.RemainingItemsThreshold = 1;
				}
				else
				{
					ListOfJobs.RemainingItemsThreshold = -1;
				}
			}
			else
			{
				await DisplayAlert("Ops!", "Ocorreu um erro inesperado na listagem! Tente Novamente mais tarde.", "OK");
				ListOfJobs.RemainingItemsThreshold = 0;
			}
		}
	}
}