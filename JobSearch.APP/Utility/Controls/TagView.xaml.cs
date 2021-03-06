using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace JobSearch.APP.Utility.Controls
{
	public partial class TagView : ContentView
	{
		public static readonly BindableProperty TechnologiesProperty = BindableProperty.Create("Technologies", typeof(string), typeof(TagView));
		public string Technologies
		{
			get => (string)GetValue(TagView.TechnologiesProperty);
			set => SetValue(TagView.TechnologiesProperty, value);
		}

		public static readonly BindableProperty NumberOfWordsProperty = BindableProperty.Create("NumberOfWords", typeof(int), typeof(TagView));
		public int NumberOfWords
		{
			get => (int)GetValue(TagView.NumberOfWordsProperty);
			set => SetValue(TagView.NumberOfWordsProperty, value);
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (propertyName == "Technologies")
			{
				Container.Children.Clear();

				if (Technologies != null)
				{
					string[] words = Technologies.Split(',');

					var limit = (words.Count() >= NumberOfWords) ? NumberOfWords : words.Count();

					for (int i = 0; i < limit; i++)
					{
						var frame = new Frame() { BackgroundColor = Color.FromHex("#F7F8FA"), Padding = new Thickness(3), HasShadow = false };
						var label = new Label() { Text = words[i], Padding = new Thickness(3), FontFamily = "MontserratLight", FontSize = 10, TextColor = Color.FromHex("#8D9EAA") };

						frame.Content = label;
						Container.Children.Add(frame);
					}
				}
			}

			base.OnPropertyChanged(propertyName);
		}

		public TagView()
		{
			InitializeComponent();
		}
	}
}
