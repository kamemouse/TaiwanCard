using System;
using Xamarin.Forms;

namespace TaiwanCard
{
	// ref1: http://www.buildinsider.net/mobile/xamarintips/0035
	// ref2: https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/renderers/
	// ref3: http://tryworks-design.com/?p=2267
	// ref4: https://kisagai.com/2012/05/06/uiswipegesturerecognizer%E3%81%A7%E5%85%A8%E6%96%B9%E5%90%91%E8%AA%8D%E8%AD%98%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95/
	public class ExAbsoluteLayout : AbsoluteLayout
	{
		public event EventHandler LeftSwiped;
		public event EventHandler RightSwiped;

		public void OnSwipeLeft()
		{
			if (LeftSwiped != null)
			{
				LeftSwiped(this, new EventArgs());
			}
		}
		public void OnSwipeRight()
		{
			if (RightSwiped != null)
			{
				RightSwiped(this, new EventArgs());
			}
		}
	}
}
