using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using JobSearch.APP.Droid.Utility.Controls;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace JobSearch.APP.Droid.Utility.Controls
{
	public class CustomEntryRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
	{
		public CustomEntryRenderer(Context context) : base(context)
		{

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Background = null;
				Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
			}
		}
	}
}