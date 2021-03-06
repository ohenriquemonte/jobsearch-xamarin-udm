using System;
using System.Collections.Generic;
using System.Text;
using JobSearch.APP.Models;
using JobSearch.APP.Services;
using JobSearch.APP.Utility.Converters;
using JobSearch.APP.Utility.Load;
using JobSearch.Domain.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace JobSearch.APP.Views
{
	public partial class RegisterJob : ContentPage
	{
		private JobService _service;

		public RegisterJob()
		{
			InitializeComponent();
			_service = new JobService();
		}

		void GoBack(System.Object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}

		private async void Save(System.Object sender, System.EventArgs e)
		{
			// TODO - Adicionar Validação

			TxtMessages.Text = String.Empty;

			User user = JsonConvert.DeserializeObject<User>(App.Current.Properties["User"].ToString());

			Job job = new Job()
			{
				Company = TxtCompany.Text,
				JobTitle = TxtJobTitle.Text,
				CityState = TxtCityState.Text,
				InitialSalary = TextToDouble.ToDouble(TxtInitialSalary.Text),
				FinalSalary = TextToDouble.ToDouble(TxtFinalSalary.Text),
				ContractType = (RBCLT.IsChecked) ? "CLT" : "PJ",
				TecnologyTools = TxtTecnologyTools.Text,
				CompanyDescription = TxtCompanyDescription.Text,
				JobDescription = TxtJobDescription.Text,
				Benefits = TxtBenefits.Text,
				InterestedSendEmailTo = TxtInterestedSendEmailTo.Text,
				PublicationDate = DateTime.Now,
				UserId = user.Id
			};

			await Navigation.PushPopupAsync(new Loading());

			ResponseService<Job> responseService = await _service.AddJob(job);

			if (responseService.IsSuccess)
			{
				await Navigation.PopAllPopupAsync();
				await DisplayAlert("Vaga Salva", "A vaga foi cadastrada com sucesso!", "OK");
				await Navigation.PopAsync();
			}
			else
			{
				if (responseService.StatusCode == 400)
				{
					//await DisplayAlert("Ops!", "Nenhum usuário encontrado!", "OK");

					StringBuilder sb = new StringBuilder();

					foreach (var dicKey in responseService.Errors)
					{
						foreach (var message in dicKey.Value)
						{
							sb.AppendLine(message);
						}
					}

					TxtMessages.Text = sb.ToString();
				}
				else
				{
					await DisplayAlert("Ops!", "Ocorreu um erro inesperado! Tente Novamente mais tarde.", "OK");
				}

				await Navigation.PopAllPopupAsync();
			}
		}
	}
}