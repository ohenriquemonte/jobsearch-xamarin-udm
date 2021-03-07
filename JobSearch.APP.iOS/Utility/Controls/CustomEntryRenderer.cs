using System;
using JobSearch.APP.iOS.Utility.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace JobSearch.APP.iOS.Utility.Controls
{
	public class CustomEntryRenderer : EntryRenderer
	{
		public CustomEntryRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Layer.BorderWidth = 0;
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
			}
		}
	}
}
