using System;
using Android.App;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Android.Widget;

namespace AndroidLearningDemo.Droid
{
	public class ErrorHandler : IErrorHandler
	{
		protected Activity Activity {
			get { return Mvx.Resolve<IMvxAndroidCurrentTopActivity> ().Activity;}
		}

		public void HandleGeneralError (string message)
		{
			Toast.MakeText (Activity.ApplicationContext, message, ToastLength.Long).Show ();
		}
	}
}

