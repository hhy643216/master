
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
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace AndroidLearningDemo.Droid.Views
{			
	public class RecordListAdapter : MvxAdapter, IDraggableListAdapter
	{
		private List<RecordDto> _recordList;
		private Context _context;
		private LayoutInflater _inflater;

		public int mMobileCellPosition { get; set;  }

		public RecordListAdapter (Context context, IMvxAndroidBindingContext bindingContext, List<RecordDto> recordList) : base (context, bindingContext)
		{
			_context = context;
			_inflater = (LayoutInflater)_context.GetSystemService (Context.LayoutInflaterService);
			_recordList = new List<RecordDto> ();
			SetItemsSource (recordList);

			mMobileCellPosition = int.MinValue;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (position >= _recordList.Count) {
				return null;
			}

			View view = _inflater.Inflate (Resource.Layout.Item_RecordListRow, parent, false);

			var txtRecode = (TextView)view.FindViewById (Resource.Id.txtRecordListTitle);
			txtRecode.Text = _recordList [position].RecordDetail;

			view.Visibility = mMobileCellPosition == position ? ViewStates.Invisible : ViewStates.Visible;
			view.TranslationY = 0;

			return view;
		}

		protected override View GetBindableView (View convertView, object dataContext, int templateId)
		{
			templateId = Resource.Layout.Item_RecordListRow;
			return base.GetBindableView (convertView, dataContext, templateId);
		}

		public void SetRecordList (List<RecordDto> recordList)
		{
			_recordList = recordList;
			SetItemsSource (recordList);
		}

		public void SwapItems (int indexOne, int indexTwo, bool isMoving = true)
		{
			var oldValue = _recordList [indexOne];
			_recordList [indexOne] = _recordList [indexTwo];
			_recordList [indexTwo] = oldValue;

			if (isMoving) {
				mMobileCellPosition = indexTwo;
			}

			SetRecordList (_recordList);

			NotifyDataSetChanged ();
		}
	}
}

