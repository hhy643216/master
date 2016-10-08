using System;
using Cirrious.MvvmCross.ViewModels;

namespace AndroidLearningDemo
{
	public class SplashViewModel : MvxViewModel
	{
		public SplashViewModel ()
		{
		}

		public void ShowTabViewModel ()
		{
			ShowViewModel<TabViewModel> ();
		}
	}
}

