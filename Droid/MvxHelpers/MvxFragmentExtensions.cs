using System;

using Android.Views;
using Android.OS;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace AndroidLearningDemo.Droid
{
	public static class MvxFragmentExtensions
	{
		private const string ViewModelRequestKey = "MvxViewModelRequest";

		public static void ProvideViewModelRequest (this MvxFragment fragment, MvxViewModelRequest request)
		{
			var bundle = fragment.Arguments ?? (fragment.Arguments = new Bundle ());

			var serializer = Mvx.Resolve<IMvxNavigationSerializer> ();
			var requestString = serializer.Serializer.SerializeObject (request);

			bundle.PutString (ViewModelRequestKey, requestString);
		}

		public static void CreateViewWhenCalled (this MvxFragment fragment,LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

		}
	}
}

