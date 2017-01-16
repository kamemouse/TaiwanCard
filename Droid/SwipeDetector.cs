using System;
using Android.Views;

namespace TaiwanCard.Droid
{
	// ref: https://www.ibm.com/developerworks/jp/java/library/j-mobileforthemasses2/
	public class SwipeDetector
	{
		private int swipe_distance;
		private int swipe_velocity;
		private const int SWIPE_MIN_DISTANCE = 120;
		private const int SWIPE_THRESHOLD_VELOCITY = 200;

		public SwipeDetector(int distance, int velocity)
		{
			swipe_distance = distance;
			swipe_velocity = velocity;
		}

		public SwipeDetector()
		{
			swipe_distance = SWIPE_MIN_DISTANCE;
			swipe_velocity = SWIPE_THRESHOLD_VELOCITY;
		}

		public bool isSwipeDown(MotionEvent e1, MotionEvent e2, float velocityY)
		{
			return isSwipe(e2.GetY(), e1.GetY(), velocityY);
		}

		public bool isSwipeUp(MotionEvent e1, MotionEvent e2, float velocityY)
		{
			return isSwipe(e1.GetY(), e2.GetY(), velocityY);
		}

		public bool isSwipeLeft(MotionEvent e1, MotionEvent e2, float velocityX)
		{
			return isSwipe(e1.GetX(), e2.GetX(), velocityX);
		}

		public bool isSwipeRight(MotionEvent e1, MotionEvent e2, float velocityX)
		{
			return isSwipe(e2.GetX(), e1.GetX(), velocityX);
		}

		private bool isSwipeDistance(float coordinateA, float coordinateB)
		{
			return (coordinateA - coordinateB) > swipe_distance;
		}

		private bool isSwipeSpeed(float velocity)
		{
			return Math.Abs(velocity) > swipe_velocity;
		}

		private bool isSwipe(float coordinateA, float coordinateB, float velocity)
		{
			return isSwipeDistance(coordinateA, coordinateB)
					&& isSwipeSpeed(velocity);
		}
	}
}
