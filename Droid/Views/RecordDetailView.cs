
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace AndroidLearningDemo.Droid
{
	public class RecordDetailView : MvxFragment
	{
		private View _view;
		private TextView _textView;

		public RecordDetailViewModel RecordDetailViewModel {
			get { 
				return base.ViewModel as RecordDetailViewModel;
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			_view = this.BindingInflate (Resource.Layout.RecordDetailView, null);

			_textView = _view.FindViewById<TextView> (Resource.Id.RecordTxt);
			_textView.Text = RecordDetailViewModel.RecordDetail;

			return _view;
		}

		public override void OnResume ()
		{
			base.OnResume ();

			_textView.Text = RecordDetailViewModel.RecordDetail;
		}
	}
}

