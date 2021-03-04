using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using JobSearch.APP.Droid.Utility.Controls;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace JobSearch.APP.Droid.Utility.Controls
{
	public class CustomEditorRenderer : Xamarin.Forms.Platform.Android.EditorRenderer
	{
		public CustomEditorRenderer(Context context) : base(context)
		{

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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