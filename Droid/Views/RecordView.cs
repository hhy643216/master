
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
using Android.Support.V4.View;

namespace AndroidLearningDemo.Droid
{
	[Activity (Name = "androidLearningDemo.droid.views.RecordView", Label = "レコード詳細", LaunchMode = Android.Content.PM.LaunchMode.SingleTask, 
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme="@style/ActionBarTheme")]			
	public class RecordView : MvxActionBarActivity
	{
		private RecordAdapter _adapter;
		private ViewPager _viewPager;

		public RecordViewModel RecordViewModel {
			get { 
				return base.ViewModel as RecordViewModel;
			}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.RecordView);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			_viewPager = this.FindViewById<ViewPager> (Resource.Id.RecordeDetailViewPager);
			_adapter = new RecordAdapter (this.SupportFragmentManager, this, RecordViewModel.RecordIdList, RecordViewModel.RecordDetailViewModelList);
			_viewPager.Adapter = _adapter;

			var predicate = new Predicate<int>(x => x.Equals(RecordViewModel.RecordId));
			var currentItem = RecordViewModel.RecordIdList.FindIndex(predicate);
			_viewPager.SetCurrentItem (currentItem, false);
		}

		public  override bool OnCreateOptionsMenu (IMenu menu) {
			var inflater = MenuInflater;
			inflater.Inflate (Resource.Menu.TabMenuActions, menu);

			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Android.Resource.Id.Home) {
				Finish ();
				return true;
			}
			if (item.ItemId == Resource.Id.ActionSetting) {
				Intent intent = new Intent (this, typeof(Setting));
				this.StartActivity (intent);
			}
			return base.OnOptionsItemSelected (item);
		}

		public override bool OnKeyDown (Keycode keycode, KeyEvent e)
		{
			return true;
		}
	}
}

