
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
using AndroidLearningDemo.Droid.Views;

namespace AndroidLearningDemo.Droid
{
	[Activity (Label = "Setting", Theme="@style/ActionBarTheme")]			
	public class Setting : MvxActionBarEventSourceActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			TextView txt = new TextView (this);
			txt.Text = "SETTING";
			txt.Gravity = GravityFlags.Center;
			SetContentView (txt);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Android.Resource.Id.Home) {
				Intent intent = new Intent (this, typeof(TabView));
				intent.SetFlags (ActivityFlags.SingleTop | ActivityFlags.ClearTop);
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

