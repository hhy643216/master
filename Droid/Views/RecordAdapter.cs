using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using Cirrious.CrossCore;
using System.Linq;
using Android.Views;

namespace AndroidLearningDemo.Droid
{
	public class RecordAdapter : FragmentStatePagerAdapter
	{
		private List<int> _recordIdList;
		private List<RecordDetailView> _convertViews;
		private List<RecordDetailViewModel> _viewModelList;

		public RecordAdapter (FragmentManager fm, RecordView activity, List<int> recordIdList, List<RecordDetailViewModel> viewModelList) : base (fm)
		{
			_recordIdList = recordIdList;
			_viewModelList = viewModelList;
			SetUpAvailableViews ();
		}

		public override int Count {
			get { 
				return _recordIdList.Count;
			}
		}

		/// <summary>
		/// RecordDetailViewを取得する
		/// </summary>
		/// <param name="position">Position.</param>
		public override Fragment GetItem (int position)
		{
			var recordId = _recordIdList [position];

			var fragment = GetAvailableView();
			UpdateViewModelRequestParam (fragment, recordId);

			return fragment;
		}

		/// <summary>
		/// システムに回収されたRecordDetailViewを再利用リストに挿入する
		/// </summary>
		/// <param name="container">Container.</param>
		/// <param name="position">Position.</param>
		/// <param name="objectValue">Object value.</param>
		public override void DestroyItem (ViewGroup container, int position, Java.Lang.Object objectValue)
		{
			var convertView = objectValue as RecordDetailView;
			if (convertView != null) 
				_convertViews.Add (convertView);

			base.DestroyItem (container, position, objectValue);
		}

		public override int GetItemPosition (Java.Lang.Object objectValue)
		{
			return PositionNone;
		}

		/// <summary>
		/// 再利用リストを初期化する
		/// </summary>
		private void SetUpAvailableViews () 
		{
			if (_convertViews == null || _convertViews.Count == 0) {
				_convertViews = new List<RecordDetailView> ();

				for (var i = 0; i < 4; i++) {
					var fragment = new RecordDetailView ();

					RecordDetailViewModel viewModel;
					if (_viewModelList.Count < i + 1) {
						viewModel = Mvx.IocConstruct<RecordDetailViewModel> ();
					} else {
						viewModel = _viewModelList [i];
					}

					fragment.ViewModel = viewModel;

					_convertViews.Add (fragment);
				}

			}
		}

		/// <summary>
		/// 利用できるDailyDetailScheduleViewを取得する.
		/// </summary>
		/// <returns>The available view.</returns>
		private RecordDetailView GetAvailableView ()
		{
			if (null == _convertViews || 0 == _convertViews.Count) {
				var fragment = new RecordDetailView ();
				var viewModel = Mvx.IocConstruct<RecordDetailViewModel> (); 
				fragment.ViewModel = viewModel;

				_convertViews.Add (fragment);
			}

			var view = _convertViews.FirstOrDefault ();
			_convertViews.RemoveAt (0);

			return view;
		}

		/// <summary>
		/// 既存のfragmentのviewModelRequestのパラメータを変更し、再利用します
		/// </summary>
		/// <param name="fragment">Fragment.</param>
		/// <param name="date">Date.</param>
		private void UpdateViewModelRequestParam(RecordDetailView fragment, int recordId) 
		{
			if (fragment.ViewModel != null) {
				((RecordDetailViewModel)fragment.ViewModel).RecordId = recordId;
			}
		}
	}
}

