using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace AndroidLearningDemo.Droid.Views
{
	[Activity (Name = "androidlearningdemo.droid.views.SplashView", MainLauncher=true, Icon = "@drawable/splash", Theme = "@style/Theme.Splash", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class SplashView : MvxActivity
	{
		public SplashViewModel SplashViewModel { get { return base.ViewModel as SplashViewModel; } }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			SplashViewModel.ShowTabViewModel ();
		}
	}
}
