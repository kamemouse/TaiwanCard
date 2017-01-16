using System;
using Android.Views;

namespace TaiwanCard.Droid
{
	// ref1: http://www.buildinsider.net/mobile/xamarintips/0035
	// ref2: https://developer.xamarin.com/guides/xamarin-forms/custom-renderer/renderers/
	// ref3: https://www.ibm.com/developerworks/jp/java/library/j-mobileforthemasses2/
	public class MyGestureListener : GestureDetector.SimpleOnGestureListener
	{
		public ExAbsoluteLayout ExAbsoluteLayout { private get; set; }

		private SwipeDetector _detector = new SwipeDetector();

		public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			bool ret = base.OnFling(e1, e2, velocityX, velocityY);
			if (ExAbsoluteLayout != null)
			{
				if (_detector.isSwipeLeft(e1, e2, velocityX))
				{
					ExAbsoluteLayout.OnSwipeLeft();
				}
				else if (_detector.isSwipeRight(e1, e2, velocityX))
				{
					ExAbsoluteLayout.OnSwipeRight();
				}
			}
			return ret;
		}
	}
}
