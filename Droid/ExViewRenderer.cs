using System;
using Android.Views;
using TaiwanCard;
using TaiwanCard.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExAbsoluteLayout), typeof(ExViewRenderer))]
namespace TaiwanCard.Droid
{
	public class ExViewRenderer : ViewRenderer
	{

		private readonly MyGestureListener _listener;
		private readonly GestureDetector _detector;

		public ExViewRenderer()
		{
			_listener = new MyGestureListener();
			_detector = new GestureDetector(_listener);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			_listener.ExAbsoluteLayout = Element as ExAbsoluteLayout;

			GenericMotion += (s, a) => _detector.OnTouchEvent(a.Event);
			Touch += (s, a) => _detector.OnTouchEvent(a.Event);
		}
	}
}
