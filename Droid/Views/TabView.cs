using Android.App;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using Android.Views;

namespace AndroidLearningDemo.Droid.Views
{
	[Activity (Name = "androidlearningdemo.droid.views.TabView", Label = "アンドロイド", 
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme="@style/ActionBarTheme")]
	public class TabView : MvxFragmentHost
	{
		private List<FragmentViewModelSet> fragmentViewModelSets;
		private RadioGroup _radioGroup;
		private int _index;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Tab);
			_index = 0;
			PrepareChildFragment ();

			_radioGroup = this.FindViewById<RadioGroup> (Resource.Id.TabItemSelect);
			_radioGroup.CheckedChange += (sender, e) => {
				var radioButton = _radioGroup.FindViewById (e.CheckedId);
				_index = _radioGroup.IndexOfChild (radioButton);
				ShowFragmentOfIndex (_index);
			};

			ShowFragmentOfIndex (_index);
		}

		public override bool OnKeyDown (Keycode keycode, KeyEvent e)
		{
			return true;
		}

		private void PrepareChildFragment ()
		{
			fragmentViewModelSets = new List<FragmentViewModelSet> () {
				new FragmentViewModelSet () {
					FragmentType = typeof(BaiduFragmentView),
					ViewModelRequest = new MvxViewModelRequest<BaiduFragmentViewModel> (null, null, new MvxRequestedBy ())
				},
				new FragmentViewModelSet () {
					FragmentType = typeof(RecordListView),
					ViewModelRequest = new MvxViewModelRequest<RecordListViewModel> (null, null, new MvxRequestedBy ())
				},
				new FragmentViewModelSet () {
					FragmentType = typeof(MapFragmentView),
					ViewModelRequest = new MvxViewModelRequest<MapFragmentViewModel> (null, null, new MvxRequestedBy ())
				}
			};
		}

		private void ShowFragmentOfIndex (int index)
		{
			FragmentViewModelSet fragmentViewModelSet = fragmentViewModelSets [index];
			ShowFragment (Resource.Id.ContentsContainer, fragmentViewModelSet.FragmentType, fragmentViewModelSet.ViewModelRequest);
		}
	}
}


