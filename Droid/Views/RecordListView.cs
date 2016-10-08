
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
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace AndroidLearningDemo.Droid.Views
{
	public class RecordListView : MvxFragment
	{
		private View _view;
		private DraggableListView _listView;
		private TextView _textView;
		private EditText _editText;
		private Button _button;

		private RecordListViewModel RecordListViewModel {
			get { 
				return base.ViewModel as RecordListViewModel;
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
		    base.OnCreateView (inflater, container, savedInstanceState);

			var parentView = Activity as TabView;
			if (parentView != null) {
				parentView.Title = "レコード";
			}

			_view = this.BindingInflate (Resource.Layout.RecordListView, null);

			_textView = (TextView)_view.FindViewById (Resource.Id.recordListNull);
			_editText = (EditText)_view.FindViewById (Resource.Id.recordWrite);
			_button = (Button)_view.FindViewById (Resource.Id.writeBtn);

			_button.Click += (sender, e) => {
				SaveRecord (_editText);
				_editText.Text = null;
				ReloadRecordList ();
			};

			_listView = (DraggableListView)_view.FindViewById (Resource.Id.recordListView);
			_listView.Adapter = new RecordListAdapter (this.Activity, BindingContext as IMvxAndroidBindingContext, null);

			return _view;
		}

		public override void OnResume ()
		{
			base.OnResume ();

			ReloadRecordList ();
		}

		private void ReloadRecordList ()
		{
			var recordDtoList = RecordListViewModel.RecordList;
			if (recordDtoList == null || recordDtoList.Count == 0) {
				_textView.Visibility = ViewStates.Visible;
				_listView.Visibility = ViewStates.Gone;
			} else {
				_textView.Visibility = ViewStates.Gone;
				_listView.Visibility = ViewStates.Visible;

				var adapter = (RecordListAdapter)_listView.Adapter;
				adapter.SetRecordList (recordDtoList);
				adapter.NotifyDataSetChanged ();
			}
		}

		private void SaveRecord (EditText editText)
		{
			var txt = editText.Text;
			if (txt != null && !string.IsNullOrEmpty(txt)) {
				RecordListViewModel.SaveRecord (txt.ToString ());
			}
		}
	}
}
