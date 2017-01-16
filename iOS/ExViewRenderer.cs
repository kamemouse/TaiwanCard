using System;
using TaiwanCard;
using TaiwanCard.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExAbsoluteLayout), typeof(ExViewRenderer))]
namespace TaiwanCard.iOS
{
	public class ExViewRenderer : ViewRenderer
	{
		// ref1: http://www.buildinsider.net/mobile/xamarintips/0035
		// ref2: https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/renderers/
		// ref3: http://tryworks-design.com/?p=2267
		// ref4: https://kisagai.com/2012/05/06/uiswipegesturerecognizer%E3%81%A7%E5%85%A8%E6%96%B9%E5%90%91%E8%AA%8D%E8%AD%98%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95/
		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			var exAbsoluteLayout = Element as ExAbsoluteLayout;
			var gr = new UISwipeGestureRecognizer(o => exAbsoluteLayout.OnSwipeLeft());
			gr.Direction = UISwipeGestureRecognizerDirection.Left;
			AddGestureRecognizer(gr);

			gr = new UISwipeGestureRecognizer(o => exAbsoluteLayout.OnSwipeRight());
			gr.Direction = UISwipeGestureRecognizerDirection.Right;
			AddGestureRecognizer(gr);
		}
	}
}
